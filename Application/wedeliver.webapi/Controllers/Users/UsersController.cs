using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.Login.Queries;
using wedeliver.Application.Features.User.Commands.CreateCustomerUser;
using wedeliver.Application.Features.User.Commands.CreatePharmacyUser;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
using wedeliver.Application.Features.User.Commands.CreateRiderUser;
using wedeliver.Application.ViewModels;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Users
{
   
    public class UsersController : BaseApiController
    {
        [HttpPost("login",Name = "UserLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserVM>> UserLogin([FromBody] UserLoginCommand command)
        {

            return await Mediator.Send(command);
            // return Ok(x);

        }

        [HttpPost("register/customer",Name = "CustomerCreate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MediatR.Unit>> CustomerCreate([FromBody] CreateCustomerUserCommand command)
        {

            return await Mediator.Send(command);
            // return Ok(x);

        }

        [HttpPost("register/rider",Name = "RiderCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MediatR.Unit>> RiderCreate([FromBody] CreateRiderUserCommand command)
        {
            return await Mediator.Send(command);
            // return Ok(x);

        }

        [HttpPost("register/foodstore",Name = "FoodStoreAdminCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> FoodStoreAdminCreate([FromBody] CreateRestaurantUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register/pharmacy", Name = "PharmacyUserCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PharmacyUserCreate([FromBody] CreatePharmacyUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
