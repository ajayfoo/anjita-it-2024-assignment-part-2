using backend_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_assignment.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
}