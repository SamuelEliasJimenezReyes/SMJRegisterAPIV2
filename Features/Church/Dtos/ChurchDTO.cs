using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Church.Dtos;

public class ChurchDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    
    public ICollection<CamperDTO> Campers { get; set; }
}