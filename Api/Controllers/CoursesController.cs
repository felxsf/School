using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Courses;

namespace School.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _service;
    public CoursesController(ICourseService service) => _service = service;

    // GET: api/courses?code=&name=&professorId=&page=1&pageSize=10
    [HttpGet]
    public async Task<ActionResult<object>> Get([FromQuery] string? code, [FromQuery] string? name,
        [FromQuery] int? professorId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (items, total) = await _service.GetPagedAsync(page < 1 ? 1 : page, pageSize < 1 ? 10 : pageSize, code, name, professorId);
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return Ok(new { page, pageSize, total, totalPages, items });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseReadDto>> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CourseCreateDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CourseUpdateDto dto)
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
