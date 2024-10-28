using Microsoft.AspNetCore.Mvc;
using MTZProject.Models;

namespace MTZProject.Controllers
{
    public class PilotController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(InputProcessVM dataModel)
        {
            if (ModelState.IsValid)
            { 

            }
            return View();
        }
    }
}
