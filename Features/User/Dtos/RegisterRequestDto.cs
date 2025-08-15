namespace SMJRegisterAPIV2.Features.User.Dtos;

public class RegisterRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Passsword { get; set; }
    public int Conference { get; set; }
}