using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Task.Queries
{
    public class GetWeeklyTasksQuery : IRequest<List<WeeklyTask>>
    {
        public int EmployeeId { get; set; }
        public class GetWeeklyTasksQueryHandler : IRequestHandler<GetWeeklyTasksQuery, List<WeeklyTask>>
        {
            private readonly ITasksRepositoryAsync _tasksRepository;


            public GetWeeklyTasksQueryHandler(ITasksRepositoryAsync productRepository)
            {
                _tasksRepository = productRepository;

            }

            public async  Task<List<WeeklyTask>> Handle(GetWeeklyTasksQuery request, CancellationToken cancellationToken)
            {
                var tasks = await _tasksRepository.GetDailyTaskEntriesAsync(request.EmployeeId);

                return tasks.OrderByDescending(o => o.Week).ToList();
            }
        }
    }
}
