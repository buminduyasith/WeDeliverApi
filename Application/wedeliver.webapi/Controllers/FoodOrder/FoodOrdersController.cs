using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.FoodOrder
{

    public class FoodOrdersController : BaseApiController
    {
        [HttpPost(Name = "CreateFoodOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand)
        {
            var result = await Mediator.Send(createFoodOrderCommand);
            return Ok(result);
        }
    }
}
