using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.Camper.Repository;

public interface ICamperRepository : IGenericRepository<Entities.Camper>
{
    Task<List<Entities.Camper>> GetAllByChurchIDAsync(int churchID);
}