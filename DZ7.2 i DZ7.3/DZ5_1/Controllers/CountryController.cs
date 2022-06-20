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
    public class CountryController : Controller
    {
        private readonly movieContext _context;

        public CountryController(movieContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string country_id)
        {
            if (country_id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.country_id == country_id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: /Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("country_id,country_iso_code,country_name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Edit/5
        public async Task<IActionResult> Edit(int country_id)
        {
            if (country_id == null)
            {
                return NotFound();
            }

            var country_id = await _context.Country.FindAsync(country_id);
            if (country_id == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: /Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string country_id, [Bind("country_id,country_iso_code,country_name")] Country country)
        {
            if (country_id != country.country_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.country_id))
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
            return View(country);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string country_id)
        {
            if (country_id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.country_id == country_id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int country_id)
        {
            var product = await _context.Country.FindAsync(country_id);
            _context.Country.Remove(country_id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int country_id)
        {
            return _context.Country.Any(e => e.country_id == country_id);
        }
    }
}
