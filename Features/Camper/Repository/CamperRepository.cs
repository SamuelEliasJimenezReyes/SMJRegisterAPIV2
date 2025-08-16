using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Camper.Repository;

public class CamperRepository(ApplicationDbContext context) :  GenericRepository<Entities.Camper>(context), ICamperRepository
{
   
    public override async Task<List<Entities.Camper>> GetAllAsync(int pageNumber, int pageSize)
        =>await context.Campers
            .AsSplitQuery()
            .Include(c => c.Church)
            .Include(c => c.Room)
            .Include(c=>c.GrantedCode)
            .ToListAsync();

    public override async Task<Entities.Camper> GetByIdAsync(int id)
        => await context.Campers
            .Include(c=>c.Church)
            .Include(c => c.Room)
            .Include(c=>c.GrantedCode)
            .Where(x=>x.ID == id)
            .FirstOrDefaultAsync();

    

    public async Task<List<Entities.Camper>> GetAllByChurchIDAsync(int churchID)
    => await context.Campers
        .Where(x => x.ChurchId == churchID)
        .Include(x=>x.Church)
        .Include(c => c.Room)
        .Include(c=>c.GrantedCode)
        .ToListAsync();
    
    public async Task<bool> ExistByPhoneNumber(string phoneNumber)
        => await context.Campers.AnyAsync(camper => camper.PhoneNumber == phoneNumber);

}