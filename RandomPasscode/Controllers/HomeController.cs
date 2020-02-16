using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int strSize = 14;
            var randString = new char[strSize];
            for (int i = 0; i < strSize; i++) {
                randString[i] = chars[random.Next(chars.Length)];
            }
            string finalString = new string(randString);
            ViewBag.randomString = finalString;
            int? currentCount = HttpContext.Session.GetInt32("count");
            ViewBag.Count = currentCount;
            return View();
        }

        [HttpPost("Generate")]
        public IActionResult Generate()
        {
            if (HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 0);
            }
            int? currentCount = HttpContext.Session.GetInt32("count");
            currentCount++;
            HttpContext.Session.SetInt32("count", (int)currentCount);
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
