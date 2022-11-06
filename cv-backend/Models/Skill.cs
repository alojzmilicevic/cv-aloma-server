namespace cv_backend.Models;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; } = string.Empty;
    public string SkillDescription { get; set; } = string.Empty;
    public int SkillLevel { get; set; }
    public User User { get; set; }
}
