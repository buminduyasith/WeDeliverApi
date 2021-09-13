using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.Commands.AddFoodItem;
using wedeliver.Application.Features.Foods.Queries.GetFoodById;
using wedeliver.Application.Features.Foods.Queries.GetFoodList;
using wedeliver.Application.ViewModels;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Foods
{
    
    public class FoodItemsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFoodItems()
        {
            var query = new GetFoodListQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }


      

        [HttpGet("{id}", Name = "GetFoodItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodVM>> GetFoodItemById(int id)
        {
            var getFoodByIdQuery = new GetFoodByIdQuery(id);
            var result = await Mediator.Send(getFoodByIdQuery);
            if (result is null) return NotFound();
            return Ok(result);
        }
       
        [HttpPost]
        public async Task<IActionResult> AddFoodItem(AddFoodItemCommand addFoodItemCommand)
        {
            var result = await Mediator.Send(addFoodItemCommand);
            return Ok(result);
        }





    }
}



//private readonly ILogger<WeatherForecastController> _logger;

//private readonly IMediator _mediator;

//public FoodItemsController(ILogger<WeatherForecastController> logger,IMediator mediator)
//{
//    _mediator = mediator;
//    _logger = logger;
//}