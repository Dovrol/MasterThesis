using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class FindOrdersByController : BaseApiController
    {
        [HttpGet("postgres")]
        public async Task<IActionResult> PostgresFindBy([FromQuery] PostgresFindBy query)
            => Ok(await Mediator.Send(query));

        [HttpGet("mysql")]
        public async Task<IActionResult> MySqlFindBy([FromQuery] MySqlFindBy query)
            => Ok(await Mediator.Send(query));

        [HttpGet("MariaDb")]
        public async Task<IActionResult> MariaDbFindBy([FromQuery] MariaDbFindBy query)
            => Ok(await Mediator.Send(query));

        [HttpGet("MongoDb")]
        public async Task<IActionResult> MongoDbFindBy([FromQuery] MongoDbFindBy query)
            => Ok(await Mediator.Send(query));
    }
}