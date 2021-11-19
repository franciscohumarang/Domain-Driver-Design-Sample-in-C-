using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Application.Tasks.Commands;
using Application.Task.Queries;
using Application.Exceptions;
using Application.Queries.Task;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeTaskController : BaseApiController
    {
        [HttpPost("Add")]
        public async Task<IActionResult>  Add( AddTaskCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));

            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestMessage(ex).Message);

            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(  DeleteTaskCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestMessage(ex).Message);

            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateTaskCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestMessage(ex).Message);

            }
        }


        [HttpPost("GetDailyTaskEntries")]
        public async Task<IActionResult> GetDailyTaskEntries(GetWeeklyTasksQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {   
                return BadRequest(new BadRequestMessage(ex).Message);

            }
        }

        [HttpPost("GetTimesheetSummaryByProject")]
        public async Task<IActionResult> GetTimesheetSummaryByProject(GetTimesheetByProjectQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestMessage(ex).Message);

            }
        }


    }
}
