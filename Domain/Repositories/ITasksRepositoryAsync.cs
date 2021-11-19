using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Base;
namespace Domain.Repositories
{
    public interface ITasksRepositoryAsync : IBaseRepositoryAsync<TaskEntry>
    {
        Task<List<WeeklyTask>> GetDailyTaskEntriesAsync(int employeeId);
        Task<List<SummaryByProject>> GetEmployeeWeelyTimesheetAsync(int employeeId, int week); 

    }
}
