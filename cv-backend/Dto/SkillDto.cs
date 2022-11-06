using cv_backend.Models;

namespace cv_backend.Dto;

public class SkillDto
{
    public string UserEmail { get; set; } = string.Empty;
    public string SkillName { get; set; } = string.Empty;
    public string SkillDescription { get; set; } = string.Empty;
    public int SkillLevel { get; set; }
}
