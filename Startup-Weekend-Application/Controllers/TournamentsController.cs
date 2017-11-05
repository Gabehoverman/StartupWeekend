using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Startup_Weekend_Application.Controllers
{
    public class TournamentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}