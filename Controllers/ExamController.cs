using backend_assignment.Data;
using backend_assignment.Dtos;
using backend_assignment.Mappers;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController(AppDbContext context) : ControllerBase
{
  private readonly AppDbContext _context = context;

  // GET: api/Exam
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
  {
    return await _context.Exams.ToListAsync();
  }

  // GET: api/Exam/5
  [HttpGet("latest")]
  public async Task<ActionResult<ExamDto>> GetExam()
  {
    var exam = await _context.Exams.Include(e => e.QuestionPaper).OrderBy(e => e.Id).LastAsync();

    if (exam == null)
    {
      return NotFound();
    }
    return exam.ToExamDto();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ExamDto>> GetExam(int id)
  {
    var exam = await _context
      .Exams.Include(e => e.QuestionPaper)
      .FirstOrDefaultAsync(e => e.Id == id);

    if (exam == null)
    {
      return NotFound();
    }
    return exam.ToExamDto();
  }
}
