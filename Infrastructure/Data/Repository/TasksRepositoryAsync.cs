using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Infrastructure.Data.Repository
{
   public class TasksRepositoryAsync : BaseRepositoryAsync<TaskEntry>, ITasksRepositoryAsync
    {
 


        private readonly DbSet<TaskEntry> _taskEntries;
        private readonly DbSet<Project> _projects;
        private readonly DbSet<TaskType> _taskTypes;

        public TasksRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
           
             _taskEntries = dbContext.Set<TaskEntry>();

             _projects =  dbContext.Set<Project>();
             _taskTypes = dbContext.Set<TaskType>();
        }
 

        public async Task<List<WeeklyTask>> GetDailyTaskEntriesAsync(int employeeId)
        {
          

            var allEntries =  await  (from t in _taskEntries
                              join p in _projects on t.ProjectId equals p.ProjectId
                              join tp in _taskTypes on t.TaskTypeId equals tp.TaskTypeId
                              where t.EmployeeId == employeeId
                              select new
                              {  TaskId = t.TaskId,
                                  Name = t.Name,
                                  Project = p.Name,
                                  TaskType = tp.Name,
                                  StartTime = t.StartTime,
                                  EndTime = t.EndTime,
                                  LoggedDate = t.LoggedDate
                                 
                                  
                              }).ToListAsync();

                       var result = from e in allEntries
                                    group e by e.LoggedDate.GetWeekOfYear()
                                         into egroup
                                     orderby egroup.Key
                                     select egroup ;

            

                var weeklyTaskList = new List<WeeklyTask>();
                
                 foreach (var group in result )
                         {
                           var weeklyTask= new  WeeklyTask();
                     weeklyTask.LoggedDate = group.FirstOrDefault().LoggedDate; ;
                     weeklyTask.Week = group.Key;

                      var taskEntries = new List<DailyTask> ();
                        foreach (var _item in group )
                                {
                                var taskEntry = new DailyTask();

                    taskEntry.Name = _item.Name;
                    taskEntry.Project = _item.Project;
                    taskEntry.StartTime = _item.StartTime;
                    taskEntry.EndTime = _item.EndTime;
                
                    taskEntry.Durration = _item.EndTime.Subtract(_item.StartTime);
                    taskEntry.TaskType = _item.TaskType;
                    taskEntry.TaskId = _item.TaskId;
                    taskEntries.Add(taskEntry);
                 
                }
                weeklyTask.DailyTask = taskEntries;

                 var timeSum = (from r in taskEntries select r.Durration.Ticks).Sum();

                   weeklyTask.TotalWeekHrs = new TimeSpan(timeSum);
                     weeklyTaskList.Add(weeklyTask);
                 }

            return weeklyTaskList;

    }
        
        public async Task<List<SummaryByProject>> GetEmployeeWeelyTimesheetAsync(int employeeId, int week)
        {  

     

            var allEntries = await (from t in _taskEntries
                                    join p in _projects on t.ProjectId equals p.ProjectId
                                    join tp in _taskTypes on t.TaskTypeId equals tp.TaskTypeId
                                    where t.EmployeeId == employeeId
                                    select new
                                    {
                                        TaskId = t.TaskId,
                                        Name = t.Name,
                                        Project = p.Name,
                                        TaskType = tp.Name,
                                        StartTime = t.StartTime,
                                        EndTime = t.EndTime,
                                        LoggedDate = t.LoggedDate


                                    }).ToListAsync();


            var resultbyProjects = from e in allEntries
                         group e by e.Project
                                       into egroup
                         orderby egroup.Key
                         select egroup;

            var summaryByProjectList = new List<SummaryByProject>();

            foreach (var group2 in resultbyProjects)
            {
                var weeklyTask = new SummaryByProject();
                weeklyTask.Project = group2.Key;
              
               var resultByWeek = from e in group2
                              group e by e.LoggedDate.GetWeekOfYear()
                                into egroup
                              orderby egroup.Key
                              select egroup;

                var taskEntries = new List<DailyTask>();
                var weeklyTimeLogSummary = new List<WeeklyTimesheet>();

                weeklyTask.Week = resultByWeek.FirstOrDefault().Key;

                foreach (var _item in resultByWeek)
                {
                 
                    var weeklyTimesheet = new WeeklyTimesheet();
                    var dailyLogs = new List<DailyLog>();
                    foreach (var i in _item)
                    {
                        var dailyLog = new DailyLog();
                        dailyLog.LoggedDate = i.LoggedDate;
                        dailyLog.Duration = i.EndTime.Subtract(i.StartTime);
                        dailyLogs.Add(dailyLog);
                    }
                    weeklyTimesheet.DailyLogs = dailyLogs;
                    weeklyTimesheet.TotalWeeklogLogs = dailyLogs.Aggregate(new TimeSpan(), (sum, nextData) => sum.Add(nextData.Duration));

                    weeklyTimeLogSummary.Add(weeklyTimesheet);
                }
                weeklyTask.WeeklyTimeLogSummary = weeklyTimeLogSummary;
                summaryByProjectList.Add(weeklyTask);

            }


               return summaryByProjectList.Where(w => w.Week == week).ToList(); ;


            }
}
}
