using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.User.Commands.CreateCustomerUser;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Users
{
    public class CustomerUsersController : BaseApiController
    {
        [HttpPost(Name = "CustomerCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MediatR.Unit>> CheckoutOrder([FromBody] CreateCustomerUserCommand command)
        {
            return await Mediator.Send(command);
           // return Ok(x);
           
        }
    }
}
