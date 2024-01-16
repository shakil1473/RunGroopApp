
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;

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
    }
}

