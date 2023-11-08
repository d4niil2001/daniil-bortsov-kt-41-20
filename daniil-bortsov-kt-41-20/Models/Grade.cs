namespace daniil_bortsov_kt_41_20.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int Mark { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}
