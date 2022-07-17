using Application.Commands;
using Application.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CreateOrdersController : BaseApiController
    {
        [HttpPost("Postgres")]
        public async Task<IActionResult> PostgresCreateOrders(int n, int seed)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.Postgres, Seed = seed}));

        [HttpPost("MySQL")]
        public async Task<IActionResult> MySqlCreateOrders(int n, int seed)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.MySQL, Seed = seed}));

        [HttpPost("MariaDb")]
        public async Task<IActionResult> MariaDbCreateOrders(int n, int seed)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.MariaDb, Seed = seed}));

        [HttpPost("MongoDb")]
        public async Task<IActionResult> MongoDbCreateOrders(int n, int seed)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.MongoDb, Seed = seed}));
    }
}