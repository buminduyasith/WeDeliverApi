using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus;
using wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderById;
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


        [HttpGet(("restaurant/{id}/foodorders"), Name = "GetAllFoodOrdersByRestaurantId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFoodOrdersByRestaurantId(GetFoodOrderByRestaurantIdQuery getFoodOrderByRestaurantIdQuery)
        {
            var result = await Mediator.Send(getFoodOrderByRestaurantIdQuery);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
           
        }
    }
}
