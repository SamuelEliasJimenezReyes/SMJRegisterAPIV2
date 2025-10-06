using System.Text;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Features.BanksInformation.Repository;
using SMJRegisterAPIV2.Features.Camper.Repository;
using SMJRegisterAPIV2.Features.Church.Repository;
using SMJRegisterAPIV2.Features.Common;
using SMJRegisterAPIV2.Features.GrantedCode.Repository;
using SMJRegisterAPIV2.Features.Payment.Repository;
using SMJRegisterAPIV2.Features.Room.Repository;
using SMJRegisterAPIV2.Middlewares;
using SMJRegisterAPIV2.Services;
using SMJRegisterAPIV2.Services.CodeGenerator;
using SMJRegisterAPIV2.Services.FileStore;
using SMJRegisterAPIV2.Services.Tenant;
using SMJRegisterAPIV2.Services.User;

var builder = WebApplication.CreateBuilder(args);

#region DbContext Configurations
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    
    string connectionString;
    
    if (string.IsNullOrEmpty(databaseUrl))
    {
        // Usar connection string de desarrollo
        connectionString = builder.Configuration.GetConnectionString("ProdConnection");
    }
    else
    {
        // Parsear DATABASE_URL de Railway correctamente
        // Formato: postgresql://user:password@host:port/database
        var uri = new Uri(databaseUrl);
        var userInfo = uri.UserInfo.Split(':');
        
        connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = uri.Host,
            Port = uri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = uri.AbsolutePath.TrimStart('/'),
            SslMode = SslMode.Require,
            TrustServerCertificate = true,
            Pooling = true,
            MaxPoolSize = 20,
            Timeout = 30,
            CommandTimeout = 30
        }.ToString();
    }

    Console.WriteLine($"Using connection string: {connectionString.Replace("Password=", "Password=***")}");
    
    options.UseNpgsql(connectionString, npgsqlOptions => 
    {
        npgsqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
        npgsqlOptions.CommandTimeout(30);
    });
    
    // Solo en desarrollo
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});
#endregion

#region Repositories and Services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICamperRepository, CamperRepository>();
builder.Services.AddScoped<IChurchRepository, ChurchRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IGenerateCodeService, GenerateCodeService>();
builder.Services.AddScoped<IGrantedCodeRepository, GrantedCodeRepository>();
builder.Services.AddScoped<IBankInformationRepository, BankInformationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddSingleton<IFileStorage, FileStorage>();
builder.Services.AddScoped<ITenantServices, TenantServices>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenServices>();
// builder.Services.AddScoped<MigrationService>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddHttpContextAccessor();
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
#endregion

#region Automapper y MediatR
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
#endregion

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

#region Swagger + Carter
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Introduce el token JWT así: Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();
#endregion

#region Auth
var jwtKey = builder.Configuration["JwtSettings:Key"];
var jwtIssuer = builder.Configuration["JwtSettings:Issuer"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtIssuer,
        RoleClaimType = "conference",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();
#endregion

var app = builder.Build();

 // using (var scope = app.Services.CreateScope())
 // {
 //    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
 //     db.Database.Migrate();
 // }

#region Uso de static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    RequestPath = ""
});

#endregion

#region Middlewares
if (builder.Environment.IsDevelopment() || builder.Environment.EnvironmentName == "Dev")
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMJRegister API V1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapCarter();

app.UseExceptionHandler(cfg =>
{
    cfg.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ValidationException ve)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var errors = ve.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            await context.Response.WriteAsJsonAsync(new { errors });
        }
        else
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var detail = new
            {
                error = exception?.Message,
                stackTrace = exception?.StackTrace
            };

            await context.Response.WriteAsJsonAsync(detail);
        }
    });
});

#endregion

app.MapGet("/health", async (ApplicationDbContext context) =>
{
    try
    {
        var canConnect = await context.Database.CanConnectAsync();
        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        
        return Results.Ok(new 
        {
            status = canConnect ? "Healthy" : "Unhealthy",
            database = canConnect ? "Connected" : "Disconnected",
            pendingMigrations = pendingMigrations.ToArray(),
            timestamp = DateTime.UtcNow
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Unhealthy: {ex.Message}");
    }
});

// app.MapPost("/api/migrate-documents", async (HttpContext httpContext) =>
// {
//     try
//     {
//         // Obtener el servicio del contenedor de dependencias
//         var migrationService = httpContext.RequestServices.GetRequiredService<MigrationService>();
//         await migrationService.MigrateCamperDocumentsToKeys();
//         return Results.Ok("Migración completada exitosamente");
//     }
//     catch (Exception ex)
//     {
//         return Results.Problem($"Error en migración: {ex.Message}");
//     }
// });

app.MapGet("/test", () => "API is running!");

app.Run();
