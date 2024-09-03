using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_assignment.Data;
using backend_assignment.Models;

namespace backend_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
    }
}
