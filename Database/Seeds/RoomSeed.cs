using Bogus;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Entities;

namespace SMJRegisterAPIV2.Database.Seeds;

public class RoomSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var roomsNames = new List<string>()
        {
            "Habitación alta",
            "Habitación baja",
            "Atras del Comedor",
            "Dormitorio Izquierda",
            "Dormitorio Derecha",
            "Piso 3"
        };

        var id = 1;
        var faker = new Faker<Room>("es")
            .RuleFor(x => x.ID, f => id++)
            .RuleFor(x => x.Gender, f => f.PickRandom<Entities.Enums.Gender>())
            .RuleFor(p=>p.MaxCapacity , f=>f.Random.Int(2,51))
            .RuleFor(p=>p.Name, f=>f.PickRandom(roomsNames));
        
        foreach (var entity in faker.Generate(5))
            modelBuilder.Entity<Room>().HasData(entity);
        
    }
}