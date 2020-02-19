using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = context.Leagues
                .Where(w => w.Name.Contains("Women"));
            ViewBag.HockeyLeagues = context.Leagues
                .Where(w => w.Sport.ToLower().Contains("hockey"));
            ViewBag.LeaguesOtherThanFootball = context.Leagues
                .Where(w => !w.Sport.ToLower().Contains("football"));
            ViewBag.LeaguesCalledConferences = context.Leagues
                .Where(w => w.Name.ToLower().Contains("conference"));
            ViewBag.LeaguesAtlanticRegion = context.Leagues
                .Where(w => w.Name.ToLower().Contains("atlantic"));
            ViewBag.TeamsInDallas = context.Teams
                .Where(w => w.Location.Contains("Dallas"));
            ViewBag.TeamsNamedRaptors = context.Teams
                .Where(w => w.TeamName.Contains("Raptors"));
            ViewBag.TeamsLocationCity = context.Teams
                .Where(w => w.Location.Contains("City"));
            ViewBag.TeamsNameBeginWithT = context.Teams
                .Where(w => w.TeamName.StartsWith("T"));
            ViewBag.TeamsAlphabeticalLocation = context.Teams
                .OrderBy(l => l.Location);
            ViewBag.TeamsReverseAlphabeticalLocation = context.Teams
                .OrderByDescending(t => t.TeamName);
            ViewBag.PlayerLastnameCooper = context.Players
                .Where(w => w.LastName.Contains("Cooper"));
            ViewBag.PlayerFirstnameJoshua = context.Players
                .Where(w => w.FirstName.Contains("Joshua"));

            ViewBag.PlayerLastnameCooperExceptJoshua = context.Players
                .Where(w => w.LastName.Contains("Cooper"))
                .Where(w => w.FirstName !="Joshua");

            ViewBag.PlayerAlexWyatt = context.Players
                .Where(w => w.FirstName == "Alexander" || w.FirstName == "Wyatt");
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}