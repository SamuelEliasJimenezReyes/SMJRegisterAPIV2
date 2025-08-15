using MediatR;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Command.Delete;

public class DeleteCamperCommandHandler(ICamperRepository repository) : IRequestHandler<DeleteCamperCommand, bool>
{
    public async Task<bool> Handle(DeleteCamperCommand request, CancellationToken cancellationToken)
    {
        var entityDb = await repository.GetByIdAsync(request.Id);
        if (entityDb is null)
            return false;
        await repository.DeleteAsync(entityDb);
        return true;

    }
}