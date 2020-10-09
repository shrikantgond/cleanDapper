using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanApp.Application.Assistance.Commands.RequestAssistance;
using CleanApp.Application.Assistance.Queries;
using CleanApp.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistanceController : ApiController
    {
        [HttpPost("RequestAssistance")]
        public async Task<ActionResult<TicketDetailsDTO>> RequestAssistanceCommand(RequestAssistanceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("GetTicketDetails")]
        public async Task<ActionResult<TicketDetailsDTO>> GetTicketDetails(GetTicketDetailsByIDQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
