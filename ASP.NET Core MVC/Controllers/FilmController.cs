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
    [Authorize(Roles = "admin, user")]
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

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("/add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        [Route("/add")]
        public async Task<IActionResult> Add(Film model)
        {
            if (ModelState.IsValid)
            {
                Film film = await db.Films
                    .FirstOrDefaultAsync(f => f.Title == model.Title
                                            && f.ReleaseYear == model.ReleaseYear
                                            && f.DurationMin == model.DurationMin
                                            && f.AgeCategory == model.AgeCategory
                                            && f.Rating == model.Rating
                                            && f.TrailerLink == model.TrailerLink
                                        );

                if (film == null)
                {
                    film = new Film
                    {
                        Id = model.Id,
                        Title = model.Title,
                        ReleaseYear = model.ReleaseYear,
                        DurationMin = model.DurationMin,
                        AgeCategory = model.AgeCategory,
                        Rating = model.Rating,
                        TrailerLink = model.TrailerLink
                    };

                    db.Films.Add(film);

                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Film");
                }

                ModelState.AddModelError(string.Empty, "Некорректные данные");

            }

            return View(model);
        }

        [Route("{globalId:int}/edit")]
        public async Task<IActionResult> Edit(int globalId)
        {
            var film = await db.Films.FirstOrDefaultAsync(u => u.Id == globalId);
            return View(film);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        [Route("{globalId:int}/edit")]
        public async Task<IActionResult> Edit(Film model, int globalId)
        {
            if (ModelState.IsValid)
            {
                Film film = await db.Films
                    .FirstOrDefaultAsync(f => f.Id == globalId
                                            && f.Title == model.Title
                                            && f.ReleaseYear == model.ReleaseYear
                                            && f.DurationMin == model.DurationMin
                                            && f.AgeCategory == model.AgeCategory
                                            && f.Rating == model.Rating
                                            && f.TrailerLink == model.TrailerLink
                                        );

                if (film == null)
                {
                    //film = await db.Films.FirstOrDefaultAsync(f => f.Id == globalId);
                    film = new Film
                    {
                        Id = globalId,
                        Title = model.Title,
                        ReleaseYear = model.ReleaseYear,
                        DurationMin = model.DurationMin,
                        AgeCategory = model.AgeCategory,
                        Rating = model.Rating,
                        TrailerLink = model.TrailerLink
                    };

                    db.Films.Update(film);

                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Film");
                }

                ModelState.AddModelError(string.Empty, "Некорректные данные");

            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [Route("{globalId:int}/delete")]
        public async Task<IActionResult> Delete(int globalId)
        {
            Film film = await db.Films
                .FirstOrDefaultAsync(f => f.Id == globalId);

            if (film != null)
            {
                db.Films.Remove(film);

                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Film");
            }

            return RedirectToAction("Index", "Film");
        }
        /*
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }*/
    }
}
