namespace SMJRegisterAPIV2.Features.Payment.Dtos;

public class CreatePaymentDto
{
    public decimal Amount { get; set; }
    public IFormFile? Evidence { get; set; }
    public string? Coments { get; set; }
    public bool IsCash { get; set; }
    //Relationships
    public int? BanksInformationId { get; set; }
    public int CamperId { get; set; }
}