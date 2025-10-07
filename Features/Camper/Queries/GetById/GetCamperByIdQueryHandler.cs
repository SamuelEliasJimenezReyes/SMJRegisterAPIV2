using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;
using SMJRegisterAPIV2.Services.FileStore;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetById;

public class GetCamperByIdQueryHandler(
    ICamperRepository repository,
    IMapper mapper,
    IFileStorage fileStorage)
    : IRequestHandler<GetCamperByIdQuery, CamperDTO>
{
    public async Task<CamperDTO> Handle(GetCamperByIdQuery request, CancellationToken cancellationToken)
    {
        var entityDb = await repository.GetByIdAsync(request.ID);
        var mapped = mapper.Map<CamperDTO>(entityDb);

        if (!string.IsNullOrEmpty(mapped.DocumentsURL))
        {
            try
            {
                var key = fileStorage.ExtractKeyFromUrl(mapped.DocumentsURL);
                var signedUrl = fileStorage.GetSignedUrl(key, 5);
                mapped.DocumentsURL = signedUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generando URL firmada: {ex.Message}");
                mapped.DocumentsURL = null;
            }
        }

        return mapped;
    }
}