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
      FirstAnswer = q.FirstAnswer.Content,
      SecondAnswerId = q.SecondAnswerId,
      SecondAnswer = q.SecondAnswer.Content,
      ThirdAnswerId = q.ThirdAnswerId,
      ThirdAnswer = q.ThirdAnswer.Content,
      FourthAnswerId = q.FourthAnswerId,
      FourthAnswer = q.FourthAnswer.Content,
    };
  }
}
