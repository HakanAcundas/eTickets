using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ProducersController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await appDbContext.TBL_PRODUCERS.ToListAsync();
            return View(allProducers);
        }
    }
}
