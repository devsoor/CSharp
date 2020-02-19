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
using AuctionsBelt.Models;

namespace AuctionsBelt.Controllers
{
    public class HomeController : Controller
    {
       private AuctionContext dbContext;

        public HomeController(AuctionContext context)
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
            string userName = loginUser.Username;

            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided username
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Username == loginUser.Username);
                // If no user exists with provided Username
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("NewLogUser.Username", "Invalid Username/Password");
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
                    ModelState.AddModelError("NewLogUser.Password", "Password does not match");
                    return View("Index");
                }
                else {
                    HttpContext.Session.SetString("UserName", userName);
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
                // If a User exists with provided Username
                if (dbContext.Users.Any(u => u.Username == regUser.Username))
                {
                    ModelState.AddModelError("NewRegUser.Username", "Username already registered!");
                    return RedirectToAction("Index");
                } else {

                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                    regUser.Wallet = 1000;
                    // Add the user to database here
                    dbContext.Add(regUser);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserName", regUser.Username);

                    return RedirectToAction("Dashboard");
                }
            } else {
                return View("Index");
            }
        }

        public User GetCurrentUser()
        {
            string userUserName = HttpContext.Session.GetString("UserName");
            User userInDb = dbContext.Users.FirstOrDefault(u => u.Username == userUserName);
            return userInDb;
        } 

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            User currentUser = GetCurrentUser();
            ViewBag.CurrentUser = currentUser;
            List<Auction> allAuctions = dbContext.Auctions.OrderByDescending(a => a.TimeRemaining).ToList();
         
            foreach (var auc in allAuctions)
            {
                var auction = dbContext.Auctions.FirstOrDefault(a => a.AuctionId == auc.AuctionId);
                var aAucs = dbContext.Auctions
                    .Include(a => a.UserList)
                    .ThenInclude(u => u.User)
                    .FirstOrDefault(p => p.AuctionId == auction.AuctionId);
                
                if (auc.UserId == currentUser.UserId)
                {
                    auc.Action = "Delete";
                }
                else
                    auc.Action = "";
                
                foreach (var u in aAucs.UserList)
                {
                    if (u.User.UserId == auc.UserId)
                    {
                        auc.FirstName = u.User.FirstName;
                        break;
                    }
                    
                }
                dbContext.SaveChanges();
                TimeSpan interval = auc.EndDate - DateTime.Now;
                auc.TimeRemaining = (int)interval.TotalDays/365;
                dbContext.SaveChanges();
            }
            return View(allAuctions);
        }

        [HttpGet("/logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpGet("NewAuction")]
        public IActionResult NewAuction()
        {
            return View();
        }

       [HttpPost("CreateAuction")]
        public IActionResult CreateAuction(Auction auction)
        {
            User currentUser = GetCurrentUser();

            if (ModelState.IsValid)
            {
                auction.Seller = currentUser;
                dbContext.Add(auction);
                var ua = new UserAuction
                    {
                        UserId = currentUser.UserId,
                        AuctionId = auction.AuctionId
                    };
                dbContext.Add(ua);

                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
                // return RedirectToAction("ShowAuction", new {id = auction.AuctionId});
            } else
            {
                return View("NewAuction");
            }
        }

        [HttpGet("DeleteAuction/{id}")]
        public IActionResult DeleteAuction(int id)
        {
            var auction = dbContext.Auctions.FirstOrDefault(w => w.AuctionId == id);
            dbContext.Remove(auction);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/ShowAuction/{id}")]
        public IActionResult ShowAuction(int id)
        {
            var auction = dbContext.Auctions.FirstOrDefault(w => w.AuctionId == id);
            return View(auction);
        }

        [HttpPost("/PlaceBid/{id}")]
        public IActionResult PlaceBid(int id, int placedBid)
        {
            ViewBag.BidError = "";
            var auction = dbContext.Auctions.FirstOrDefault(w => w.AuctionId == id);
            User currentUser = GetCurrentUser();
            if (auction.TopBid == 0 && placedBid < auction.StartingBid)
            {
                ViewBag.BidError = "$Starting bid is {auction.StartingBid}";
                return View("ShowAuction", auction);
            }

            if (placedBid < auction.TopBid )
            {
                ViewBag.BidError = "You must place bid higher than previous bid";
                return View("ShowAuction", auction);
            }
            if (placedBid > currentUser.Wallet)
            {
                ViewBag.BidError = "You must place bid less than your Wallet size";
                return View("ShowAuction", auction);
            }

            // auction ends

            currentUser.Wallet -= placedBid;
            auction.TopBid = placedBid;
            TimeSpan interval = auction.EndDate - DateTime.Now;
            auction.TimeRemaining = (int)interval.TotalDays/365;
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
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
