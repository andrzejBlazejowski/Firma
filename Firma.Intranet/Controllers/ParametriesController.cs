using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class ParametriesController : Controller
    {
        private readonly FirmaContext _context;

        public ParametriesController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Parametries
        public async Task<IActionResult> Index()
        {
              return _context.Parametr != null ? 
                          View(await _context.Parametr.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Parametr'  is null.");
        }

        // GET: Parametries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parametr == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parametry == null)
            {
                return NotFound();
            }

            return View(parametry);
        }

        // GET: Parametries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parametries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Wartosc,Opis")] Parametry parametry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametry);
        }

        // GET: Parametries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parametr == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametr.FindAsync(id);
            if (parametry == null)
            {
                return NotFound();
            }
            return View(parametry);
        }

        // POST: Parametries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Wartosc,Opis")] Parametry parametry)
        {
            if (id != parametry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametryExists(parametry.Id))
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
            return View(parametry);
        }

        // GET: Parametries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parametr == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parametry == null)
            {
                return NotFound();
            }

            return View(parametry);
        }

        // POST: Parametries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parametr == null)
            {
                return Problem("Entity set 'FirmaContext.Parametr'  is null.");
            }
            var parametry = await _context.Parametr.FindAsync(id);
            if (parametry != null)
            {
                _context.Parametr.Remove(parametry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametryExists(int id)
        {
          return (_context.Parametr?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
