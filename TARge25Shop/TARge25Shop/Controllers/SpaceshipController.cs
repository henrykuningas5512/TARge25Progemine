using Microsoft.AspNetCore.Mvc;

namespace TARge25Shop.Controllers
{
    public class SpaceshipController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
