using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace MoviesCrudOperation.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movies = new Movie
            {
                Geners = await _context.Geners.OrderBy(a => a.Name).ToListAsync()
            };
            return View(movies);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            var files = Request.Form.Files;

            if (files.Any())
            {
                var imgFolderName = Path.Combine("wwwroot", "images", "poster");
                var imgPathToSave = Path.Combine(Directory.GetCurrentDirectory(), imgFolderName);

                var videoFolderName = Path.Combine("wwwroot", "Videos", "Trailer");
                var videoPathToSave = Path.Combine(Directory.GetCurrentDirectory(), videoFolderName);

                string fullPath="";

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var ex = Path.GetExtension(fileName);

                    if (ex==".png"||ex==".jpg")
                    {
                        fullPath = Path.Combine(imgPathToSave, fileName);
                        movie.Poster = fileName;
                    }
                    else if (ex==".mp4")
                    {
                        fullPath = Path.Combine(videoPathToSave, fileName);
                        movie.Trailer = fileName;
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            _context.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Movie movie= _context.Movies.Find(id);

            var imgFolderName = Path.Combine("wwwroot", "images", "poster");
            var imgPathToSave = Path.Combine(Directory.GetCurrentDirectory(), imgFolderName);
            var Image = Path.Combine(imgPathToSave, movie.Poster);

            var videoFolderName = Path.Combine("wwwroot", "Videos", "Trailer");
            var videoPathToSave = Path.Combine(Directory.GetCurrentDirectory(), videoFolderName);
            var Video = Path.Combine(videoPathToSave, movie.Trailer);


            if (System.IO.File.Exists(Image)&&System.IO.File.Exists(Video))
            {
                 System.IO.File.Delete(Image);
                 System.IO.File.Delete(Video);
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Movie movie = _context.Movies.Find(id);
            movie.Geners = await _context.Geners.OrderBy(a => a.Name).ToListAsync();
            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            var movieId = await _context.Movies.FindAsync(movie.MovieId);

            var files = Request.Form.Files;


            if (files.Any())
            {
                var imgFolderName = Path.Combine("wwwroot", "images", "poster");
                var imgPathToSave = Path.Combine(Directory.GetCurrentDirectory(), imgFolderName);

                var videoFolderName = Path.Combine("wwwroot", "Videos", "Trailer");
                var videoPathToSave = Path.Combine(Directory.GetCurrentDirectory(), videoFolderName);

                string fullPath = "";

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var ex = Path.GetExtension(fileName);

                    if (ex == ".png" || ex == ".jpg")
                    {
                        fullPath = Path.Combine(imgPathToSave, fileName);
                        movieId.Poster = fileName;
                    }
                    else if (ex == ".mp4")
                    {
                        fullPath = Path.Combine(videoPathToSave, fileName);
                        movieId.Trailer = fileName;
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

            }
            else
            {
                movie.Poster = movieId.Poster;
                movie.Trailer = movieId.Trailer;
            }

            movieId.Title = movie.Title;
            movieId.Story = movie.Story;
            movieId.GenerId = movie.GenerId;
            movieId.Year = movie.Year;
            movieId.Rate = movie.Rate;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            Movie movie = _context.Movies.Find(id);

            var GenerId = _context.Movies.Find(id).GenerId;
            ViewBag.Gener = _context.Geners.Find(GenerId).Name;
            return View(movie);
        }

    }
}
