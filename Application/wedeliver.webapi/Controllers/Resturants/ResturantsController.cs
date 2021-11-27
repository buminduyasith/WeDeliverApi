using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.Resturants.Queries.ResturantsSearch;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Resturants
{
   
    public class ResturantsController : BaseApiController
    {
        [HttpPost(("search"), Name = "SearchResturants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchResturants(ResturantsSearchQuery resturantsSearchQuery)
        {
          
            var result = await Mediator.Send(resturantsSearchQuery);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}


