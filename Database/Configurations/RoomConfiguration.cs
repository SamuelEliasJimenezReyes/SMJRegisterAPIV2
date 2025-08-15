using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMJRegisterAPIV2.Entities;

namespace SMJRegisterAPIV2.Database.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Habitaciones");
        
        builder.HasKey(x => x.ID);
        builder.HasQueryFilter(x => !x.IsDeleted);
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("NombreHabitacion");
        
        builder.Property(x=>x.MaxCapacity)
            .HasColumnName("CapacidadMaxima");
        
        builder.Property(x=>x.CurrentCapacity)
            .HasColumnName("CapacidadActual");
        
        builder.Property(x => x.Gender)
            .HasConversion<string>()
            .HasColumnName("Genero");
        
        builder.HasMany(x => x.Campers)
            .WithOne(x => x.Room)
            .HasForeignKey(x => x.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}