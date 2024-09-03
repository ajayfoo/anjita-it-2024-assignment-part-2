using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_assignment.Data;
using backend_assignment.Models;

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
    [HttpGet("{id}")]
    public async Task<ActionResult<Exam>> GetExam(int id)
    {
        var exam = await _context.Exams.FindAsync(id);

        if (exam == null)
        {
            return NotFound();
        }

        return exam;
    }

    [HttpPost]
    public async Task<ActionResult<Exam>> PostExam(Exam exam)
    {
        _context.Exams.Add(exam);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
    }
}
