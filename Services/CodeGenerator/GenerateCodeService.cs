namespace SMJRegisterAPI.Services.CodeGenerator;

public class GenerateCodeService : IGenerateCodeService
{
    public string GenerateAlphanumericCode(int length=6)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
    }
}