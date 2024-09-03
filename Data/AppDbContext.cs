using backend_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Response> Responses { get; set; } = null!;
    public DbSet<Exam> Exams { get; set; } = null!;
    public DbSet<Result> Results { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Answer> initialAnswers = [
                new(){Id=1,Content="Mumbai"},
                new(){Id=2,Content="Delhi"},
                new(){Id=3,Content="Chennai"},
                new(){Id=4,Content="Banglore"},
        ];
        modelBuilder.Entity<Answer>().HasData(initialAnswers);
        Question initialQuestion = new()
        {
            Id = 1,
            Content = "What is the capital of India?",
            FirstAnswerId = initialAnswers[0].Id,
            SecondAnswerId = initialAnswers[1].Id,
            ThirdAnswerId = initialAnswers[2].Id,
            FourthAnswerId = initialAnswers[3].Id,
            CorrectAnswerId = initialAnswers[0].Id
        };
        modelBuilder.Entity<Question>().HasData([initialQuestion]);
        QuestionPaper initialQuestionPaper = new()
        {
            Id = 1,
            Q1Id = initialQuestion.Id,
            Q2Id = initialQuestion.Id,
            Q3Id = initialQuestion.Id,
            Q4Id = initialQuestion.Id,
            Q5Id = initialQuestion.Id,
        };
        modelBuilder.Entity<QuestionPaper>().HasData([initialQuestionPaper]);
        Exam exam = new()
        {
            Id = 1,
            QuestionPaperId = initialQuestionPaper.Id,
            Responses = []
        };
        modelBuilder.Entity<Exam>().HasData(exam);
    }
}