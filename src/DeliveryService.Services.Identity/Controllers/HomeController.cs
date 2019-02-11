using DeliveryService.Common.Commands;
using DeliveryService.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Content("Hello from DeliveryService.Services.Identity API!");
        }
    }
}
