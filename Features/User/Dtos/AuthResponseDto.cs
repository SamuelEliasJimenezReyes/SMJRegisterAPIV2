namespace SMJRegisterAPI.Features.User.Dtos;

public class AuthResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}