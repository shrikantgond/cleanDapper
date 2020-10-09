using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanApp.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanApp.Application.Authentication.Commands;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        [HttpPost("Register")]
        public async Task<ActionResult<long>> SaveFunction1(RegisterCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
