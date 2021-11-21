using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.User.Commands.CreateRiderUser;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Users
{
    public class RiderUserController : BaseApiController
    {
        [HttpPost(Name = "RiderCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MediatR.Unit>> CheckoutOrder([FromBody] CreateRiderUserCommand command)
        {
            return await Mediator.Send(command);
           // return Ok(x);
           
        }
    }
}
