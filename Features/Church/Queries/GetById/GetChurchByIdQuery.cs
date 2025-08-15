using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;

namespace SMJRegisterAPI.Features.Church.Queries.GetById;

public class GetChurchByIdQuery : IRequest<ChurchDTO>
{
    public int Id { get; set; }
}