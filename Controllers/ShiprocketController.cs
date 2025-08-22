using ShiprocketTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShiprocketTest.Controllers
{
    public class ShiprocketController : Controller
    {
        private readonly ShiprocketService _shiprocketService = new ShiprocketService();

        public async Task<ActionResult> Authenticate()
        {
            var token = await _shiprocketService.GetAuthToken();
            return Content($"Shiprocket Token: {token}");
        }

        public async Task<ActionResult> CreateOrder()
        {
            var result = await _shiprocketService.CreateOrder();
            return Content(result);
        }

        public async Task<ActionResult> TrackOrder(string awb)
        {
            var result = await _shiprocketService.TrackOrder(awb);
            return Content(result);
        }
    }

}