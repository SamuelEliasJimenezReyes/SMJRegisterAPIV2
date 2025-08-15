using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;
using SMJRegisterAPIV2.Services.CodeGenerator;

namespace SMJRegisterAPIV2.Features.GrantedCode.Repository;

public class GrantedCodeRepository (ApplicationDbContext context, IGenerateCodeService codeGeneratorService) : GenericRepository<Entities.GrantedCode>(context) , IGrantedCodeRepository
{
    public override Task<List<Entities.GrantedCode>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        return context.GrantedCodes
            .Include(x=>x.Camper)
            .ToListAsync();
    }

    public async  Task<Entities.GrantedCode> AddWithCodeAsync(Entities.GrantedCode entity, int Amount)
    {
        var codeGenerated = codeGeneratorService.GenerateAlphanumericCode();
        var codeExits =  context.GrantedCodes.Any(grantedCode => grantedCode.Code == codeGenerated); 
        do
        {
            codeGenerated = codeGeneratorService.GenerateAlphanumericCode();
        } while (codeExits);
        entity.Code = codeGenerated;
        entity.GrantAmount = Amount;
        entity.IsUsed = false;
        
        await context.GrantedCodes.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Entities.GrantedCode> GetByCodeAsync(string code)
        =>  await context.GrantedCodes.FirstOrDefaultAsync(grantedCode => grantedCode.Code == code);

    public async Task<bool> ExistCodeAsync(string code)
    => await context.GrantedCodes.AnyAsync(grantedCode => grantedCode.Code == code);
    
    public async Task<bool> CodeIsUsedAsync(string code)
    => await context.GrantedCodes.AnyAsync(grantedCode => grantedCode.Code == code && grantedCode.IsUsed);
}