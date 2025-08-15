using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Database.Configurations;


public class ChurchConfiguration(Conference tenantConference) : IEntityTypeConfiguration<Church>
{
    

    public void Configure(EntityTypeBuilder<Church> builder)
    {
        builder.ToTable("Iglesias");
        
        builder.HasKey(x => x.ID);
       
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("Nombre");
        
        builder.Property(x => x.Conference)
            .HasConversion<string>()
            .HasColumnName("Conferencia");
    }
}