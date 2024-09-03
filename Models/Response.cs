namespace backend_assignment.Models;
public class Response
{
    public int Id { get; set; }
    public Student Student { get; set; } = null!;
    public Answer? Q1Answer { get; set; }
    public Answer? Q2Answer { get; set; }
    public Answer? Q3Answer { get; set; }
    public Answer? Q4Answer { get; set; }
    public Answer? Q5Answer { get; set; }
}