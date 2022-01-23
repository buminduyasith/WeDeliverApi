using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.Commands.RiderAcceptOrder;
using wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus;
using wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrderByRestaurantId;
using wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrdersAvailableForRiders;
using wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrdersByClient;
using wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByIdClient;
using wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByRestaurantId;
using wedeliver.Application.Features.FoodOrders.Queries.GetOrdersForRidersByRiderId;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.FoodOrder
{

    public class FoodOrdersController : BaseApiController
    {
        [HttpPost(Name = "CreateFoodOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodOrderVM>> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand)
        {
            var result = await Mediator.Send(createFoodOrderCommand);
            return CreatedAtRoute("GetSpecificFoodOrderByClient", new { orderId = result.Id, clientId =result.ClientID}, result);
           
        }

        [HttpGet(("client/{clientId}/orders/{orderId}"), Name = "GetSpecificFoodOrderByClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodOrderVM>> GetSpecificFoodOrderByClient(int clientId, int orderId)
        {
            var result = await Mediator.Send(new GetFoodOrderByIdClientQuery { ClientId = clientId, OrderId = orderId });
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet(("client/{id}/orders"), Name = "GetAllSpecificFoodOrderByClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FoodOrderVM>>> GetAllSpecificFoodOrderByClient(int id)
        {
            var result = await Mediator.Send(new GetAllFoodOrdersByClientQuery { ClientId = id });
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }


        /// <summary>
        /// implement this in handler
        /// </summary>

        //[HttpPut(("status/{id}"), Name = "UpdateFoodOrderStatus")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateFoodOrderStatus(int id, UpdateFoodOrderStatusCommand updateFoodOrderStatusCommand)
        //{
        //    var result = await Mediator.Send(updateFoodOrderStatusCommand);
        //    return NoContent();
        //}


        [HttpGet(("restaurant/{id}/orders"), Name = "GetAllFoodOrdersByRestaurantId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FoodOrderRestaurantVM>>> GetAllFoodOrdersByRestaurantId(int id)
        {
            var result = await Mediator.Send(new GetAllFoodOrderByRestaurantIdQuery { RestaurantId=id});
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
           
        }

        [HttpGet(("restaurant/{restaurantId}/orders/{orderId}"), Name = "GetSpecificFoodOrderByRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodOrderRestaurantVM>> GetSpecificFoodOrderByRestaurant(int restaurantId, int orderId)
        {
            var result = await Mediator.Send(new GetFoodOrderByRestaurantIdQuery { RestaurantId = restaurantId, OrderId = orderId });
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        
        [HttpGet(("riders/orderstobedelivered"), Name = "GetAllFoodOrdersAvailableForRiders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodOrderRestaurantVM>> GetAllFoodOrdersAvailableForRiders()
        {
            var result = await Mediator.Send(new GetAllFoodOrdersAvailableForRidersQuery());

            if (result != null)
            {
               return Ok(result);
            }

            return NotFound();

        }

       
        [HttpPost(("rideracceptorder"), Name = "RiderAcceptOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        //check the return type 
        public async Task<ActionResult> RiderAcceptOrder(RiderAcceptOrderCommand riderAcceptOrderCommand)
        {
            var result = await Mediator.Send(riderAcceptOrderCommand);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost(("updateorderstatus"), Name = "UpdateOrderStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodOrderVM>> UpdateOrderStatus(UpdateFoodOrderStatusCommand updateFoodOrderStatusCommand)
        {
            var result = await Mediator.Send(updateFoodOrderStatusCommand);
           
            //first parameter need to change
            return CreatedAtRoute("UpdateOrderStatus", new { orderId = updateFoodOrderStatusCommand.OrderId }, result);

        }

        [HttpPost(("rider/orders"), Name = "GetAllOrdersForRiderByRiderId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodOrderVM>> GetAllOrdersForRiderByRiderId(GetAllOrdersForRiderByRiderIdQuery getAllOrdersForRiderByRiderId)
        {
            var result = await Mediator.Send(getAllOrdersForRiderByRiderId);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

    }
}
