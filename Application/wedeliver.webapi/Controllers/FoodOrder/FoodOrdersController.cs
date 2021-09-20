using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus;
using wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrderByRestaurantId;
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

        [HttpPut(("status/{id}"), Name = "UpdateFoodOrderStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFoodOrderStatus(int id,UpdateFoodOrderStatusCommand updateFoodOrderStatusCommand)
        {
            var result = await Mediator.Send(updateFoodOrderStatusCommand);
            return Ok(result);
        }


        [HttpGet(("restaurant/{id}/orders"), Name = "GetAllFoodOrdersByRestaurantId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFoodOrdersByRestaurantId(int id)
        {
            var result = await Mediator.Send(new GetAllFoodOrderByRestaurantIdQuery { RestaurantId=id});
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
           
        }

    }
}
