using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroop.Data;
using RunGroop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunGroop.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ClubController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var clubs = _applicationDbContext.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Detail(int id)
        {
            Club club = _applicationDbContext.Clubs.FirstOrDefault(c => c.Id == id);

            /*
             * _applicationDbContext.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
             * When one model has another model as properties we need to use include
             * Include actually doing the join
             */

            return View(club);
        }
    }
}

