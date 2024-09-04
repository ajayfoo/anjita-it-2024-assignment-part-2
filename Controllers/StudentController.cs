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

  private async Task InitStudentSession(Student student)
  {
    Exam latestExam = await _context.Exams.OrderBy(e => e.Id).LastAsync();
    Response response =
      new()
      {
        Student = student,
        StudentId = student.Id,
        Exam = latestExam,
        ExamId = latestExam.Id,
      };
    await _context.Responses.AddAsync(response);
    await _context.SaveChangesAsync();
    var session = new StudentSession() { ResponseId = response.Id };
    await _context.StudentSessions.AddAsync(session);
    await _context.SaveChangesAsync();
    var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), HttpOnly = true };
    Response.Cookies.Append("emailId", student.EmailId, cookieOptions);
    Response.Cookies.Append("studentSessionId", session.Id.ToString(), cookieOptions);
  }

  [HttpPut]
  public async Task<ActionResult<string>> PutStudent(Student student)
  {
    _context.Entry(student).State = student.Id == 0 ? EntityState.Added : EntityState.Modified;
    await _context.SaveChangesAsync();
    await InitStudentSession(student);
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
