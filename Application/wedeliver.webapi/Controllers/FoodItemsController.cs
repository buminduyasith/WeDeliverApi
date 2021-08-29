using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.Commands.AddFoodItem;
using wedeliver.Application.Features.Foods.Queries.GetFoodList;
using wedeliver.Application.Features.Foods.ViewModels;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;

namespace wedeliver.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodItemsController : ControllerBase
    {
    
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMediator _mediator;

        public FoodItemsController(ILogger<WeatherForecastController> logger,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoodItems()
        {
          
            var query = new GetFoodListQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //[HttpPost(Name = "AddFoodItem")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //public async Task<ActionResult<FoodVM>> CheckoutOrder([FromBody] AddFoodItemCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        [HttpPost(Name = "AddFoodItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CheckoutOrder([FromBody] CreateRestaurantUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}