using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
       private WeddingContext dbContext;

        public HomeController(WeddingContext context)
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
                    ModelState.AddModelError("", "Invalid Email/Password");
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
                    ModelState.AddModelError("Password", "Password does not match");
                    return View("Index");
                }
                else {
                    HttpContext.Session.SetString("UserEmail", userEmail);
                    return RedirectToAction("Dashboard");
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
                    ModelState.AddModelError("regUser.Email", "Email already registered!");
                    return RedirectToAction("Index");
                } else {

                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                    // Add the user to database here
                    dbContext.Add(regUser);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserEmail", regUser.Email);

                    return RedirectToAction("Dashboard");
                }
            } else {
                return View("Index");
            }
        }

        public User GetCurrentUser()
        {
            string userEmail = HttpContext.Session.GetString("UserEmail");
            User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            return userInDb;
        } 

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            List<Wedding> allWeddings = dbContext.Weddings.ToList();
            User currentUser = GetCurrentUser();
            ViewBag.CurrentUser = currentUser;
            
            foreach (var wed in allWeddings)
            {
                var wedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == wed.WeddingId);
                wedding.Action = "RSVP";
                // Now check if the current logged in user is already attending this wedding
                // by creating list of users attending this wedding
                var allAttendedWeddings = dbContext.Weddings
                    .Include(a => a.AttendedUsers)
                    .ThenInclude(u => u.User)
                    .FirstOrDefault(w => w.WeddingId == wed.WeddingId);
                //first check if the current logged in user is the creator of this wedding
                if (wedding.UserId == currentUser.UserId)
                    wedding.Action = "Delete";
                else if (allAttendedWeddings.AttendedUsers.Exists(u => u.User.UserId == currentUser.UserId))
                        wedding.Action = "UnRSVP";
                dbContext.SaveChanges();
            }
            return View(allWeddings);
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            return View();
        }

        [HttpPost("CreateWedding")]
        public IActionResult CreateWedding(Wedding wedding)
        {
            if (ModelState.IsValid)
            {
                wedding.Name = $"{wedding.WedderOne} & {wedding.WedderTwo}";
                User currentUser = GetCurrentUser();
                wedding.UserId = currentUser.UserId;
                wedding.Action = "Delete";
                string tdDate = DateTime.Now.ToString("MMM dd, yyyy");
                wedding.DateToDisplay = tdDate;
                dbContext.Add(wedding);
                dbContext.SaveChanges();
                return RedirectToAction("ShowWedding", new {id = wedding.WeddingId});
            } else
            {
                return View("NewWedding");
            }
        }

        [HttpGet("ShowWedding/{id}")]
        public IActionResult ShowWedding(int id)
        {
            var wedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == id);

            // Create a guest list and send it in ViewBag
            var guestList = dbContext.Weddings
                .Include(a => a.AttendedUsers)
                .ThenInclude(u => u.User)
                .FirstOrDefault(w => w.WeddingId == id);
            ViewBag.GuestList = guestList.AttendedUsers;
            return View(wedding);
        }

        [HttpGet("RSVPWedding/{type}/{id}")]
        public IActionResult RSVP(string type, int id)
        {
            User currentUser = GetCurrentUser();
        
            switch(type)
            {
                case "RSVP":
                    var userWedding = new UserWedding
                    {
                        UserId = currentUser.UserId,
                        WeddingId = id
                    };
                    dbContext.Add(userWedding);
                    break;
                case "UnRSVP":
                    var uw = dbContext.UserWeddings
                        .FirstOrDefault(w => w.UserId == currentUser.UserId && w.WeddingId == id);
                    dbContext.Remove(uw);
                    break;
                case "Delete":

                    // Delete the wedding 
                    // NOTE: This will automatically remove all references to users of this wedding in the Join table - COOL!!
                    var wed = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == id);
                    dbContext.Remove(wed);
                    break;
            }

            dbContext.SaveChanges();
            ViewBag.CurrentUser = currentUser;
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/logout")]
        public IActionResult logout()
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
