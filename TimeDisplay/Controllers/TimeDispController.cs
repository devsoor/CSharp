using System;
using Microsoft.AspNetCore.Mvc;


namespace TimeDisplay.Controllers
{
    public class TimeDispController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            string tdDate = DateTime.Now.ToString("MMM dd, yyyy  hh:mm tt");
            ViewBag.myDate = tdDate;
            return View();
        }
    }
}