
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;
using RunGroop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunGroop.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubInterface _clubInterface;


        public ClubController(IClubInterface clubInterface)
        {
            _clubInterface = clubInterface;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubInterface.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubInterface.GetByIdAsync(id);

            /*
             * _applicationDbContext.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
             * When one model has another model as properties we need to use include
             * Include actually doing the join. you can abstration of join.
             */

            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            if(club.Title == null || !ModelState.IsValid)
            {
                return View(club);
            }

            _clubInterface.Add(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubInterface.GetByIdAsync(id);
            if (club == null)
                return View("Error");

            var clubVM = new EditClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                Image = club.Image
            };

            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel clubViewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", clubViewModel);
            }

            var userClub = await _clubInterface.GetByIdAsyncNoTracking(id);
            if(userClub != null)
                try
                {
                    //delete photos
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(clubViewModel);
                }

            var photosResult = true;

            var club = new Club
            {
                Id = id,
                Title = clubViewModel.Title,
                Description = clubViewModel.Description,
                Image = clubViewModel.Image
            };

            if(!_clubInterface.Update(club))
            {
                ModelState.AddModelError("", "Failed to update club");
                return View("Edit", clubViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}

