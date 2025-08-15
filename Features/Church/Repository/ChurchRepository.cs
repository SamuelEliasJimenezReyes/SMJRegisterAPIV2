using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Church.Repository;

public class ChurchRepository(ApplicationDbContext context) : GenericRepository<Entities.Church>(context), IChurchRepository 
{
    
    public async Task<Entities.Church> GetByIdWithCamper(int id)
    {
        var entity = await context.Churches
            .Include(x=>x.Campers)
            .ThenInclude(x=>x.Room)
            .FirstOrDefaultAsync(x=>x.ID == id);
        return entity;
    }

    public async Task<List<Entities.Church>> GetByConference(int conference)
        => await context.Churches
            .Where(x => x.Conference == (Entities.Enums.Conference)conference)
            .OrderBy(x => x.Name)
            .ToListAsync();
    
}