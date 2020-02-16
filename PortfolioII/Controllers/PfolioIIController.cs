using Microsoft.AspNetCore.Mvc;

namespace PortfolioII.Controllers
{
    public class PfolioIIController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("/projects")]
        public ViewResult Projects()
        {
            return View();
        }

        [HttpGet("/contact")]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost("/update")]
        public RedirectToActionResult Update()
        {
            return RedirectToAction("Index");
        }

    }
}