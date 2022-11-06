using cv_backend.Data;
using cv_backend.Dto;
using cv_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly DataContext db;

    public EducationController(DataContext context)
    {
        db = context;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> Education(string email)
    {
        var user = await db.User.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var education = await db.Education.Where(x => x.User == user).Select(s => new EducationDto()
        {
            Degree = s.Degree,
            EducationDescription = s.EducationDescription,
            OtherInformation = s.OtherInformation,
            School = s.School,
            StartDate = s.StartDate,
            EndDate = s.EndDate,
        }).ToListAsync();

        return Ok(education);
    }

    [HttpPost("add-education")]
    public async Task<IActionResult> AddEducation(EducationDto body)
    {
        var user = await db.User.FirstOrDefaultAsync(x => x.Email == body.UserEmail);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var education = new Education
        {
            User = user,
            School = body.School,
            Degree = body.Degree,
            StartDate = body.StartDate,
            EndDate = body.EndDate,
            EducationDescription = body.EducationDescription,
            OtherInformation = body.OtherInformation
        };

        await db.Education.AddAsync(education);
        await db.SaveChangesAsync();


        return Ok(body);
    }
}