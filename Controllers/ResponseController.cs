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

  private async Task<Question?> UpdateResponseAndGetNextQuestion(
    int answerId,
    Response currentResponse
  )
  {
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
    return await GetQuestionNo(5, currentResponse.ExamId);
  }

  private static bool AnsweredAllQuestions(Response response)
  {
    if (response.Q1AnswerId == null)
      return false;
    if (response.Q2AnswerId == null)
      return false;
    if (response.Q3AnswerId == null)
      return false;
    if (response.Q4AnswerId == null)
      return false;
    if (response.Q5AnswerId == null)
      return false;
    return true;
  }

  [HttpPut("{answerId}")]
  public async Task<ActionResult<QuestionDto>> PutResponse(int answerId)
  {
    int studentSessionId = int.Parse(Request.Cookies["studentSessionId"] ?? "");

    StudentSession? studentSession = await _context.StudentSessions.FindAsync(studentSessionId);
    if (studentSession == null)
      return NotFound();

    Response? currentResponse = await _context.Responses.FirstAsync(r =>
      r.Id == studentSession.ResponseId
    );
    if (currentResponse == null)
      return NotFound();

    Question? nextQuestion = await UpdateResponseAndGetNextQuestion(answerId, currentResponse);
    if (nextQuestion == null)
    {
      Console.WriteLine("Current Question is null");
      return StatusCode(500);
    }
    if (AnsweredAllQuestions(currentResponse))
    {
      Score? score = await SubmitResponseAndGetScore(currentResponse);
      if (score == null)
      {
        return StatusCode(500);
      }
      score.StudentSessionId = studentSessionId;
      bool exists = await _context.Scores.AnyAsync(s => s.StudentSessionId == studentSessionId);
      if (!exists)
      {
        _context.Scores.Add(score);
        await _context.SaveChangesAsync();
      }
      Response.Headers.Location = "/Result";
      return StatusCode(303);
    }
    return nextQuestion.ToQuestionDto();
  }

  private static Score GetScoreFrom(Response response, QuestionPaper paper)
  {
    int score = 0;
    if (response.Q1AnswerId == paper.Q1.CorrectAnswerId)
    {
      ++score;
    }
    if (response.Q2AnswerId == paper.Q2.CorrectAnswerId)
    {
      ++score;
    }
    if (response.Q3AnswerId == paper.Q3.CorrectAnswerId)
    {
      ++score;
    }
    if (response.Q4AnswerId == paper.Q4.CorrectAnswerId)
    {
      ++score;
    }
    if (response.Q5AnswerId == paper.Q5.CorrectAnswerId)
    {
      ++score;
    }
    int max = 5;
    return new() { Obtained = score, Max = max };
  }

  private async Task<Score?> SubmitResponseAndGetScore(Response response)
  {
    var latestExam = await _context
      .Exams.Include(e => e.QuestionPaper)
      .ThenInclude(e => e.Q1)
      .Include(e => e.QuestionPaper)
      .ThenInclude(e => e.Q2)
      .Include(e => e.QuestionPaper)
      .ThenInclude(e => e.Q3)
      .Include(e => e.QuestionPaper)
      .ThenInclude(e => e.Q4)
      .Include(e => e.QuestionPaper)
      .ThenInclude(e => e.Q5)
      .Include(e => e.Responses)
      .OrderBy(e => e.Id)
      .LastAsync();
    if (latestExam == null)
    {
      return null;
    }
    return GetScoreFrom(response, latestExam.QuestionPaper);
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
