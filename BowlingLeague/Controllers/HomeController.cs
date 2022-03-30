using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository bowlRepo { get; set; }
        private ITeamsRepository teamRepo { get; set; }

        public HomeController(IBowlersRepository b, ITeamsRepository t)
        {
            bowlRepo = b;
            teamRepo = t;
        }

        public IActionResult Index(string teamName)
        {
            var bowlers = bowlRepo.Bowlers
                .Where(x => x.Team.TeamName == teamName || teamName == null);

            ViewBag.TeamName = teamName;
            ViewBag.NextBowler = bowlRepo.Bowlers.Max(x => x.BowlerID) + 1;

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            Bowler bowler = new Bowler();
            bowler.BowlerID = id;

            ViewBag.Teams = teamRepo.Teams.ToList();

            return View("Form", bowler);
        }

        [HttpPost]
        public IActionResult Create(Bowler b)
        {
            if (ModelState.IsValid)
            {
                bowlRepo.AddBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = teamRepo.Teams.ToList();
                ViewBag.ErrorMessage = "Check";

                return View("Form", b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Bowler bowler = bowlRepo.Bowlers.Single(x => x.BowlerID == id);
            ViewBag.Teams = teamRepo.Teams.ToList();
            ViewBag.Check = 1;

            return View("Form", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                bowlRepo.UpdateBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = teamRepo.Teams.ToList();
                ViewBag.ErrorMessage = "Check";
                ViewBag.Check = 1;

                return View("Form", b);
            }
        }

        public IActionResult Delete(int id)
        {
            Bowler b = bowlRepo.Bowlers.FirstOrDefault(x => x.BowlerID == id);

            bowlRepo.DeleteBowler(b);

            return RedirectToAction("Index");
        }
    }
}
