using Bogus;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Database.Seeds;

public class BankInformationSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var banksInfo = new List<BanksInformation>
        {
            new BanksInformation
            {
                ID = 1,
                BankName = Banks.Popular,
                AccountNumber = "785889601",
                Conference = Conference.Sureste
            },
            new BanksInformation
            {
                ID = 2,
                BankName = Banks.BanReservas,
                AccountNumber = "9601266314",
                Conference = Conference.Sureste
            },
            new BanksInformation
            {
                ID = 3,
                BankName = Banks.BanReservas,
                AccountNumber = "9603689644",
                Conference = Conference.Central
            },
            new BanksInformation
            {
                ID = 4,
                BankName = Banks.Popular,
                AccountNumber = "833350150",
                Conference = Conference.Central
            },
            new BanksInformation
            {
                ID = 5,
                BankName = Banks.Popular,
                AccountNumber = "790839831",
                Conference = Conference.Noroeste
            },
            new BanksInformation
            {
                ID = 6,
                BankName = Banks.Popular,
                AccountNumber = "9605995258",
                Conference = Conference.Noroeste
            }
        };

        modelBuilder.Entity<BanksInformation>().HasData(banksInfo);
    }

}