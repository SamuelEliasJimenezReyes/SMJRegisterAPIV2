using Bogus;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Entities;

namespace SMJRegisterAPIV2.Database.Seeds;

public static class PaymentSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var id = 1;
        var faker = new Faker<Payment>("es")
            .RuleFor(p => p.ID, f => id++)
            .RuleFor(p => p.Amount, f => f.Random.Decimal(100, 2000))
            .RuleFor(p => p.EvidenceURL, f => f.Internet.Url())
            .RuleFor(p => p.Coments, f => f.Lorem.Sentence())
            .RuleFor(p => p.IsCash, f => f.Random.Bool(0.4f))
            .RuleFor(p => p.BanksInformationId, (f, p) => 
                p.IsCash == true ? null : f.Random.Int(1, 6))
            .RuleFor(p => p.CamperId, f => f.Random.Int(1, 50))
            .RuleFor(p => p.IsDeleted, f => false)
            .RuleFor(p => p.CreatedAt, f => DateTime.UtcNow.AddDays(-f.Random.Number(1, 30)))
            .RuleFor(p => p.UpdatedAt, f => DateTime.UtcNow);

        var payments = faker.Generate(150);

        modelBuilder.Entity<Payment>().HasData(payments);
    }
}