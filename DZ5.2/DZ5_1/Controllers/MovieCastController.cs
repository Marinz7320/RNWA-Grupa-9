using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DZ5_1.Models;

namespace DZ5_1.Controllers
{
    public class MovieCastController : Controller
    {
        private readonly movieContext _context;

        public OrderdetailsController(movieContext context)
        {
            _context = context;
        }

        // GET: MovieCast
        public async Task<IActionResult> Index()
        {
            var birtContext = _context.Orderdetails.Include(o => o.OrderNumberNavigation).Include(o => o.ProductCodeNavigation);
            return View(await birtContext.ToListAsync());
        }

        // GET: Orderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_cast = await _context.Orderdetails
                .Include(o => o.OrderNumberNavigation)
                .Include(o => o.ProductCodeNavigation)
                .FirstOrDefaultAsync(m => m.OrderNumber == id);
            if (movie_cast == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // GET: moviecast/Create
        public IActionResult Create()
        {
            ViewData["movie_id"] = new SelectList(_context.movieIDs, "movie_id", "Status");
            ViewData["person_id"] = new SelectList(_context.PersonIDs, "person_id", "person_id");
            return View();
        }

        // POST: Orderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("movie_id,person_id,character_name,gender_id,cast_order")] MovieCast movie_cast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["movie_id"] = new SelectList(_context.movieIDs, "movie_id", "Status", movie_cast.movie_id);
            ViewData["person_id"] = new SelectList(_context.personIDs, "person_id", "person_id", movie_cast.person_id);
            return View(movie_cast);
        }

        // GET: MovieCast/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_cast = await _context.MovieCast.FindAsync(id);
            if (movie_cast == null)
            {
                return NotFound();
            }
            ViewData["movie_id"] = new SelectList(_context.Orders, "movie_id", "Status", movie_cast.movie_id);
            ViewData["person_id"] = new SelectList(_context.Products, "person_id", "person_id",movie_cast.person_id);
            return View(movie_id);
        }

        // POST: MovieCast/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("movie_id,person_id,character_name,gender_id,cast_order")]MovieCast movie_cast)
        {
            if (id != movie_cast.movie_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie_cast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCastExists(movie_cast.movie_id))
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
            ViewData["movie_id"] = new SelectList(_context.Orders, "movie_id", "Status", orderdetail.OrderNumber);
            ViewData["ProductCode"] = new SelectList(_context.Products, "ProductCode", "ProductCode", orderdetail.ProductCode);
            return View(orderdetail);
        }

        // GET: Orderdetails/Delete/5
        public async Task<IActionResult> Delete(int? movie_id)
        {
            if (movie_id == null)
            {
                return NotFound();
            }

            var movie_cast = await _context.movieContext
                .Include(o => o.MovieIDNavigation)
                .Include(o => o.PersonIDNavigation)
                .FirstOrDefaultAsync(m => m.MovieID == movie_id);
            if (movie_Cast == null)
            {
                return NotFound();
            }

            return View(movie_id);
        }

        // POST: Orderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie_ = await _context.movieContext.FindAsync(id);
            _context.movieContext.Remove(movie_Cast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCastExists(int movie_id)
        {
            return _context.movieContext.Any(e => e.MovieID == movie_id);
        }
    }
}
