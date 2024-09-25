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

        [HttpPost]
        public async Task<ActionResult<GradesDto>> PostGrade(CreateGradeDto createGradeDto)
        {
            var grade = new Grades
            {
                StudentId = createGradeDto.StudentId,
                SubjectName = createGradeDto.Subject,
                GradeName = createGradeDto.GradeName,
                Grade = createGradeDto.GradeValue,
                Comment = createGradeDto.Comment
            };

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            var gradeDto = new GradesDto
            {
                Id = grade.Id,
                StudentId = grade.StudentId,
                Subject = grade.SubjectName,
                GradeName = grade.GradeName,
                GradeValue = grade.Grade,
                Comment = grade.Comment
            };

            return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, gradeDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradesDto>> GetGrade(string id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            var gradeDto = new GradesDto
            {
                Id = grade.Id,
                StudentId = grade.StudentId,
                Subject = grade.SubjectName,
                GradeName = grade.GradeName,
                GradeValue = grade.Grade,
                Comment = grade.Comment
            };

            return gradeDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(string id, CreateGradeDto gradeDto)
        {
            var grade = await _context.Grades.FindAsync(id);
            
            if (grade == null)
            {
                return NotFound();  
            }

            grade.StudentId = gradeDto.StudentId;
            grade.SubjectName = gradeDto.Subject;
            grade.GradeName = gradeDto.GradeName;
            grade.Grade = gradeDto.GradeValue;
            grade.Comment = gradeDto.Comment;

            
            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();  
        }

        private bool GradeExists(string id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }

    }
}