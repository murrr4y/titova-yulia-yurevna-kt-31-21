namespace titova_yulia_kt_31_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }  
        public int GroupId { get; set; }
        public int ExamId { get; set; }
        public int TestId {  get; set; }

        public Group Group { get; set; }
        public Exam Exam { get; set; }
        public Test Test { get; set; }
    }
}
