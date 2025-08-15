using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPI.Entities;

namespace SMJRegisterAPI.Database.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Pagos");
        builder.HasKey(x => x.ID);
        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.Property(x => x.Amount)
            .HasColumnName("CantidadAPagar")
            .HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.Coments)
            .HasConversion<string>()
            .HasColumnName("Comentarios");
        
        builder.HasOne(x=>x.BanksInformation)
            .WithMany(x=>x.Payments)
            .HasForeignKey(x=>x.BanksInformationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x=>x.Camper)
            .WithMany(x=>x.Payments)
            .HasForeignKey(x=>x.CamperId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}