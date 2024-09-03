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
    ExamDto dto =
      new()
      {
        Q1Id = exam.QuestionPaper.Q1Id,
        Q2Id = exam.QuestionPaper.Q2Id,
        Q3Id = exam.QuestionPaper.Q3Id,
        Q4Id = exam.QuestionPaper.Q4Id,
        Q5Id = exam.QuestionPaper.Q5Id,
      };
    return dto;
  }

  [HttpGet("{id}")]
  public ActionResult<ExamDto> GetExam(int id)
  {
    var exam = _context.Exams.Include(e => e.QuestionPaper).ToList().Find(e => e.Id == id);

    if (exam == null)
    {
      return NotFound();
    }
    ExamDto dto =
      new()
      {
        Q1Id = exam.QuestionPaper.Q1Id,
        Q2Id = exam.QuestionPaper.Q2Id,
        Q3Id = exam.QuestionPaper.Q3Id,
        Q4Id = exam.QuestionPaper.Q4Id,
        Q5Id = exam.QuestionPaper.Q5Id,
      };
    return dto;
  }
}
