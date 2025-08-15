using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetById;

public class GetChurchByIdQuery : IRequest<ChurchDTO>
{
    public int Id { get; set; }
}