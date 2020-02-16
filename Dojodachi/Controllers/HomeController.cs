using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Pet pet = new Pet();
            return RedirectToAction("dojodachi", pet);
        }

        [HttpGet("dojodachi")]
        public IActionResult dojodachi(Pet pet)
        {
            return View("Dojodachi", pet);
        }

        [HttpPost("Feed")]
        public IActionResult Feed()
        {
            return RedirectToAction("dojodachi");
        }

        [HttpPost("Play")]
        public IActionResult Play()
        {
            return RedirectToAction("Index");
        }
        [HttpPost("Work")]
        public IActionResult Work()
        {
            return RedirectToAction("Index");
        }

        [HttpPost("Sleep")]
        public IActionResult Sleep()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
