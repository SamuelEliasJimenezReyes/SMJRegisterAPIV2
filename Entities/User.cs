using Microsoft.AspNetCore.Identity;
using SMJRegisterAPI.Entities.Enums;
namespace SMJRegisterAPI.Entities;

public class User : IdentityUser
{
    public Conference Conference { get; set; } = Conference.General;
}