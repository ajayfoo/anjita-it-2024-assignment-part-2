using backend_assignment.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("Main");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapGet(
  "/question",
  (HttpContext context) =>
  {
    return Results.File("pages/question.html", "text/html");
  }
);

app.MapGet(
  "/",
  () =>
  {
    return Results.File("pages/index.html", "text/html");
  }
);
app.MapPost(
  "/",
  (HttpContext context) =>
  {
    Console.WriteLine(context.Request.Form["email"]);
    context.Response.Redirect("/question");
  }
);
app.Run();
