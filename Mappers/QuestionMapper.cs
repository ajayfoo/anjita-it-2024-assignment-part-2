using backend_assignment.Dtos;
using backend_assignment.Models;

namespace backend_assignment.Mappers;

public static class QuestionMapper
{
  public static QuestionDto ToQuestionDto(this Question q)
  {
    return new()
    {
      Id = q.Id,
      Content = q.Content,
      FirstAnswerId = q.FirstAnswerId,
      SecondAnswerId = q.SecondAnswerId,
      ThirdAnswerId = q.ThirdAnswerId,
      FourthAnswerId = q.FourthAnswerId,
    };
  }
}
