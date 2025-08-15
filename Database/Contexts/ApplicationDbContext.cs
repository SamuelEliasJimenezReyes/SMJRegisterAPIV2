using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Database.Seeds;
using SMJRegisterAPI.Entities;
using SMJRegisterAPI.Entities.Enums;
using SMJRegisterAPI.Services.Tenant;

namespace SMJRegisterAPI.Database.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantServices tenantServices) : IdentityDbContext<User>(options)
{
    public DbSet<Camper> Campers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<GrantedCode> GrantedCodes { get; set; }
    public DbSet<Church> Churches { get; set; }
    public DbSet<BanksInformation> BanksInformations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        ConfigureTenantFilters(modelBuilder);

        ApplySeedData(modelBuilder);
    }

    private void ConfigureTenantFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanksInformation>()
            .HasQueryFilter(x => !x.IsDeleted && 
                                 (tenantServices.GetCurrentConference() == Conference.General 
                                  || x.Conference == tenantServices.GetCurrentConference()));

        modelBuilder.Entity<Church>()
            .HasQueryFilter(x => !x.IsDeleted && 
                                 (tenantServices.GetCurrentConference() == Conference.General 
                                  || x.Conference == tenantServices.GetCurrentConference()));

        modelBuilder.Entity<Camper>()
            .HasQueryFilter(x => !x.IsDeleted && 
                                 (tenantServices.GetCurrentConference() == Conference.General 
                                  || (x.Church != null && x.Church.Conference == tenantServices.GetCurrentConference())));
    }

    private void ApplySeedData(ModelBuilder modelBuilder)
    {
        ChurchSeed.Seed(modelBuilder);
        CamperSeed.Seed(modelBuilder);
        RoomSeed.Seed(modelBuilder);
        BankInformationSeed.Seed(modelBuilder);
    }
}