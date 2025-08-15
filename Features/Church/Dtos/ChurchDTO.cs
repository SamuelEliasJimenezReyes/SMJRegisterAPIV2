using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Church.Dtos;

public class ChurchDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    
    public ICollection<CamperDTO> Campers { get; set; }
}