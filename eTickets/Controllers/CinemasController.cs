using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext appDbContext;
        public CinemasController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await appDbContext.TBL_PRODUCERS.ToListAsync();
            return View();
        }
    }
}
