using titova_yulia_kt_31_21.Interfaces.GroupInterfaces;
using titova_yulia_kt_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace titova_yulia_kt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;

        public GroupController(ILogger<GroupController> logger, IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpGet("GetGroups")]
        public async Task<IActionResult> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            var groups = await _groupService.GetGroupAsync(cancellationToken);
            return Ok(groups);
        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroupAsync(string groupName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.AddGroupAsync(groupName, cancellationToken);
                return Ok("Запись добавлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось добавить новую запись: {ex.Message}");
            }
        }

        [HttpPut("EditGroup/{groupId}")]
        public async Task<IActionResult> EditGroup(int groupId, string groupName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.EditGroupAsync(groupId, groupName, cancellationToken);
                return Ok("Запись изменена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось изменить запись: {ex.Message}");
            }
        }

        [HttpDelete("DeleteGroup/{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.DeleteGroupAsync(groupId, cancellationToken);
                return Ok("Запись удалена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Не удалось удалить запись: {ex.Message}");
            }
        }
    }
}