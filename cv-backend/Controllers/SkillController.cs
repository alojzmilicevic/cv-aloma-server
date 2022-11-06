using cv_backend.Data;
using cv_backend.Dto;
using cv_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillController : ControllerBase
{
    private readonly DataContext db;

    public SkillController(DataContext context)
    {
        db = context;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> AllSkills(string email)
    {
        var user = await db.User.Where(u => u.Email == email).FirstOrDefaultAsync();
        if (user == null)
        {
            return BadRequest("User not found");

        }
        var skills = await db.Skill.Where(x => x.User == user).Select(s => new SkillDto()
        {
            SkillDescription = s.SkillDescription,
            SkillLevel = s.SkillLevel,
            SkillName = s.SkillName,            
        }).ToListAsync();

        return Ok(skills);
    }

    [HttpPost("add-skill")]
    public async Task<IActionResult> AddSkill(SkillDto body)
    {
        var user = await db.User.FirstOrDefaultAsync(x => x.Email == body.UserEmail);
        if (user == null)
        {
            return BadRequest("User not found");

        }
        
        await db.Skill.AddAsync(new Skill()
        {
            SkillName = body.SkillName,
            SkillDescription = body.SkillDescription,
            SkillLevel = body.SkillLevel,
            User = user,
        });
        await db.SaveChangesAsync();

        return Ok("Added skill");
    }
}