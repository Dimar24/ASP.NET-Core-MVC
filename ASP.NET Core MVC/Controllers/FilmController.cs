using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        IWebHostEnvironment _appEnvironment;

        public FilmController(ILogger<FilmController> logger, ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            db = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> Add(Film model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                string pathFiles = "/Files/posters/" + uploadedFile.FileName;

                Film film = await db.Films
                    .FirstOrDefaultAsync(f => f.Title == model.Title
                                            && f.ReleaseYear == model.ReleaseYear
                                            && f.DurationMin == model.DurationMin
                                            && f.AgeCategory == model.AgeCategory
                                            && f.Rating == model.Rating
                                            && f.TrailerLink == model.TrailerLink
                                            && f.PathImage == pathFiles
                                        );

                if (film == null)
                {
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + pathFiles, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    film = new Film
                    {
                        Id = model.Id,
                        Title = model.Title,
                        PathImage = pathFiles,
                        ReleaseYear = model.ReleaseYear,
                        DurationMin = model.DurationMin,
                        AgeCategory = model.AgeCategory,
                        Rating = model.Rating,
                        TrailerLink = model.TrailerLink,
                        Hiden = model.Hiden
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
        public async Task<IActionResult> Edit(Film model, int globalId, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                Film film = await db.Films.AsNoTracking()
                    .FirstOrDefaultAsync(f => f.Id == globalId);
                string pathFiles = film.PathImage;

                film = await db.Films.AsNoTracking()
                    .FirstOrDefaultAsync(f => f.Id == globalId
                                            && f.Title == model.Title
                                            && f.ReleaseYear == model.ReleaseYear
                                            && f.DurationMin == model.DurationMin
                                            && f.AgeCategory == model.AgeCategory
                                            && f.Rating == model.Rating
                                            && f.TrailerLink == model.TrailerLink
                                            && f.Hiden == model.Hiden
                                        );
                
                if (film == null || uploadedFile != null)
                {
                    if(uploadedFile != null)
                    {
                        if (pathFiles != null) { 
                            pathFiles = _appEnvironment.WebRootPath + pathFiles;
                            System.IO.File.Delete(pathFiles);
                        }
                        pathFiles = "/Files/posters/" + uploadedFile.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + pathFiles, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                    }

                    film = new Film
                    {
                        Id = globalId,
                        Title = model.Title,
                        ReleaseYear = model.ReleaseYear,
                        DurationMin = model.DurationMin,
                        AgeCategory = model.AgeCategory,
                        Rating = model.Rating,
                        TrailerLink = model.TrailerLink,
                        Hiden = model.Hiden,
                        PathImage = pathFiles
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

        [Authorize(Roles = "admin")]
        [Route("{globalId:int}/hiden")]
        public async Task<IActionResult> Hiden(int globalId)
        {
            Film film = await db.Films.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == globalId);
            
            if (film != null)
            {
                film.Hiden = !film.Hiden;

                db.Films.Update(film);

                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Film");
            }
            
            return RedirectToAction("Index", "Film");
        }
    }
}
