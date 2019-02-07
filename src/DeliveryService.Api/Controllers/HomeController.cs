using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Hello from DeliveryService EPIC Api
        /// </summary>
        /// <returns>
        /// Returns Hello from DeliveryServiceApo
        /// </returns>
        [Route("")]
        public IActionResult Get()
        {
            return Content("Hello from DeliveryServiceApi");
        }

    }
}