using DeliveryService.Common.Commands;
using DeliveryService.Services.Points.Domain.Repositories;
using DeliveryService.Services.Points.Repositories;
using DeliveryService.Services.Points.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Controllers
{
    [Route("")]
    public class PointsController : Controller
    {
        private IPointService _pointService;

        public PointsController(IPointService service, IPointRepository pointRepository)
        {
            _pointService = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> BrowsePoints()
        {
            return Json(await _pointService.BrowsePointsAsync());
        }

        [HttpGet("path")]
        public async Task<IActionResult> GetPath([FromBody] GetPath command)
        {
            return Json(await _pointService.GetPath(command.originId, command.destinationId));
        }
    }
}
