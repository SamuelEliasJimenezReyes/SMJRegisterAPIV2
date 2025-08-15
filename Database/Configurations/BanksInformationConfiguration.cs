using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Database.Configurations;

public class BanksInformationConfiguration(Conference tenantConference) : IEntityTypeConfiguration<BanksInformation>
{
    public void Configure(EntityTypeBuilder<BanksInformation> builder)
    {
        builder.ToTable("Cuentas");
        
        builder.HasKey(x => x.ID);
        
        builder.Property(x => x.AccountNumber)
            .HasMaxLength(100)
            .HasColumnName("NumeroDeCuenta");
        
        builder.Property(x => x.Conference)
            .HasConversion<string>()
            .HasColumnName("Conferencia");
        
        builder.Property(x => x.BankName)
            .HasConversion<string>()
            .HasColumnName("Banco");
    }
}