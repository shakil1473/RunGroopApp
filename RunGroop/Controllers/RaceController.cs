using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;
using RunGroop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunGroop.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RaceController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var races = _applicationDbContext.Races.ToList();
            return View(races);
        }

        public IActionResult Detail(int id)
        {
            Race race = _applicationDbContext.Races.FirstOrDefault(r => r.Id == id);
            return View(race);
        }
    }
}

