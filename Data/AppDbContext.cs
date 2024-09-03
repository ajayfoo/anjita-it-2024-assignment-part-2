using backend_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Response> Responses { get; set; } = default!;
    public DbSet<Exam> Exams { get; set; } = default!;
    public DbSet<Result> Results { get; set; } = default!;
}