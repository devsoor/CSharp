using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegister.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext dbContext;

        public HomeController(UsersContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult login(IndexViewModel user)
        {
            LoginUser loginUser= user.NewLogUser;
            User regUser= user.NewRegUser;
            string userEmail = loginUser.Email;
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == loginUser.Email);
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("loginUser.Email", "Invalid Email/Password");
                    return View("Index");
                }
                
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    System.Console.WriteLine("Passwords don't match");
                    ModelState.AddModelError("loginUser.Password", "Password does not match");
                    return View("Index");
                }
                else {
                    HttpContext.Session.SetString("UserEmail", userEmail);
                    return RedirectToAction("Success", loginUser);
                }
            } else {
                return View("Index");
            }
        }

        [HttpPost("register")]
        public IActionResult register(IndexViewModel user)
        {
            User regUser= user.NewRegUser;

            // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a User exists with provided email
                if (dbContext.Users.Any(u => u.Email == regUser.Email))
                {
                    System.Console.WriteLine("==========> ALREADY registered");
                    ModelState.AddModelError("regUser.Email", "Email already registered!");
                    return RedirectToAction("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                    // Add the user to database here
                    dbContext.Add(regUser);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserEmail", regUser.Email);
                    return RedirectToAction("Success", regUser);
                }
            } else {
                return View("Index");
            }
        } 

        public IActionResult Success()
        {
            return View();        
        }

        [HttpGet("/logout")]
        public ViewResult logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
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
