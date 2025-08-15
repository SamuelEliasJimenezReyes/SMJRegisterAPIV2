using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.BanksInformation.Repository;

public interface IBankInformationRepository : IGenericRepository<Entities.BanksInformation>
{
    Task<List<Entities.BanksInformation>> GetAllBanksInformationByConference(int conference);
}