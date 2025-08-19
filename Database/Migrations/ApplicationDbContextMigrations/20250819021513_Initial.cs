using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMJRegisterAPIV2.Database.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BanksInformations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanksInformations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Churches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreHabitacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "integer", nullable: false),
                    CapacidadActual = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Coments = table.Column<string>(type: "text", nullable: true),
                    DocumentsURL = table.Column<string>(type: "text", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsGrant = table.Column<bool>(type: "boolean", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    PayWay = table.Column<int>(type: "integer", nullable: false),
                    ShirtSize = table.Column<int>(type: "integer", nullable: false),
                    ArrivedTimeSlot = table.Column<int>(type: "integer", nullable: false),
                    ChurchId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: true),
                    GrantedCodeId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Campers_Churches_ChurchId",
                        column: x => x.ChurchId,
                        principalTable: "Churches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campers_Habitaciones_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Habitaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CodigosDeDescuento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CantidadDescontada = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    CamperId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosDeDescuento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CodigosDeDescuento_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CantidadAPagar = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    EvidenceURL = table.Column<string>(type: "text", nullable: true),
                    Comentarios = table.Column<string>(type: "text", nullable: true),
                    BanksInformationId = table.Column<int>(type: "integer", nullable: false),
                    CamperId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pagos_BanksInformations_BanksInformationId",
                        column: x => x.BanksInformationId,
                        principalTable: "BanksInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagos_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BanksInformations",
                columns: new[] { "ID", "AccountNumber", "BankName", "Conference", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "785889601", 1, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7054), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "9601266314", 3, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7064), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "9603689644", 3, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7065), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "833350150", 1, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7066), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "790839831", 1, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7067), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "9605995258", 1, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(7069), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Churches",
                columns: new[] { "ID", "Conference", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6613), false, "El Valle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6625), false, "Higüey I", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6627), false, "Higüey II", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6627), false, "Magua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6628), false, "Romana I (Central)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6630), false, "Romana II, Quisqueya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6631), false, "Romana III, (Casa de Alabanzas)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6632), false, "Romana IV, Villa Progreso", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6632), false, "Romana V, La Lechoza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6634), false, "Romana VI, Barrio George", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6634), false, "Romana VII, Piedra Linda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6635), false, "Romana VIII", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6636), false, "Romana IX", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6636), false, "Romana X", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6637), false, "Romana XI (Benjamín)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6638), false, "Sabana de la Mar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6639), false, "San Pedro I, Central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6640), false, "San Pedro II, Villa Olímpica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6641), false, "San Pedro IV (Canaan) - Capilla S. Pedro II", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6642), false, "San Pedro III, Barrio Miramar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6642), false, "Azua Central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6643), false, "Azua, Finca 6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6644), false, "Azua, Finca Etnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6644), false, "Azua, Las Charcas (Étnico)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6645), false, "Azua, Sector El Hoyo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6646), false, "Baní", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6647), false, "Bani, El Fundo - Capilla Bani", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6647), false, "Barahona", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6648), false, "Elías Piña", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6648), false, "Ocoa Etnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6649), false, "San Cristóbal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6650), false, "San Cristóbal (Étnico)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6650), false, "San Cristóbal Étnico II", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6652), false, "San José de Ocoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6653), false, "San Juan I (Central)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6653), false, "San Juan II - Casa de Adoración", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6654), false, "San Juan III (El Renuevo)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6655), false, "Alma Rosa Primera", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6655), false, "Carretera Mella (Luz en las Tinieblas)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6656), false, "Ens. Isabelita", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6657), false, "Ensanche Cancela (Étnico)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6657), false, "Ensanche Ozama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6658), false, "Mendoza (Capilla Ozama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6658), false, "Invivienda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6659), false, "Villa Esfuerzo - Capilla Invivienda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6660), false, "Los Frailes I", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6660), false, "Los Mina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6661), false, "Los Tres Brazos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6662), false, "Los Tres Ojos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6662), false, "Urbanización Ciudad Juan Bosch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6663), false, "Urbanización Lomisa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6664), false, "Valiente  (Étnico)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6664), false, "Villa Faro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6665), false, "Villa Mella, Buena Vista II.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6666), false, "Villa Mella, El Edén", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6666), false, "Villa Mella, Guaricano Étnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6667), false, "Villa Mella, Vista Bella III", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6667), false, "Casa del Padre - Hotel Golden House", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6668), false, "Cristo Rey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6669), false, "Ensanche La Fe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6669), false, "Ensanche Luperón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6670), false, "Ensanche Quisqueya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6671), false, "Arroyo Bonito - Capilla Quisqueya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6671), false, "Haina Étnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6672), false, "Boca Nigua - Capilla Haina Boca Etnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6674), false, "Haina Shalom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6674), false, "Herrera - Barrio Enriquillo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6675), false, "Palmarejo - Capilla Herrera", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6675), false, "Jardines del Norte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6676), false, "Jesús el Mesías, (La 15) Barrio 27 de Febrero", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6720), false, "Juan de Morfa (Central)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6721), false, "Km 24 , Barrio Eduardo Brito, Autop. Duarte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6721), false, "Km.24 Etnico - Capilla", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6722), false, "Manoguayabo - Hato Nuevo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6723), false, "Nación Santa, Enriquillo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6723), false, "Haina Balsequillo - Capilla N. Santa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6724), false, "Majagual, Sabana Perdida - Capilla N. Santa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6724), false, "Pantoja", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6725), false, "Roca Mar, En Su presencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6725), false, "Constanza - Capilla En Su presencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6726), false, "Simon Bolivar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 2, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6727), false, "Villa Linda - Ciudad Satelite - Capilla", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6739), false, "Beller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6740), false, "Camboya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6741), false, "Canca La Piedra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6741), false, "Casa de Reposo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6742), false, "Casa Viva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6743), false, "Cien Fuegos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6743), false, "El Ingenio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6744), false, "El INVI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6745), false, "El Paraíso", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6745), false, "Ensanche Libertad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6746), false, "Ensanche Mella", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6746), false, "Hoya del Caimito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6747), false, "La Herradura", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6748), false, "Los Cerritos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6748), false, "Los Cocos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6749), false, "Los Jardines", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6749), false, "Monte Bonito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6750), false, "Navarrete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6750), false, "Palmar Arriba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6751), false, "Pekín", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6752), false, "Puesto Grande", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6752), false, "Tamboril", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6753), false, "Castañuelas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6753), false, "Cerro Gordo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6754), false, "Damajagua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6755), false, "El Pocito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6755), false, "Esperanza 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6756), false, "Esperanza Manantial de Vida", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6757), false, "Esperanza Paraíso", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6757), false, "Hatico, Mao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6758), false, "Hatillo Palma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6758), false, "Hato Nuevo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6759), false, "Jaibón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6759), false, "Loma de Cabrera", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6760), false, "Los Tomines", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6760), false, "Maizal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6761), false, "Mao Central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6762), false, "Martín García", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6762), false, "Monte Cristi 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6763), false, "Monte Cristi 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6764), false, "Monte Cristi 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6764), false, "Ranchadero", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6765), false, "Santiago Rodríguez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6765), false, "Villa Sinda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6766), false, "Villa Vásquez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6766), false, "Altamira", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6767), false, "Bethel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6769), false, "Cabía", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6770), false, "Caonao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6770), false, "El Tabernáculo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6771), false, "Guananico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6772), false, "Imbert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6772), false, "La Balsa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6773), false, "La Escalereta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6773), false, "La Isabela", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6774), false, "La Jagua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6775), false, "Las Canas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6775), false, "Luperón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6776), false, "Navas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6776), false, "Palmarito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6777), false, "Proyecto Ama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6778), false, "Puerto Plata Central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6778), false, "Rincón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, 1, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6779), false, "San Marcos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6788), false, "San Francisco Central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6828), false, "Piantini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6829), false, "Ventura Grullon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6830), false, "Cotuí", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6831), false, "La Bija", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6831), false, "La Espínola", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6832), false, "La Enea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6833), false, "La Soledad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6833), false, "Vista del Valle SFM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6834), false, "Pimentel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6834), false, "Villa Arriba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6835), false, "El Indio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6835), false, "Castillo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6836), false, "Bonao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6837), false, "La Vega", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6837), false, "Palmarito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 163, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6838), false, "Salcedo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6838), false, "Bayacanes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6839), false, "Moca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6840), false, "IML de la Majagua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6840), false, "IML de Sánchez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6841), false, "IML de las Terrenas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6842), false, "IML de Samaná", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6842), false, "IML de los Corales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6843), false, "IML de Arroyo Hondo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6843), false, "IML de la Ceiba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6844), false, "IML de la Pascuala", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6845), false, "IML de los Robalos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6845), false, "IML del Catey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6846), false, "IML del Limón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6846), false, "Nagua central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6847), false, "Telanza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6848), false, "Km3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6848), false, "El Yayal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6849), false, "Matancitas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6850), false, "Sabaneta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 183, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6850), false, "Las 500tas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 184, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6851), false, "Bella Vista", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 185, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6851), false, "El Juncal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 186, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6852), false, "Baoba del piñal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 187, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6853), false, "Baoba central", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 188, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6853), false, "La Entrada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6854), false, "Los rincones", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 190, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6855), false, "Los naranjos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6855), false, "Las gordas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 192, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6856), false, "Boba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6856), false, "La Cienega", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, 3, new DateTime(2025, 8, 19, 2, 15, 13, 187, DateTimeKind.Utc).AddTicks(6857), false, "Abreu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campers_ChurchId",
                table: "Campers",
                column: "ChurchId");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_RoomId",
                table: "Campers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigosDeDescuento_CamperId",
                table: "CodigosDeDescuento",
                column: "CamperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_BanksInformationId",
                table: "Pagos",
                column: "BanksInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CamperId",
                table: "Pagos",
                column: "CamperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CodigosDeDescuento");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BanksInformations");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Churches");

            migrationBuilder.DropTable(
                name: "Habitaciones");
        }
    }
}
