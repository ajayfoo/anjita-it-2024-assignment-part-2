using backend_assignment.Data;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResultController(AppDbContext context) : ControllerBase
{
  private readonly AppDbContext _context = context;

  // GET: api/Exam/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Exam>> GetResult(int id)
  {
    var exam = await _context.Exams.FindAsync(id);

    if (exam == null)
    {
      return NotFound();
    }

    return exam;
  }

  [HttpGet]
  public IResult RenderPage()
  {
    return Results.File("/pages/result.html", "text/html");
  }
}
