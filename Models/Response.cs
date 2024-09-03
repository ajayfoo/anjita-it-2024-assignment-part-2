namespace backend_assignment.Models;

public class Response
{
  public int Id { get; set; }
  public int StudentId { get; set; }
  public Student Student { get; set; } = null!;
  public int? Q1AnswerId { get; set; }
  public Answer? Q1Answer { get; set; }
  public int? Q2AnswerId { get; set; }
  public Answer? Q2Answer { get; set; }
  public int? Q3AnswerId { get; set; }
  public Answer? Q3Answer { get; set; }
  public int? Q4AnswerId { get; set; }
  public Answer? Q4Answer { get; set; }
  public int? Q5AnswerId { get; set; }
  public Answer? Q5Answer { get; set; }
}
