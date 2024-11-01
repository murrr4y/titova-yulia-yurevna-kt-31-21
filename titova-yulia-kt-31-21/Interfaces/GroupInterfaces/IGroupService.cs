using titova_yulia_kt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Models;
using System.Text.RegularExpressions;
using Group = titova_yulia_kt_31_21.Models.Group;

namespace titova_yulia_kt_31_21.Interfaces.GroupInterfaces
{
    public interface IGroupService
    {
        public Task<Group[]> GetGroupAsync(CancellationToken cancellationToken);
        public Task AddGroupAsync(string  groupName, CancellationToken cancellationToken);
        public Task EditGroupAsync(int groupId, string groupName, CancellationToken cancellationToken);
        public Task DeleteGroupAsync(int groupId, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        private readonly StudentPerfomanceDbContext _dbContext;
        public GroupService(StudentPerfomanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Group[]> GetGroupAsync(CancellationToken cancellationToken = default)
        {
            var groups = _dbContext.Set<Group>().ToArrayAsync(cancellationToken);

            return groups;
        }
        public async Task AddGroupAsync(string groupName, CancellationToken cancellationToken = default)
        {
            if (groupName != null || groupName != "")
            {
                var newGroup = new Group
                {
                    GroupName = groupName,
                };

                _dbContext.Groups.Add(newGroup);
                await _dbContext.SaveChangesAsync();
            } else
            {
                throw new Exception("Невозможно создать запись с пустым значением.");
            }
            
        }
        public async Task EditGroupAsync(int groupId, string groupName, CancellationToken cancellationToken = default)
        {
            var group = await _dbContext.Set<Group>().FindAsync(groupId);
            if (group != null)
            {
                group.GroupName = groupName;

                await _dbContext.SaveChangesAsync();
            } else
            {
                throw new Exception($"Запись с id {groupId} не найдена.");
            }
        }
        public async Task DeleteGroupAsync(int groupId, CancellationToken cancellationToken = default)
        {
            var group = await _dbContext.Set<Group>().FindAsync(groupId);
            if (group != null)
            {
                _dbContext.Groups.Remove(group);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Запись с id {groupId} не найдена.");
            }
        }
    }
}