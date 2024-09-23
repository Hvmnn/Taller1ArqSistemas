using GradesService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly MariaDbContext _context;

        public GradesController(MariaDbContext context)
        {
            _context = context;
            initializeDB();
        }

        private void initializeDB()
        {
            _context.Database.EnsureCreated();

            if(!_context.Grades.Any())
            {
                _context.Grades.AddRange(
                    new Grades { subjectName = "progra", gradeName = "catedra 1", grade = 44, comment = "maoma"},
                    new Grades { subjectName = "progra", gradeName = "catedra 2", grade = 33, comment = "malo"},
                    new Grades { subjectName = "progra", gradeName = "catedra 3", grade = 70, comment = "excelente"}
                );

                _context.SaveChanges();
            }
        }

        [HttpGet("Grades")]
        public IActionResult Get()
        {
            var data = _context.Grades.ToList();
            return Ok(new {data});
        }
    }
}