using backend_assignment.Data;
using backend_assignment.Dtos;
using backend_assignment.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController(AppDbContext context) : ControllerBase
{
  private readonly AppDbContext _context = context;

  // GET: api/Question/5
  [HttpGet("{id}")]
  public ActionResult<QuestionDto> GetQuestion(int id)
  {
    var question = _context
      .Questions.Include(q => q.FirstAnswer)
      .Include(q => q.SecondAnswer)
      .Include(q => q.ThirdAnswer)
      .Include(q => q.FourthAnswer)
      .ToList()
      .Find(q => q.Id == id);

    if (question == null)
    {
      return NotFound();
    }

    return question.ToQuestionDto();
  }
}
