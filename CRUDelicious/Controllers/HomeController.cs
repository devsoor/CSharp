using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishesContext dbContext;

        public HomeController(DishesContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public ViewResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(u => u.CreatedAt).ToList();
            return View(AllDishes);
        }

        [HttpGet("new")]
        public ViewResult NewDish(Dish newDish)
        {
            return View();
        }

        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View("NewDish");
            }
        }
        
        [HttpGet("/{id}")]
        public ViewResult ShowDish(int id)
        {
            Dish currentDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            return View(currentDish);
        }

        [HttpGet("/edit/{id}")]
        public ViewResult EditDish(int id)
        {
            Dish currentDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            return View(currentDish);
        }

        [HttpGet("/delete/{id}")]
        public IActionResult DeleteDish(int id)
        {
            Dish currentDish = dbContext.Dishes.SingleOrDefault(dish => dish.DishId == id);
            dbContext.Dishes.Remove(currentDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateDish/{id}")]
        public IActionResult UpdateDish(Dish formDish, int id)
        {
            Dish currentDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            currentDish.Name = formDish.Name;
            currentDish.Chef = formDish.Chef;
            currentDish.Description = formDish.Description;
            currentDish.Tastiness = formDish.Tastiness;
            currentDish.Calories = formDish.Calories;
            currentDish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return View("ShowDish", currentDish);
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
