namespace cv_backend.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Skill> Skills { get; set; } = new List<Skill>();
    public List<Experience> Experience { get; set; } = new List<Experience>();
    public List<Education> Education { get; set; } = new List<Education>();
}
