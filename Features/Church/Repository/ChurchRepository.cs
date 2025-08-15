using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Database.Contexts;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.Church.Repository;

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