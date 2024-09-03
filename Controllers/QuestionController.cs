using backend_assignment.Data;
using backend_assignment.Dtos;
using backend_assignment.Mappers;
using backend_assignment.Models;
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
  public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
  {
    var question = await _context.Questions.FindAsync(id);

    if (question == null)
    {
      return NotFound();
    }

    return question.ToQuestionDto();
  }
}
