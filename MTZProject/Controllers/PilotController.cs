using Microsoft.AspNetCore.Mvc;
using MTZProject.Interfaces;
using MTZProject.Logic;
using MTZProject.Models;

namespace MTZProject.Controllers
{
    public class PilotController : Controller
    {
        private IOperation _operation;
        public PilotController(IOperation operation)
        {
            _operation = operation;
        }
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
                OutputProcessVM outputProcess = Operations.Processing(dataModel);
                return Json(outputProcess);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
