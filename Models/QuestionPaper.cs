namespace backend_assignment.Models;
public class QuestionPaper
{
    public int Id { get; set; }
    public Question? Q1 { get; set; }
    public Question? Q2 { get; set; }
    public Question? Q3 { get; set; }
    public Question? Q4 { get; set; }
    public Question? Q5 { get; set; }
}