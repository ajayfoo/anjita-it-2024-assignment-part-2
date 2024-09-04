using backend_assignment.Data;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Pages;

public class ResultPageModel(AppDbContext context) : PageModel
{
  private readonly AppDbContext _context = context;

  public IList<Question> Questions { get; set; } = default!;

  public async Task OnGetAsync()
  {
    if (_context.Questions != null)
    {
      Questions = await _context.Questions.ToListAsync();
    }
  }
}
