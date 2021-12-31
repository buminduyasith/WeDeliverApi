using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.Commands.AddFoodCategory;
using wedeliver.Application.Features.Foods.Queries.GetAllFoodCategory;
using wedeliver.Application.Features.Foods.Queries.TestPdf;
using wedeliver.Application.ViewModels;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.FoodCategory
{
  
    public class FoodCategoryController : BaseApiController
    {
        [HttpPost(Name = "CreateFoodCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodCategoryVM>> CreateFoodOrder(AddFoodCategoryCommand addFoodCategoryCommand)
        {
            var result = await Mediator.Send(addFoodCategoryCommand);
            return CreatedAtRoute("GetSpecificFoodCategoryByClient", new { orderId = result.Id }, result);

        }

        [HttpGet(Name = "GetAllFoodCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodCategoryVM>> GetAllFoodCategories()
        {

            var result = await Mediator.Send(new GetAllFoodCategoryQuery());
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet("/test",Name = "wow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ContentResult> test()
        {

            var result = await Mediator.Send(new TestPdfQuery());
            if (result != null)
            {
                return base.Content(result, "text/html");
            }

            return base.Content("<div>Hello</div>", "text/html");

        }
    }
}
