using System.Security.Claims;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Services.Tenant;

public class TenantServices(IHttpContextAccessor httpContextAccessor) : ITenantServices
{
    public Conference GetCurrentConference()
    {
        var claim = httpContextAccessor.HttpContext?.User?.FindFirst("conference");
        if (claim == null || !Enum.TryParse<Conference>(claim.Value, out var conference))
        {
            return Conference.General;
        }
        return conference;
    }

    public string GetCurrentUserId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value 
               ?? throw new UnauthorizedAccessException("User not authenticated");
    }
}