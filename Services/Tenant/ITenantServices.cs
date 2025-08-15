using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Services.Tenant;

public interface ITenantServices
{
    Conference GetCurrentConference();
    string GetCurrentUserId();
}