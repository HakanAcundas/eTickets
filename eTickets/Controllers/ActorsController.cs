﻿using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private AppDbContext appDbContext;
        public ActorsController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        
        public ActionResult Index()
        {
            var data = appDbContext.TBL_ACTORS.ToList();
            return View(data);
        }

        //Get: Actors/CreateActor
        public async Task<IActionResult> CreateActor()
        {
            return View();
        }
    }
}
