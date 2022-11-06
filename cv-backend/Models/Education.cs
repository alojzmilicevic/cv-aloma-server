namespace cv_backend.Models;

public class Education
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Degree { get; set; } = string.Empty;
    public string EducationDescription { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public string OtherInformation { get; set; } = string.Empty;
    public User User { get; set; }
}
