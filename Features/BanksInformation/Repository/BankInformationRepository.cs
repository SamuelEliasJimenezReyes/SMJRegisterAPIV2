using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.BanksInformation.Repository;

public class BankInformationRepository(ApplicationDbContext context) : GenericRepository<Entities.BanksInformation>(context), IBankInformationRepository
{
    public async Task<List<Entities.BanksInformation>> GetAllBanksInformationByConference(int conference)
        => await context.BanksInformations
            .Where(x => x.Conference == (Entities.Enums.Conference)conference)
            .ToListAsync();

}