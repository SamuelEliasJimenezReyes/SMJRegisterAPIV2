using Bogus.DataSets;
using SMJRegisterAPIV2.Common.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Entities; 
public class Room : BaseEntity
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    
    //relationships
    public ICollection<Camper> Campers { get; set; }
}