using backend_assignment.Dtos;
using backend_assignment.Models;

namespace backend_assignment.Mappers;

public static class ExamMapper
{
  public static ExamDto ToExamDto(this Exam e)
  {
    return new()
    {
      Q1Id = e.QuestionPaper.Q1Id,
      Q2Id = e.QuestionPaper.Q2Id,
      Q3Id = e.QuestionPaper.Q3Id,
      Q4Id = e.QuestionPaper.Q4Id,
      Q5Id = e.QuestionPaper.Q5Id,
    };
  }
}
