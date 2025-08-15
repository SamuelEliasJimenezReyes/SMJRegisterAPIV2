namespace SMJRegisterAPI.Services.CodeGenerator;

public interface IGenerateCodeService
{
    string GenerateAlphanumericCode(int length = 6);
}