using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Users
{
   
    public class RestaurantUsersController : BaseApiController
    {
        [HttpPost(Name = "FoodStoreAdminCreate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CheckoutOrder([FromBody] CreateRestaurantUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
