using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.Login.Queries;
using wedeliver.Application.ViewModels;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Users
{
   
    public class UsersLoginController : BaseApiController
    {
        [HttpPost(Name = "UserLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserVM>> CheckoutOrder([FromBody] UserLoginCommand command)
        {

            return await Mediator.Send(command);
            // return Ok(x);

        }
    }
}
