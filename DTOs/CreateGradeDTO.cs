public class CreateGradeDto
{
    public required string StudentId { get; set; }
    public required string Subject { get; set; }
    public required string GradeName { get; set; }
    public required decimal GradeValue { get; set; }
    public required string Comment { get; set; }
}