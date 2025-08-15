using SMJRegisterAPI.Common.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Entities;

public class Church : BaseEntity
{
    public string Name { get; set; }
    public Conference Conference { get; set; }
    
    //Relationsship
    public ICollection<Camper> Campers { get; set; }
}