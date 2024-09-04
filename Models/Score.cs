using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Models;

public class Score
{
  public int Id { get; set; }
  public int StudentSessionId { get; set; }
  public StudentSession StudentSession { get; set; } = null!;
  public int Obtained { get; set; }
  public int Max { get; set; }
}
