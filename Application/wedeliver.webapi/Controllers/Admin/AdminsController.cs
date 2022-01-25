using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedeliver.Application.Features.Admin.Queries.GetNewlyRegisterdUser;
using wedeliver.Application.ViewModels;
using wedeliver.webapi.Controllers.Base;

namespace wedeliver.webapi.Controllers.Admin
{
    public class AdminsController : BaseApiController
    {
        

        [HttpGet("inactiveusers", Name = "GetNewlyRegisterdUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVmForAdmin>> GetNewlyRegisterdUsers()
        {

            var result = await Mediator.Send(new GetNewlyRegisterdUsersQuery());
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }


    }
}
