using backend_assignment.Dtos;
using backend_assignment.Models;

namespace backend_assignment.Mappers;

public static class ResponseMapper
{
  public static ResponseDto ToResponseDto(this Response r)
  {
    return new()
    {
      Id = r.Id,
      StudentId = r.StudentId,
      ExamId = r.ExamId,
      Q1AnswerId = r.Q1AnswerId,
      Q2AnswerId = r.Q2AnswerId,
      Q3AnswerId = r.Q3AnswerId,
      Q4AnswerId = r.Q4AnswerId,
      Q5AnswerId = r.Q5AnswerId,
    };
  }

  public static Response ToResponse(this ResponseDto dto)
  {
    Response response =
      new()
      {
        StudentId = dto.StudentId,
        ExamId = dto.ExamId,
        Q1AnswerId = dto.Q1AnswerId,
        Q2AnswerId = dto.Q2AnswerId,
        Q3AnswerId = dto.Q3AnswerId,
        Q4AnswerId = dto.Q4AnswerId,
        Q5AnswerId = dto.Q5AnswerId,
      };
    if (dto.Id != null)
    {
      response.Id = (int)dto.Id;
    }
    return response;
  }
}
