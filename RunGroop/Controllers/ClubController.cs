﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Data;

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
    }
}
