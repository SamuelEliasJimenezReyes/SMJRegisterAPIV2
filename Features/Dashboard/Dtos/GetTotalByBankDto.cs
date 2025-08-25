namespace SMJRegisterAPIV2.Features.Dashboard.Dtos;

public class GetTotalByBankDto
{
    public string BankName { get; set; }
    public decimal TotalAmount { get; set; }
}