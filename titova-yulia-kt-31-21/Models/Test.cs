using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace titova_yulia_kt_31_21.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public bool IsPassed { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
