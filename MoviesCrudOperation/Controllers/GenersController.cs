using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesCrudOperation.Models;

namespace MoviesCrudOperation.Controllers
{
    public class GenersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Geners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Geners.ToListAsync());
        }

        // GET: Geners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gener = await _context.Geners
                .FirstOrDefaultAsync(m => m.GenerId == id);
            if (gener == null)
            {
                return NotFound();
            }

            return View(gener);
        }

        // GET: Geners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Geners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenerId,Name")] Gener gener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gener);
        }

        // GET: Geners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gener = await _context.Geners.FindAsync(id);
            if (gener == null)
            {
                return NotFound();
            }
            return View(gener);
        }

        // POST: Geners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenerId,Name")] Gener gener)
        {
            if (id != gener.GenerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenerExists(gener.GenerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gener);
        }

        // GET: Geners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gener = await _context.Geners
                .FirstOrDefaultAsync(m => m.GenerId == id);
            if (gener == null)
            {
                return NotFound();
            }

            return View(gener);
        }

        // POST: Geners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gener = await _context.Geners.FindAsync(id);
            var MoviesInGener=_context.Movies.Where(a => a.GenerId == id).ToList();
            foreach (var movie in MoviesInGener)
            {
                _context.Movies.Remove(movie);
            }
            _context.Geners.Remove(gener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenerExists(int id)
        {
            return _context.Geners.Any(e => e.GenerId == id);
        }
    }
}
