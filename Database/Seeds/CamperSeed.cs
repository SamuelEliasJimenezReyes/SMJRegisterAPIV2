using Bogus;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Database.Seeds
{
    public class CamperSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var churchIds = modelBuilder.Model
                .GetEntityTypes()
                .First(e => e.ClrType == typeof(Church))
                .GetSeedData()
                .Select(d => (int)d["ID"])
                .ToList();

            var id = 1;

            var faker = new Faker<Camper>("es")
                .RuleFor(p => p.ID, f => id++)
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.PhoneNumber, f => f.Person.Phone)
                .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
                .RuleFor(x => x.Condition, f => f.PickRandom<Condition>())
                .RuleFor(x => x.PayWay, f => f.PickRandom<PayWay>())
                .RuleFor(x => x.ShirtSize, f => f.PickRandom<ShirtSize>())
                .RuleFor(x => x.PaidAmount, f => f.Random.Number(0, 2500))
                .RuleFor(x => x.ChurchId, f => f.PickRandom(churchIds));

            foreach (var entity in faker.Generate(20))
                modelBuilder.Entity<Camper>().HasData(entity);
        }
    }
}
