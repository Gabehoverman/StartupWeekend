﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Startup_Weekend_Application.Data;
using Startup_Weekend_Application.Models;
using Startup_Weekend_Application.Models.ManageViewModels;
using System.Security.Claims;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Startup_Weekend_Application.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            
            _context = context;
            _userManager = userManager;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Ping> Pings = _context.Ping.ToList();
            foreach (Ping Ping in Pings) {
                //
            }

            ViewData["pings"] = Pings;


            return View();
        }

        public IActionResult Beacons() {

            List<Ping> BeaconList = _context.Ping.ToList();
            ViewData["Pings"] = BeaconList;

            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,UserId,Game,Time,Platform,PlayStyle,SkillLevel")] Ping ping)
		{
            var user = await _userManager.GetUserAsync(User);
            ping.Username = user.UserName;

            ping.Time = DateTime.Now;

            if (ModelState.IsValid)
			{
				_context.Add(ping);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(ping);
		}

    }
}
