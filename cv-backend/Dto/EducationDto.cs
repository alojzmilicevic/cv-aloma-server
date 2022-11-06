namespace cv_backend.Dto;

public class EducationDto
{
    public string UserEmail { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string EducationDescription { get; set; } = string.Empty;
    public string OtherInformation { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
