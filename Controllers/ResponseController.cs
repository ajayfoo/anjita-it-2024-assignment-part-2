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

  [HttpPut]
  public async Task<ActionResult<Response>> PutResponse(ResponseDto responseDto)
  {
    Console.WriteLine(Response.Cookies);
    Response response = responseDto.ToResponse();
    _context.Entry(response).State = response.Id == 0 ? EntityState.Added : EntityState.Modified;
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetResponse", new { id = response.Id }, response);
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
