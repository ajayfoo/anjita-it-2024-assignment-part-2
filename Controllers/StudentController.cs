using Microsoft.AspNetCore.Mvc;
using backend_assignment.Data;
using backend_assignment.Models;

namespace backend_assignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    // POST: api/User
    [HttpPut]
    public async Task<ActionResult<Student>> PutUser(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }
}
