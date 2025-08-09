using Application.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Students;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service) => _service = service;

        // GET: api/students?identification=&firstName=&lastName=&birthDateFrom=&birthDateTo=&page=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<object>> GetPaged(
            [FromQuery] string? identification,
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] DateTime? birthDateFrom,
            [FromQuery] DateTime? birthDateTo,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var (items, total) = await _service.GetPagedAsync(page, pageSize, identification, firstName, lastName, birthDateFrom, birthDateTo);
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            return Ok(new { page, pageSize, total, totalPages, items });
        }

        // GET: api/students/identification/STU000001
        [HttpGet("identification/{idNumber}")]
        public async Task<ActionResult<StudentReadDto>> GetByIdentification(string idNumber)
        {
            var dto = await _service.GetByIdentificationAsync(idNumber);
            return dto is null ? NotFound() : Ok(dto);
        }

        // GET: api/students/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentReadDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto is null ? NotFound() : Ok(dto);
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentCreateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        // PUT: api/students/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentUpdateDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        // DELETE: api/students/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
