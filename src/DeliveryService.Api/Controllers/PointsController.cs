using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace DeliveryService.Api.Controllers
{
    [Route("[controller]")]
    public class PointsController : Controller
    {
        private readonly IBusClient _busClient;

        public PointsController(IBusClient busClient)
        {
            _busClient = busClient ?? throw new ArgumentNullException(nameof(busClient));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreatePoint command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;

            await _busClient.PublishAsync(command);

            return Accepted("points/" + command.Id);
        }
    }
}