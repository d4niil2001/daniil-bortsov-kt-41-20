namespace daniil_bortsov_kt_41_20.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentMidname { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
