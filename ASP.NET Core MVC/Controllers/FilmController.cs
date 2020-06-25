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

    public class FilmController : Controller
    {
        private ApplicationContext db;
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        [Route("films")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var films = await db.Films.ToListAsync();
            return View(films);
        }
    }
}
