using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class TaxAreaCodesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public TaxAreaCodesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/TaxAreaCodes
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.TaxAreaCodes.Include(t => t.Country);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Finance/TaxAreaCodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxAreaCode = await _context.TaxAreaCodes
                .Include(t => t.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxAreaCode == null)
            {
                return NotFound();
            }

            return View(taxAreaCode);
        }

        // GET: Finance/TaxAreaCodes/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Code");
            return View();
        }

        // POST: Finance/TaxAreaCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,CountryId")] TaxAreaCode taxAreaCode)
        {
            ModelState.Remove("Country");
            if (ModelState.IsValid)
            {
                taxAreaCode.Id = Guid.NewGuid();
                _context.Add(taxAreaCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Code", taxAreaCode.CountryId);
            return View(taxAreaCode);
        }

        // GET: Finance/TaxAreaCodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxAreaCode = await _context.TaxAreaCodes.FindAsync(id);
            if (taxAreaCode == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Code", taxAreaCode.CountryId);
            return View(taxAreaCode);
        }

        // POST: Finance/TaxAreaCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description,CountryId")] TaxAreaCode taxAreaCode)
        {
            if (id != taxAreaCode.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Country");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxAreaCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxAreaCodeExists(taxAreaCode.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Code", taxAreaCode.CountryId);
            return View(taxAreaCode);
        }

        // GET: Finance/TaxAreaCodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxAreaCode = await _context.TaxAreaCodes
                .Include(t => t.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxAreaCode == null)
            {
                return NotFound();
            }

            return View(taxAreaCode);
        }

        // POST: Finance/TaxAreaCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var taxAreaCode = await _context.TaxAreaCodes.FindAsync(id);
            if (taxAreaCode != null)
            {
                _context.TaxAreaCodes.Remove(taxAreaCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxAreaCodeExists(Guid id)
        {
            return _context.TaxAreaCodes.Any(e => e.Id == id);
        }
    }
}
