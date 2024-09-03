namespace backend_assignment.Models;

public class Question
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;

    public int FirstAnswerId { get; set; }
    public Answer FirstAnswer { get; set; } = null!;

    public int SecondAnswerId { get; set; }
    public Answer SecondAnswer { get; set; } = null!;

    public int ThirdAnswerId { get; set; }
    public Answer ThirdAnswer { get; set; } = null!;

    public int FourthAnswerId { get; set; }
    public Answer FourthAnswer { get; set; } = null!;

    public int CorrectAnswerId { get; set; }
    public Answer CorrectAnswer { get; set; } = null!;
}