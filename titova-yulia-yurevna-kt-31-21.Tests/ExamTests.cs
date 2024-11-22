using titova_yulia_kt_31_21.Models;

namespace titova_yulia_yurevna_kt_31_21.Tests
{
    public class ExamTests
    {
        [Fact]
        public void IsValidMark_4_True()
        {
            var testExam = new Exam
            {
                Mark = 4,
                StudentId = 1,
                SubjectId = 1,
            };

            var result = testExam.IsValidMark();

            Assert.True(result);
        }
    }
}
