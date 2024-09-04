using System.Text.Json.Nodes;
using backend_assignment.Data;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(AppDbContext context) : ControllerBase
{
  private readonly AppDbContext _context = context;

  // POST: api/Student
  [HttpPut]
  public async Task<ActionResult<string>> PutStudent(Student student)
  {
    _context.Entry(student).State = student.Id == 0 ? EntityState.Added : EntityState.Modified;
    await _context.SaveChangesAsync();
    var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), Path = "/" };
    Response.Cookies.Append("emailId", student.EmailId, cookieOptions);
    cookieOptions.HttpOnly = true;
    Response.Cookies.Append("studentId", student.Id.ToString(), cookieOptions);
    return "/question";
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
