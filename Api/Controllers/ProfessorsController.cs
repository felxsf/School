using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Professors;

namespace School.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfessorsController : ControllerBase
{
    private readonly IProfessorService _service;
    public ProfessorsController(IProfessorService service) => _service = service;

    // GET: api/professors?document=&name=&email=&page=1&pageSize=10
    [HttpGet]
    public async Task<ActionResult<object>> Get([FromQuery] string? document, [FromQuery] string? name,
        [FromQuery] string? email, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (items, total) = await _service.GetPagedAsync(page < 1 ? 1 : page, pageSize < 1 ? 10 : pageSize, document, name, email);
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return Ok(new { page, pageSize, total, totalPages, items });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProfessorReadDto>> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProfessorCreateDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProfessorUpdateDto dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
