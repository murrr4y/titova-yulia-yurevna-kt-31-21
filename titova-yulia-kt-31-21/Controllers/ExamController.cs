using titova_yulia_kt_31_21.Interfaces.ExamInterfaces;
using titova_yulia_kt_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace titova_yulia_kt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly ILogger<ExamController> _logger;
        private readonly IExamService _examService;

        public ExamController(ILogger<ExamController> logger, IExamService examService)
        {
            _logger = logger;
            _examService = examService;
        }

        [HttpGet("GetExams")]
        public async Task<IActionResult> GetExamsAsync(CancellationToken cancellationToken = default)
        {
            var exams = await _examService.GetExamsdAsync(cancellationToken);
            return Ok(exams);
        }

        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExamAsync(int studentId, int subjectId, int mark, CancellationToken cancellationToken = default)
        {
            try
            {
                await _examService.AddExamAsync(studentId, subjectId, mark, cancellationToken);
                return Ok("Запись добавлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось добавить новую запись: {ex.Message}");
            }
        }

        [HttpPut("EditExam/{examId}")]
        public async Task<IActionResult> EditExam(int examId, int mark, CancellationToken cancellationToken = default)
        {
            try
            {
                await _examService.EditExamAsync(examId, mark, cancellationToken);
                return Ok("Запись изменена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось изменить запись: {ex.Message}");
            }
        }
    }
}