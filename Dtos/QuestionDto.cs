namespace backend_assignment.Dtos;

public class QuestionDto
{
  public int Id { get; set; }
  public string Content { get; set; } = null!;
  public int FirstAnswerId { get; set; }
  public string FirstAnswer { get; set; } = null!;
  public int SecondAnswerId { get; set; }
  public string SecondAnswer { get; set; } = null!;
  public int ThirdAnswerId { get; set; }
  public string ThirdAnswer { get; set; } = null!;
  public int FourthAnswerId { get; set; }
  public string FourthAnswer { get; set; } = null!;
}
