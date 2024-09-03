namespace backend_assignment.Models;

public class Question
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public Answer? FirstAnswer { get; set; }
    public Answer? SecondAnswer { get; set; }
    public Answer? ThirdAnswer { get; set; }
    public Answer? FourthAnswer { get; set; }
    public Answer? CorrectAnswer { get; set; }
}