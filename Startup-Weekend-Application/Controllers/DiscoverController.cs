using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Startup_Weekend_Application.Data;
using Startup_Weekend_Application.Models;

namespace Startup_Weekend_Application.Controllers
{
    public class DiscoverController : Controller
    {
        private ApplicationDbContext _dbContext;
        

        public DiscoverController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        //Get Discover Pings
        public IActionResult Index()
        {
            var Dpings = _dbContext.Discover.ToList();

            return View(Dpings);
        }
    }
}