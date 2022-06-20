using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AA_2.Models;

namespace AA_2.Controllers
{
    public class MovieController : Controller
    {
        private readonly movieContext _context;

        public MovieController(movieContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? movie_id)
        {
            if (movie_id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieID == movie_id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("movie_id,title,budget,homepage,overview,popularity,release_date,revenue,runtime,movie_status,tagline,vote_average,vote_count")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: /Edit/5
        public async Task<IActionResult> Edit(int? movie_id)
        {
            if (movie_id == null)
            {
                return NotFound();
            }

            var order = await _context.Movie.FindAsync(movie_id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: /Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int movie_id, [Bind("movie_id,title,budget,homepage,overview,popularity,release_date,revenue,runtime,movie_status,tagline,vote_average,vote_count")] Movie movie)
        {
            if (movie_id != movie.movie_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie.movie_id);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.movie_id))
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
            return View(movie);
        }

        // GET: O/Delete/5
        public async Task<IActionResult> Delete(int? movie_id)
        {
            if (movie_id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.movie_id == movie_id);
            if (movie_id == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int movie_id)
        {
            var order = await _context.Movie.FindAsync(movie_id);
            _context.Movie.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int movie_id)
        {
            return _context.Movie.Any(e => e.movie_id == movie_id);
        }
    }
}
