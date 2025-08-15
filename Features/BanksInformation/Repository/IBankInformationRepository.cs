using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.BanksInformation.Repository;

public interface IBankInformationRepository : IGenericRepository<Entities.BanksInformation>
{
    Task<List<Entities.BanksInformation>> GetAllBanksInformationByConference(int conference);
}