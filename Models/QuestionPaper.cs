namespace backend_assignment.Models;
public class QuestionPaper
{
    public int Id { get; set; }

    public int Q1Id { get; set; }
    public Question Q1 { get; set; } = null!;

    public int Q2Id { get; set; }
    public Question Q2 { get; set; } = null!;

    public int Q3Id { get; set; }
    public Question Q3 { get; set; } = null!;

    public int Q4Id { get; set; }
    public Question Q4 { get; set; } = null!;

    public int Q5Id { get; set; }
    public Question Q5 { get; set; } = null!;
}