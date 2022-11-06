namespace cv_backend.Dto;

public class ExperienceDto
{
    public string UserEmail { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyLocation { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
