using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Database.Configurations;

public class CamperConfiguration(Conference tenantConference) : IEntityTypeConfiguration<Camper>
{
    public void Configure(EntityTypeBuilder<Camper> builder)
    {
        builder.ToTable("Campistas");
  
        builder.HasKey(x => x.ID);
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("Nombre");
        
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11)
            .HasColumnName("NumeroDeTelefono");

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .HasColumnName("Apellido");
        
        builder.Property(x => x.Age)
            .HasColumnName("Edad");
        
        builder.Property(x => x.Coments)
            .HasConversion<string>()
            .HasColumnName("Comentarios");
        
        builder.Property(x => x.PaidAmount)
            .HasColumnName("CantidadPaga")
            .HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.TotalAmount)
            .HasColumnName("CantidadAPagar")
            .HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.IsGrant)
            .HasColumnName("Becado");
        
        builder.Property(x => x.Gender)
            .HasConversion<string>()
            .HasColumnName("Genero");
        
        builder.Property(x => x.Condition)
            .HasConversion<string>()
            .HasColumnName("Condicion");
        
        builder.Property(x => x.PayWay)
            .HasConversion<string>()
            .HasColumnName("TipoDePago");
        
        builder.Property(x => x.ShirtSize)
            .HasConversion<string>()
            .HasColumnName("SizeDeCamisa");

        builder.Property(x => x.ArrivedTimeSlot)
            .HasConversion<string>()
            .HasColumnName("HoraDeLlegada");

        builder.HasOne(x=> x.Church)
            .WithMany(x=>x.Campers)
            .HasForeignKey(x=>x.ChurchId);
        
        builder.HasOne(x=>x.Room)
            .WithMany(x=>x.Campers)
            .HasForeignKey(x=>x.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}