using cv_backend.Data;
using cv_backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext db;

    public UserController(DataContext context)
    {
        db = context;
    }

    [HttpGet("{userEmail}")]
    public async Task<IActionResult> User(string userEmail)
    {
        var user = await db.User.Where(u => u.Email == userEmail).Select(p => new UserDto()
        {
            PhoneNumber = p.PhoneNumber,
            Address = p.Address,
            City = p.City,
            Description = p.Description,
            Email = p.Email,
            Name = p.Name,
            Skills = p.Skills,
            Education = p.Education,
            Experience = p.Experience,
            
        }).FirstOrDefaultAsync();

        if (user == null)
        {
            return BadRequest("User not found");
        }

        return Ok(user);
    }


}