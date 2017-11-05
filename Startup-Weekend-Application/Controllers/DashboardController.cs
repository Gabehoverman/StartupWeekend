using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Startup_Weekend_Application.Data;
using Startup_Weekend_Application.Models;
using Startup_Weekend_Application.Models.ManageViewModels;
using System.Security.Claims;
using System.Diagnostics.Contracts;


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
            var username = _userManager.GetUserName(User);

            List<Interests> interests = _context.Interests.Where(p => p.Username.Contains(username)).ToList();
            ViewData["interests"] = interests;

            List<Ping> richPings = new List<Ping>();

            foreach (Interests interest in interests) {
                List<Ping> richPing = _context.Ping.Where(p => p.Game.Contains(interest.GameTitle)).ToList();
                richPings.AddRange(richPing);
            }

            ViewData["richPings"] = richPings;

			List<Ping> Pings = _context.Ping.ToList();

            ViewData["pings"] = Pings;


            return View();
        }

        public IActionResult Profile(String Username)
        {

            var user = _context.ApplicationUsers.Where(p => p.UserName.Contains(Username));

            ViewData["User"] = user;

            return View();
        }

		public IActionResult Interests()
		{
            var username = _userManager.GetUserName(User);
			List<Interests> interests = _context.Interests.Where(p => p.Username.Contains(username)).ToList();
			ViewData["interests"] = interests;

			return View();
		}

        //Not In Use;
        public async Task<IAsyncResult> MatchUsersAsync()
        {
            var user = await _userManager.GetUserAsync(User);

			List<Ping> Ping = 
                (System.Collections.Generic.List<Startup_Weekend_Application.Models.Ping>)
                (from ping in _context.Ping
                where ping.Username == user.UserName
                select ping);
            return (System.IAsyncResult)Ping;
        }

        //Returns all pings for beacons page
        public IActionResult Beacons() {

            var username = _userManager.GetUserName(User);

			List<Interests> interests = _context.Interests.Where(p => p.Username.Contains(username)).ToList();
			ViewData["interests"] = interests;

			List<Ping> richPings = new List<Ping>();

			foreach (Interests interest in interests)
			{
				List<Ping> richPing = _context.Ping.Where(p => p.Game.Contains(interest.GameTitle)).ToList();
				richPings.AddRange(richPing);
			}

            ViewData["richPings"] = richPings;

            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Username,Game,Time,Platform,PlayStyle,SkillLevel")] Ping ping)
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> New([Bind("Id,Username,Game,Time,Platform,PlayStyle,SkillLevel")] Ping ping)
		{
			var user = await _userManager.GetUserAsync(User);
			ping.Username = user.UserName;

			ping.Time = DateTime.Now;

			if (ModelState.IsValid)
			{
				_context.Add(ping);
				await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Beacons));
			}
			return View(ping);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> NewInterest([Bind("Id,Username,GameTitle,Platform,IsActive")] Interests interest)
		{
			var user = await _userManager.GetUserAsync(User);
            interest.Username = user.UserName;
            interest.IsActive = true;


			if (ModelState.IsValid)
			{
                _context.Add(interest);
				await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DashboardController.Interests));
			}
            return View(interest);
		}

    }
}
