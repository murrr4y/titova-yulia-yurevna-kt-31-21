using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace titova_yulia_kt_31_21.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
