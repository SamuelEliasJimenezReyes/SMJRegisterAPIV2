// Services/MigrationService.cs

using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Services.FileStore;

namespace SMJRegisterAPIV2.Services;

public class MigrationService
{
    private readonly ApplicationDbContext _context;
    private readonly IFileStorage _fileStorage;
    private readonly ILogger<MigrationService> _logger;

    public MigrationService(ApplicationDbContext context, IFileStorage fileStorage, ILogger<MigrationService> logger)
    {
        _context = context;
        _fileStorage = fileStorage;
        _logger = logger;
    }

    public async Task MigrateCamperDocumentsToKeys()
    {
        var campers = await _context.Campers
            .Where(c => c.DocumentsURL.Contains("r2.cloudflarestorage.com"))
            .ToListAsync();

        foreach (var camper in campers)
        {
            camper.DocumentsURL = _fileStorage.ExtractKeyFromUrl(camper.DocumentsURL);
            camper.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}