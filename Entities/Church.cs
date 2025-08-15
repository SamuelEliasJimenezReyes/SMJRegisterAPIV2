using SMJRegisterAPIV2.Common.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Entities;

public class Church : BaseEntity
{
    public string Name { get; set; }
    public Conference Conference { get; set; }
    
    //Relationsship
    public ICollection<Camper> Campers { get; set; }
}