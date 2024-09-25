using GradesService.Data;
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
                    new Grades { SubjectName = "progra", GradeName = "catedra 1", Grade = 44, Comment = "maoma"},
                    new Grades { SubjectName = "progra", GradeName = "catedra 2", Grade = 33, Comment = "malo"},
                    new Grades { SubjectName = "progra", GradeName = "catedra 3", Grade = 70, Comment = "excelente"}
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