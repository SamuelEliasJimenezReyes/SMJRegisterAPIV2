using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Camper.Repository;

public interface ICamperRepository : IGenericRepository<Entities.Camper>
{
    Task<List<Entities.Camper>> GetAllByChurchIDAsync(int churchID);
    Task<bool> ExistByPhoneNumber(string phoneNumber);
    Task<List<Entities.Camper>> FindByFilterAsync(string? filter);
}