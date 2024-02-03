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
    public class FAClassCodesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public FAClassCodesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/FAClassCodes
        public async Task<IActionResult> Index()
        {
              return _context.FAClassCodes != null ? 
                          View(await _context.FAClassCodes.ToListAsync()) :
                          Problem("Entity set 'SmilyAccountantContext.FAClassCodes'  is null.");
        }

        // GET: Finance/FAClassCodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FAClassCodes == null)
            {
                return NotFound();
            }

            var fAClassCode = await _context.FAClassCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAClassCode == null)
            {
                return NotFound();
            }

            return View(fAClassCode);
        }

        // GET: Finance/FAClassCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/FAClassCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name")] FAClassCode fAClassCode)
        {
            if (ModelState.IsValid)
            {
                fAClassCode.Id = Guid.NewGuid();
                _context.Add(fAClassCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAClassCode);
        }

        // GET: Finance/FAClassCodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FAClassCodes == null)
            {
                return NotFound();
            }

            var fAClassCode = await _context.FAClassCodes.FindAsync(id);
            if (fAClassCode == null)
            {
                return NotFound();
            }
            return View(fAClassCode);
        }

        // POST: Finance/FAClassCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Name")] FAClassCode fAClassCode)
        {
            if (id != fAClassCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAClassCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAClassCodeExists(fAClassCode.Id))
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
            return View(fAClassCode);
        }

        // GET: Finance/FAClassCodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FAClassCodes == null)
            {
                return NotFound();
            }

            var fAClassCode = await _context.FAClassCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAClassCode == null)
            {
                return NotFound();
            }

            return View(fAClassCode);
        }

        // POST: Finance/FAClassCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FAClassCodes == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.FAClassCodes'  is null.");
            }
            var fAClassCode = await _context.FAClassCodes.FindAsync(id);
            if (fAClassCode != null)
            {
                _context.FAClassCodes.Remove(fAClassCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAClassCodeExists(Guid id)
        {
          return (_context.FAClassCodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
