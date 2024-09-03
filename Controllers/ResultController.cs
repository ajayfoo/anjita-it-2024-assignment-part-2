
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_assignment.Data;
using backend_assignment.Models;

namespace backend_assignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResultController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // GET: api/Exam
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Result>>> GetResults()
    {
        return await _context.Results.ToListAsync();
    }

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
}
