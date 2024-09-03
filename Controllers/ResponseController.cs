using Microsoft.AspNetCore.Mvc;
using backend_assignment.Data;
using backend_assignment.Models;

namespace backend_assignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResponseController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpPost]
    public async Task<ActionResult<Response>> PostResponse(Response response)
    {
        _context.Responses.Add(response);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetResponse", new { id = response.Id }, response);
    }
}
