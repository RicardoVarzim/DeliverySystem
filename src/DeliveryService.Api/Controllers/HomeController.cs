using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Get()
        {
            return Content("Hello from DeliveryServiceApi");
        }

    }
}