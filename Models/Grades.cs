namespace GradesService.Models{
    public class Grades
    {
        public Grades()
        {
            Id = Guid.NewGuid().ToString(); 
        }

    public string Id { get; set; }
    public string StudentId { get; set; } = string.Empty;
    public string subjectName { get; set; } = string.Empty;
    public string gradeName { get; set; } = string.Empty;
    public int grade { get; set; }
    public string comment { get; set; } = string.Empty;

    }
}
