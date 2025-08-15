using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Services.Tenant;

public interface ITenantServices
{
    Conference GetCurrentConference();
    string GetCurrentUserId();
}