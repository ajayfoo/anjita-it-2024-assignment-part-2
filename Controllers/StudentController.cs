using Microsoft.AspNetCore.Mvc;
using backend_assignment.Data;
using backend_assignment.Models;

namespace backend_assignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    // POST: api/Student
    [HttpPut]
    public async Task<ActionResult<Student>> PutStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            Path = "/"
        };
        Response.Cookies.Append("emailId", student.EmailId, cookieOptions);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return student;
    }
}
