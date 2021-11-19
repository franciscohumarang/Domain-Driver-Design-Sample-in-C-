using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using MediatR;
using Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;


using Newtonsoft.Json;
using AspnetRun.Application.Exceptions;


namespace Application.Tasks.Commands
{
    public partial class AddTaskCommand : IRequest<int>
    {
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public int ProjectId { get; set; }
        [JsonRequired]
        public int TaskTypeId { get; set; }
        [JsonRequired]
        public int ClientId { get; set; }
        [JsonRequired]
        public DateTime StartTime { get; set; }
        [JsonRequired]
        public DateTime EndTime { get; set; }
        public bool IsBillable { get; set; }
        [JsonRequired]
        public int EmployeeId { get; set; }
        [JsonRequired]
        public DateTime LoggedDate { get; set; }


        public class AddTaskEntryCommanddHandler : IRequestHandler<AddTaskCommand, int>
        {
           private readonly ITasksRepositoryAsync _tasksRepository; 


            public AddTaskEntryCommanddHandler(ITasksRepositoryAsync tasksRepository)
            {
                _tasksRepository =  tasksRepository;

            }


            public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
            {
                
              
                    var taskEntry = new TaskEntry();

                    taskEntry.Name = request.Name;
                    taskEntry.LoggedDate = request.LoggedDate;
                    taskEntry.EmployeeId = request.EmployeeId;
                    taskEntry.EndTime = request.EndTime;
                    taskEntry.StartTime = request.StartTime;
                    taskEntry.ProjectId = request.ProjectId;
                    taskEntry.TaskTypeId = request.TaskTypeId;
                    taskEntry.IsBillable = request.IsBillable;
                    taskEntry.ClientId = request.ClientId;

                    await _tasksRepository.AddAsync(taskEntry);
                    return taskEntry.TaskId;
             
            }
        }

    }

    }