namespace backend_assignment.Models;

public class Result
{
    public int Id { get; set; }
    public Exam Exam { get; set; } = null!;
    public Student Student { get; set; } = null!;
    public int Score { get; set; }
    public int MaxScore { get; set; }
}