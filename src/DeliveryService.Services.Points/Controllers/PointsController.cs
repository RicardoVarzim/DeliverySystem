using DeliveryService.Common.Commands;
using DeliveryService.Services.Points.Domain.Repositories;
using DeliveryService.Services.Points.Repositories;
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
        private IGraphRepository _graphRepository;
        private IPointRepository _pointRepository;

        public PointsController(IGraphRepository repository, IPointRepository pointRepository)
        {
            _graphRepository = repository;
            _pointRepository = pointRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> BrowsePoints()
        {
            return Json(await _pointRepository.BrowseAsync());
        }

        [HttpGet("path")]
        public async Task<IActionResult> GetPath([FromBody] GetPath command)
        {
            var originPoint = _pointRepository.GetAsync(command.originId);
            var destinationPoint = _pointRepository.GetAsync(command.destinationId);
            var pathList = await _graphRepository.PathAsync(originPoint.Result, destinationPoint.Result);
            if (pathList == null)
            {
                return NotFound();
            }

            //if (pathList.UserId != Guid.Parse(User.Identity.Name))
            //{
            //    return Unauthorized();
            //}

            return Json(pathList);
        }
    }
}
