using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.MedicineOrders.Commands.CreateMedicineOrder;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.MedicineOrder
{
   
    public class MedicineOrdersController : BaseApiController
    {
        [HttpPost(Name = "CreateMedicineOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMedicineOrders(CreateMedicineOrderCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
