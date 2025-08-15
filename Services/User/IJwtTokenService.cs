using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Services.User;

public interface IJwtTokenService
{
     string GenerateToken(string userId, string email, Conference conference);
}