using Microsoft.AspNetCore.Identity;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Entities;

public class User : IdentityUser
{
    public Conference Conference { get; set; } = Conference.General;
}