using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;
using RunGroop.ViewModels;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Race race)
        {
            if (race.Title == null || !ModelState.IsValid)
                return View();

            _raceInterface.Add(race);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceInterface.GetByIdAsync(id);
            if (race == null)
                return View("Error");

            var raceViewMode = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                Image = race.Image,
                StartTime = race.StartTime,
                EntryFee = race.EntryFee,
                Website = race.Website,
                Twitter = race.Twitter,
                Facebook = race.Facebook,
                Contact = race.Contact
            };

            return View(raceViewMode);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit race");
                return View("Edit", raceViewModel);
            }

            var userClub = await _raceInterface.GetByIdAsyncNoTracking(id);
            if (userClub != null)
                try
                {
                    //delete photos
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(raceViewModel);
                }

            var photosResult = true;

            var race = new Race
            {
                Id = id,
                Title = raceViewModel.Title,
                Description = raceViewModel.Description,
                Image = raceViewModel.Image,
                StartTime = raceViewModel.StartTime,
                EntryFee = raceViewModel.EntryFee,
                Website = raceViewModel.Website,
                Twitter = raceViewModel.Twitter,
                Facebook = raceViewModel.Facebook,
                Contact = raceViewModel.Contact
            };

            if (!_raceInterface.Update(race))
            {
                ModelState.AddModelError("", "Failed to update race");
                return View("Edit", raceViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}

