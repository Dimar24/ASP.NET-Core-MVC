using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Core_MVC.Controllers
{
    [Authorize]
    [Route("films")]
    public class FilmController : Controller
    {
        private ApplicationContext db;
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var films = await db.Films.ToListAsync();
            return View(films);
        }

        [Route("{globalId:int}/info")]
        public async Task<IActionResult> Info(int globalId)
        {
            var film = await db.Films.FirstOrDefaultAsync(u => u.Id == globalId);
            //var film;
            return View(film);
        }
    }
}
