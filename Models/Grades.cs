namespace GradesService.Models{
    public class Grades
    {
        public Grades()
        {
            Id = Guid.NewGuid().ToString(); 
        }

    public string Id { get; set; }
    public string StudentId { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public string GradeName { get; set; } = string.Empty;
    public decimal Grade { get; set; }
    public string Comment { get; set; } = string.Empty;

    }
}
