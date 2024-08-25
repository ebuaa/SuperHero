using Microsoft.AspNetCore.Mvc;
using hero_csharp.Models;
using hero_csharp.Services.SchoolService;

namespace hero_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return Ok(await _schoolService.GetSchoolListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<School> GetSchool(int id)
        {
            var school = _schoolService.GetSchool(id);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }

        [HttpPost]
        public ActionResult<School> PostSchool(School school)
        {
            _schoolService.AddSchool(school);
            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        [HttpPut("{id}")]
        public IActionResult PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _schoolService.UpdateSchool(id, school);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(int id)
        {
            _schoolService.DeleteSchool(id);
            return NoContent();
        }
    }
}