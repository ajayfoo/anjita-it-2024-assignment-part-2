namespace backend_assignment.Models;

public class Question
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public Answer FirstAnswer { get; set; } = null!;
    public Answer SecondAnswer { get; set; } = null!;
    public Answer ThirdAnswer { get; set; } = null!;
    public Answer FourthAnswer { get; set; } = null!;
    public Answer CorrectAnswer { get; set; } = null!;
}