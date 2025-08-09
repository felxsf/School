using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Grades;

namespace School.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GradesController : ControllerBase
{
    private readonly IGradeService _service;
    public GradesController(IGradeService service) => _service = service;

    // GET: api/grades?studentId=&courseId=&type=&min=&max=&page=1&pageSize=10
    [HttpGet]
    public async Task<ActionResult<object>> Get([FromQuery] int? studentId, [FromQuery] int? courseId,
        [FromQuery] string? type, [FromQuery] decimal? min, [FromQuery] decimal? max,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (items, total) = await _service.GetPagedAsync(page < 1 ? 1 : page, pageSize < 1 ? 10 : pageSize,
            studentId, courseId, type, min, max);

        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return Ok(new { page, pageSize, total, totalPages, items });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GradeReadDto>> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GradeCreateDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] GradeUpdateDto dto)
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
