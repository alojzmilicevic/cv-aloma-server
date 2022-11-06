namespace cv_backend.Models;

public class Experience
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyLocation { get; set; } = string.Empty;
    public User User { get; set; }
}
