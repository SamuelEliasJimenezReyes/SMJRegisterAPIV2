using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPI.Entities;

namespace SMJRegisterAPI.Database.Configurations;

public class GrantedCodeConfiguration : IEntityTypeConfiguration<GrantedCode>
{
    public void Configure(EntityTypeBuilder<GrantedCode> builder)
    {
        builder.ToTable("CodigosDeDescuento");
        
        builder.HasKey(x => x.ID);

        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.Property(x => x.Code)
            .HasMaxLength(100)
            .HasColumnName("Codigo");

        builder.Property(x => x.GrantAmount)
            .HasColumnName("CantidadDescontada")
            .HasColumnType("decimal(18,2)");
        
            //RelationShips
        builder.HasOne(x=> x.Camper)
            .WithOne(x=>x.GrantedCode)
            .HasForeignKey<GrantedCode>(x=>x.CamperId);
    }
}