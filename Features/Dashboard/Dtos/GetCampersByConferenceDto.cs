namespace SMJRegisterAPIV2.Features.Dashboard.Dtos;

public class GetCampersByConferenceDto
{
    public string Conference { get; set; }
    public int CamperCount { get; set; }
}