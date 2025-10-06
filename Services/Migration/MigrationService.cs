// // Services/MigrationService.cs
//
// using Microsoft.EntityFrameworkCore;
// using SMJRegisterAPIV2.Database.Contexts;
// using SMJRegisterAPIV2.Services.FileStore;
//
// namespace SMJRegisterAPIV2.Services;
//
// public class MigrationService
// {
//     private readonly ApplicationDbContext _context;
//     private readonly IFileStorage _fileStorage;
//     private readonly ILogger<MigrationService> _logger;
//
//     public MigrationService(ApplicationDbContext context, IFileStorage fileStorage, ILogger<MigrationService> logger)
//     {
//         _context = context;
//         _fileStorage = fileStorage;
//         _logger = logger;
//     }
//
//     public async Task MigrateCamperDocumentsToKeys()
//     {
//         _logger.LogInformation("Iniciando migración de URLs a Keys...");
//
//         var campers = await _context.Campers
//             .Where(c => !string.IsNullOrEmpty(c.DocumentsURL))
//             .ToListAsync();
//
//         int updatedCount = 0;
//
//         foreach (var camper in campers)
//         {
//             try
//             {
//                 if (camper.DocumentsURL.StartsWith("http"))
//                 {
//                     var key = _fileStorage.ExtractKeyFromUrl(camper.DocumentsURL);
//                     
//                     _logger.LogInformation($"Migrando Camper {camper.ID}: {camper.DocumentsURL} -> {key}");
//                     
//                     camper.DocumentsURL = key;
//                     updatedCount++;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, $"Error migrando Camper {camper.ID}: {ex.Message}");
//             }
//         }
//
//         if (updatedCount > 0)
//         {
//             await _context.SaveChangesAsync();
//             _logger.LogInformation($"Migración completada. {updatedCount} registros actualizados.");
//         }
//         else
//         {
//             _logger.LogInformation("No se encontraron registros para migrar.");
//         }
//     }
// }