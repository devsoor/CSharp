using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("/result")]
        public ViewResult Result(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();
        }


        [HttpPost("/update")]
        public RedirectToActionResult Update(string name, string location, string language, string comment)
        {
            return RedirectToAction("Result", new {Name = name, Location = location, Language = language, comment = comment});
        }

    }
}