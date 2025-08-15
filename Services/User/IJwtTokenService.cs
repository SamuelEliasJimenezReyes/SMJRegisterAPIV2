using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Services.User;

public interface IJwtTokenService
{
     string GenerateToken(string userId, string email, Conference conference);
}