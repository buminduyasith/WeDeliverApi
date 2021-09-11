using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.Commands.AddFoodItem;
using wedeliver.Application.Features.Foods.Queries.GetFoodById;
using wedeliver.Application.Features.Foods.Queries.GetFoodList;
using wedeliver.Application.Features.Foods.ViewModels;
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
        public async Task<IActionResult> GetFoodItemById(int id)
        {

            //var result = await Mediator.Send(getFoodByIdQuery);
            return Ok(id);
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