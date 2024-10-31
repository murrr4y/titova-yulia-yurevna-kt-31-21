using titova_yulia_kt_31_21.Interfaces.StudentInterfaces;
using titova_yulia_kt_31_21.Interfaces.SubjectInterfaces;
using titova_yulia_kt_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace titova_yulia_kt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetOtherInfoController : ControllerBase
    {
        private readonly ILogger<GetOtherInfoController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public GetOtherInfoController(ILogger<GetOtherInfoController> logger, IStudentService studentService, ISubjectService subjectService)
        {
            _logger = logger;
            _studentService = studentService;
            _subjectService = subjectService;
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsdAsync(cancellationToken);
            return Ok(students);
        }

        [HttpGet("GetSubjects")]
        public async Task<IActionResult> GetSubjectsAsync(CancellationToken cancellationToken = default)
        {
            var subjects = await _subjectService.GetSubjectsAsync(cancellationToken);
            return Ok(subjects);
        }
    }
}