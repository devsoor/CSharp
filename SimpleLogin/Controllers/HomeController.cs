using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLogin.Models;

namespace SimpleLogin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(IndexViewModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            } else
            {
                return View("Index", user);
            }
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginrUser(IndexViewModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            } else
            {
                return View("Index", user);
            }
        }

        public IActionResult Success()
        {
            return View();        
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
