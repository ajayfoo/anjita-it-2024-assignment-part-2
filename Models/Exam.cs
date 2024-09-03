namespace backend_assignment.Models;

public class Exam
{
    public int Id { get; set; }
    public QuestionPaper? QuestionPaper { get; set; }
    public Response[] Responses { get; set; } = [];
}