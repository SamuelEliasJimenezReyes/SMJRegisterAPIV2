namespace SMJRegisterAPIV2.Features.Dashboard.Dtos;

public class DashboardSummaryDto
{
    public int TotalCampersPaid { get; set; }
    public decimal TotalAmountPaid { get; set; }
    public decimal TotalAmountPending { get; set; }
}