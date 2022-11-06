using cv_backend.Data;
using cv_backend.Dto;
using cv_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ExperienceController : ControllerBase
{
    private readonly DataContext db;

    public ExperienceController(DataContext context)
    {
        db = context;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> Experiences(string email)
    {
        var user = await db.User.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var experiences = await db.Experience.Where(x => x.User.Email == email).Select(s => new ExperienceDto()
        {
            CompanyLocation = s.CompanyLocation,
            CompanyName = s.CompanyName,
            JobDescription = s.JobDescription,
            JobTitle = s.JobTitle,
            StartDate = s.StartDate,
            EndDate = s.EndDate,
        }).ToListAsync();


        return Ok(experiences);
    }

    [HttpPost("add-experience")]
    public async Task<IActionResult> AddExperience(ExperienceDto body)
    {
        var user = await db.User.FirstOrDefaultAsync(x => x.Email == body.UserEmail);
        if (user == null)
        {
            return BadRequest("User not found");

        }

        var experience = new Experience
        {
            User = user,
            CompanyLocation = body.CompanyLocation,
            CompanyName = body.CompanyName,
            EndDate = body.EndDate,
            JobDescription = body.JobDescription,
            JobTitle = body.JobTitle,
            StartDate = body.StartDate,
        };

        await db.Experience.AddAsync(experience);
        await db.SaveChangesAsync();




        return Ok(experience);
    }
}