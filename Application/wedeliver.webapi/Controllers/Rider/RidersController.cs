using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.RiderOrders.Queries;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Rider
{
    public class RidersController : BaseApiController
    {
        [HttpPost(("orders"), Name = "GetAllPendingOrdesTobeDeliverd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPendingOrdesTobeDeliverd(RiderOrderQuery riderOrderQuery)
        {

            var result = await Mediator.Send(riderOrderQuery);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
