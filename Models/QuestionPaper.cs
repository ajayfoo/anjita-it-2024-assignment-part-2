namespace backend_assignment.Models;
public class QuestionPaper
{
    public int Id { get; set; }
    public Question Q1 { get; set; } = null!;
    public Question Q2 { get; set; } = null!;
    public Question Q3 { get; set; } = null!;
    public Question Q4 { get; set; } = null!;
    public Question Q5 { get; set; } = null!;
}