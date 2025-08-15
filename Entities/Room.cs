using Bogus.DataSets;
using SMJRegisterAPI.Common.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Entities; 
public class Room : BaseEntity
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    
    //relationships
    public ICollection<Camper> Campers { get; set; }
}