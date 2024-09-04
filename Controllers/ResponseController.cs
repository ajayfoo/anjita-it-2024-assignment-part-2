using System.Drawing.Printing;
using backend_assignment.Data;
using backend_assignment.Dtos;
using backend_assignment.Mappers;
using backend_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponseController(AppDbContext context) : ControllerBase
{
  private readonly AppDbContext _context = context;

  private async Task<Question> GetQuestionNo(int num, int examId)
  {
    Exam exam = await _context.Exams.Include(e => e.QuestionPaper).FirstAsync(e => e.Id == examId);
    QuestionPaper qp = await _context
      .QuestionPapers.Include(qp => qp.Q1)
      .ThenInclude(q => q.FirstAnswer)
      .Include(qp => qp.Q1)
      .ThenInclude(q => q.SecondAnswer)
      .Include(qp => qp.Q1)
      .ThenInclude(q => q.ThirdAnswer)
      .Include(qp => qp.Q1)
      .ThenInclude(q => q.FourthAnswer)
      .Include(qp => qp.Q2)
      .ThenInclude(q => q.FirstAnswer)
      .Include(qp => qp.Q2)
      .ThenInclude(q => q.SecondAnswer)
      .Include(qp => qp.Q2)
      .ThenInclude(q => q.ThirdAnswer)
      .Include(qp => qp.Q2)
      .ThenInclude(q => q.FourthAnswer)
      .Include(qp => qp.Q2)
      .ThenInclude(q => q.FirstAnswer)
      .Include(qp => qp.Q3)
      .ThenInclude(q => q.SecondAnswer)
      .Include(qp => qp.Q3)
      .ThenInclude(q => q.ThirdAnswer)
      .Include(qp => qp.Q3)
      .ThenInclude(q => q.FourthAnswer)
      .Include(qp => qp.Q4)
      .ThenInclude(q => q.FirstAnswer)
      .Include(qp => qp.Q4)
      .ThenInclude(q => q.SecondAnswer)
      .Include(qp => qp.Q4)
      .ThenInclude(q => q.ThirdAnswer)
      .Include(qp => qp.Q4)
      .ThenInclude(q => q.FourthAnswer)
      .FirstAsync(q => q.Id == exam.QuestionPaperId);
    if (num == 1)
    {
      return qp.Q1;
    }
    else if (num == 2)
    {
      return qp.Q2;
    }
    else if (num == 3)
    {
      return qp.Q3;
    }
    else if (num == 4)
    {
      return qp.Q4;
    }
    else
    {
      return qp.Q5;
    }
  }

  private async Task<Question?> UpdateResponseAndGetNextQuestion(int answerId)
  {
    int studentSessionId = int.Parse(Request.Cookies["studentSessionId"] ?? "");
    StudentSession? studentSession = await _context.StudentSessions.FindAsync(studentSessionId);
    if (studentSession == null)
      return null;
    Response? currentResponse = await _context.Responses.FirstAsync(r =>
      r.Id == studentSession.ResponseId
    );
    if (currentResponse == null)
      return null;
    if (currentResponse.Q1AnswerId == null)
    {
      currentResponse.Q1AnswerId = answerId;
      await _context.SaveChangesAsync();
      return await GetQuestionNo(2, currentResponse.ExamId);
    }
    else if (currentResponse.Q2AnswerId == null)
    {
      currentResponse.Q2AnswerId = answerId;
      await _context.SaveChangesAsync();
      return await GetQuestionNo(3, currentResponse.ExamId);
    }
    else if (currentResponse.Q3AnswerId == null)
    {
      currentResponse.Q3AnswerId = answerId;
      await _context.SaveChangesAsync();
      return await GetQuestionNo(4, currentResponse.ExamId);
    }
    else if (currentResponse.Q4AnswerId == null)
    {
      currentResponse.Q4AnswerId = answerId;
      await _context.SaveChangesAsync();
      return await GetQuestionNo(5, currentResponse.ExamId);
    }
    else
      currentResponse.Q5AnswerId ??= answerId;
    await _context.SaveChangesAsync();
    return null;
  }

  [HttpPut("{answerId}")]
  public async Task<ActionResult<QuestionDto>> PutResponse(int answerId)
  {
    Console.WriteLine("$$$$$$$$$$$$ Other Current Question is null $$$$$$$$$$");
    Question? nextQuestion = await UpdateResponseAndGetNextQuestion(answerId);
    if (nextQuestion == null)
    {
      Console.WriteLine("Current Question is null");
      return StatusCode(500);
    }
    return nextQuestion.ToQuestionDto();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Response>> GetResponse(int id)
  {
    var response = await _context.Responses.FindAsync(id);

    if (response == null)
    {
      return NotFound();
    }

    return response;
  }
}
