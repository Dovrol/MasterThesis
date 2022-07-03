using Application.Commands;
using Application.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CreateOrdersController : BaseApiController
    {
        [HttpPost("postgres")]
        public async Task<IActionResult> PostgresCreateOrders(int n)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.Postgres}));

        [HttpPost("MySQL")]
        public async Task<IActionResult> MySqlCreateOrders(int n)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.MySQL}));

        [HttpPost("MariaDb")]
        public async Task<IActionResult> MariaDbCreateOrders(int n)
            => Ok(await Mediator.Send(new CreateOrders.Command { N = n, Db = SupportedDb.MariaDb}));
    }
}