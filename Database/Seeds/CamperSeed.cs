using Bogus;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Database.Seeds;

public static class CamperSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {

        var id = 1;

        var faker = new Faker<Camper>("es")
            .RuleFor(p => p.ID, f => id++)
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(x => x.Age, f => f.Random.Int(12, 40))
            .RuleFor(x => x.Coments, f => f.Lorem.Sentence())
            .RuleFor(x => x.DocumentsURL, f => f.Internet.Url())
            .RuleFor(x => x.PaidAmount, f => f.Random.Number(0, 4600))
            .RuleFor(x => x.TotalAmount, f => 4600)
            .RuleFor(x => x.IsGrant, f => f.Random.Bool(0.2f))
            .RuleFor(x => x.IsPaid, (f, p) => p.PaidAmount >= p.TotalAmount)
            .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
            .RuleFor(x => x.Condition, f => f.PickRandom<Condition>())
            .RuleFor(x => x.PayWay, f => f.PickRandom<PayWay>())
            .RuleFor(x => x.ShirtSize, f => f.PickRandom<ShirtSize>())
            .RuleFor(x => x.ArrivedTimeSlot, f => f.PickRandom<ArrivedTimeSlot>())
            .RuleFor(x => x.ChurchId, f => f.Random.Int(1, 194));

        var campers = faker.Generate(300);

        modelBuilder.Entity<Camper>().HasData(campers);
    }
}