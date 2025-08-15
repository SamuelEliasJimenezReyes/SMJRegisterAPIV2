using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Church.Repository;

public interface IChurchRepository : IGenericRepository<Entities.Church>
{
    Task<Entities.Church> GetByIdWithCamper(int id);
     Task<List<Entities.Church>> GetByConference(int conference);
}