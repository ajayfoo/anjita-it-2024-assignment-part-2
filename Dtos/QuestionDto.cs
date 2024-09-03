namespace backend_assignment.Dtos;

public class QuestionDto
{
  public int Id { get; set; }
  public string Content { get; set; } = null!;
  public int FirstAnswerId { get; set; }
  public int SecondAnswerId { get; set; }
  public int ThirdAnswerId { get; set; }
  public int FourthAnswerId { get; set; }
}
