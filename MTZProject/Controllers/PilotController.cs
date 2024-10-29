using Microsoft.AspNetCore.Mvc;
using MTZProject.Interfaces;
using MTZProject.Logic;
using MTZProject.Models;

namespace MTZProject.Controllers
{
    public class PilotController : Controller
    {
        private readonly IOperation _operation;
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
                _operation.Processing(dataModel);
            }
            else
            {
                return BadRequest();
            }
            return View();
        }
    }
}
