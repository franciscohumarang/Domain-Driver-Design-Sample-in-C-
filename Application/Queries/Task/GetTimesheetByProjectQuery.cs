using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Task
{
    public class GetTimesheetByProjectQuery: IRequest<List<SummaryByProject>>
    {
        public int EmployeeId { get; set; }
        public int WeekNoYear { get; set; }

        public class GetTimesheetByProjectQueryHandler : IRequestHandler<GetTimesheetByProjectQuery, List<SummaryByProject>>
        {
            private readonly ITasksRepositoryAsync _tasksRepository;


            public GetTimesheetByProjectQueryHandler(ITasksRepositoryAsync productRepository)
            {
                _tasksRepository = productRepository;

            } 

            public async Task<List<SummaryByProject>> Handle(GetTimesheetByProjectQuery request, CancellationToken cancellationToken)
            {
              var summaryByProjects= await  _tasksRepository.GetEmployeeWeelyTimesheetAsync(request.EmployeeId, request.WeekNoYear);

                return summaryByProjects;
            }
        }
    }
}
