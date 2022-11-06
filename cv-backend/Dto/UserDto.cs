using cv_backend.Models;

namespace cv_backend.Dto;

public class UserDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Skill> Skills { get; set; } = new List<Skill>();
    public List<Education> Education { get; set; } = new List<Education>();
    public List <Experience> Experience { get; set; } = new List<Experience>();

}
