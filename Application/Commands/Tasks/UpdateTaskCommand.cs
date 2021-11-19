
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
 
using Domain.Entities;

namespace Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
      
        public int TaskId { get; set; }

      
        public string Name { get; set; }
      
        public int ProjectId { get; set; }
       
        public int TaskTypeId { get; set; }
 
        public int ClientId { get; set; }
   

        public DateTime StartTime { get; set; }
     

        public DateTime EndTime { get; set; }
        public bool IsBillable { get; set; }
   

        public int EmployeeId { get; set; }
    

        public DateTime LoggedDate { get; set; }

        public class UpdateByTaskIdCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
        {
            private readonly ITasksRepositoryAsync _taskRepository;
            public UpdateByTaskIdCommandHandler(ITasksRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {

                var taskEntry = await _taskRepository.GetByIdAsync(request.TaskId);
               
                if (taskEntry == null)
                    throw new ApplicationException("Task Id to Update not found");

      


                taskEntry.Name = request.Name;
                taskEntry.LoggedDate = request.LoggedDate;
                taskEntry.EmployeeId = request.EmployeeId;
                taskEntry.EndTime = request.EndTime;
                taskEntry.StartTime = request.StartTime;
                taskEntry.ProjectId = request.ProjectId;
                taskEntry.TaskTypeId = request.TaskTypeId;
                taskEntry.IsBillable = request.IsBillable;
                taskEntry.ClientId = request.ClientId;

                await _taskRepository.UpdateAsync(taskEntry);


                return Unit.Value;
            }
        }
    }

}