using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunGroop.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceInterface _raceInterface;
        public RaceController(IRaceInterface raceInterface)
        {
            _raceInterface = raceInterface;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var races = await _raceInterface.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceInterface.GetByIdAsync(id);
            return View(race);
        }
    }
}

