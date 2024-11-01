using titova_yulia_kt_31_21.Interfaces.TestInterfaces;
using titova_yulia_kt_31_21.Models;
using Microsoft.AspNetCore.Mvc;


namespace titova_yulia_kt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestService _testService;

        public TestController(ILogger<TestController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet("GetTests")]
        public async Task<IActionResult> GetTestsAsync(CancellationToken cancellationToken = default)
        {
            var tests = await _testService.GetTestsdAsync(cancellationToken);
            return Ok(tests);
        }

        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTestAsync(int studentId, int subjectId, bool isPassed, CancellationToken cancellationToken = default)
        {
            try
            {
                await _testService.AddTestAsync(studentId, subjectId, isPassed, cancellationToken);
                return Ok("Запись добавлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось добавить новую запись: {ex.Message}");
            }
        }

        [HttpPut("EditTest/{testId}")]
        public async Task<IActionResult> EditTest(int testId, bool isPassed, CancellationToken cancellationToken = default)
        {
            try
            {
                await _testService.EditTestAsync(testId, isPassed, cancellationToken);
                return Ok("Запись изменена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось изменить запись: {ex.Message}");
            }
        }
    }
}