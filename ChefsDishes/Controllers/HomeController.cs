using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;


namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefDishContext dbContext;

        public HomeController(ChefDishContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<User> allUsers = dbContext.Users
                .OrderByDescending(u => u.CreatedAt)
                .Include(u => u.CreatedDishes)
                .ToList();
            return View(allUsers);
        }

        [HttpGet("/NewChef")]
        public ViewResult NewChef()
        {
            return View();
        }

        [HttpPost("NewChefSubmit")]
        public IActionResult NewChefSubmit(User newChef)
        {
            if (ModelState.IsValid)
            {
                DateTime today = DateTime.Now; 
                TimeSpan interval = today - newChef.DOB;
                Double totalYears = interval.TotalDays/365;
                newChef.Age = (int)totalYears;
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View("NewChef");
            }
        }

        [HttpGet("dishes")]
        public ViewResult dishes()
        {
            List<Dish> allDishes = dbContext.Dishes
                .OrderByDescending(u => u.CreatedAt)
                .Include(d => d.Chef)
                .ToList();
            return View("Dishes", allDishes);
        }

        [HttpGet("/dishes/new")]
        public ViewResult NewDish()
        {
            List<User> AllUsers = dbContext.Users.OrderByDescending(u => u.CreatedAt).ToList();
            ViewBag.Allusers = AllUsers;
            return View();
        }

        // [HttpPost("AddDish")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                List<User> AllUsers = dbContext.Users.OrderByDescending(u => u.CreatedAt).ToList();
                ViewBag.Allusers = AllUsers;
                return View("NewDish");
            }
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
