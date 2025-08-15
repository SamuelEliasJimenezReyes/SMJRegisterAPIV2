using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Database.Contexts;
using SMJRegisterAPI.Features.BanksInformation.Dtos;
using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.BanksInformation.Repository;

public class BankInformationRepository(ApplicationDbContext context) : GenericRepository<Entities.BanksInformation>(context), IBankInformationRepository
{
    public async Task<List<Entities.BanksInformation>> GetAllBanksInformationByConference(int conference)
        => await context.BanksInformations
            .Where(x => x.Conference == (Entities.Enums.Conference)conference)
            .ToListAsync();

}