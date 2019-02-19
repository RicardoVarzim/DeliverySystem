using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Common.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace DeliveryService.Api.Controllers
{
    [Route("")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PointsController : Controller
    {
        private readonly IBusClient _busClient;

        public PointsController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("point")]
        public async Task<IActionResult> Post([FromBody] CreatePoint command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);

            await _busClient.PublishAsync(command);

            return Accepted("points/" + command.Id);
        }

        [HttpPost("connection")]
        public async Task<IActionResult> Post([FromBody] CreateConnection command)
        {
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);

            await _busClient.PublishAsync(command);

            return Accepted("points/" + command.Id);
        }

    }
}