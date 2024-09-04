using backend_assignment.Data;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Pages;

public class ResultPageModel(AppDbContext context) : PageModel
{
  private readonly AppDbContext _context = context;

  public Score Score { get; set; } = default!;

  public async Task OnGetAsync()
  {
    int studentSessionId = int.Parse(Request.Cookies["studentSessionId"] ?? "");

    if (_context.Questions != null)
    {
      Score = await _context.Scores.FirstAsync(s => s.StudentSessionId == studentSessionId);
    }
  }
}
