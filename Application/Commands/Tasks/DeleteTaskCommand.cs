 
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace Application.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public int TaskId { get; set; }
        public class DeleteByTaskIdCommandHandler : IRequestHandler<DeleteTaskCommand,Unit>
        {
            private readonly ITasksRepositoryAsync _taskRepository;
            public DeleteByTaskIdCommandHandler(ITasksRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Unit> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
            {

                var task = await _taskRepository.GetByIdAsync(command.TaskId);
                if (task == null)
                    throw new ApplicationException("Task Id not found");

                await _taskRepository.DeleteAsync(task);


                return Unit.Value;
            }
        }
    }
}
