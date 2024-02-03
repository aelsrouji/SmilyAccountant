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
    public class FASubClassCodesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public FASubClassCodesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/FASubClassCodes
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.FASubClassCodes.Include(f => f.FAClassCode);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Finance/FASubClassCodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FASubClassCodes == null)
            {
                return NotFound();
            }

            var fASubClassCode = await _context.FASubClassCodes
                .Include(f => f.FAClassCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fASubClassCode == null)
            {
                return NotFound();
            }

            return View(fASubClassCode);
        }

        // GET: Finance/FASubClassCodes/Create
        public IActionResult Create()
        {
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name");
            return View();
        }

        // POST: Finance/FASubClassCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FAClassCodeId,Code,Name")] FASubClassCode fASubClassCode)
        {
            ModelState.Remove("FAClassCode");

            if (ModelState.IsValid)
            {
                fASubClassCode.Id = Guid.NewGuid();
                _context.Add(fASubClassCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fASubClassCode.FAClassCodeId);
            return View(fASubClassCode);
        }

        // GET: Finance/FASubClassCodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FASubClassCodes == null)
            {
                return NotFound();
            }

            var fASubClassCode = await _context.FASubClassCodes.FindAsync(id);
            if (fASubClassCode == null)
            {
                return NotFound();
            }
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fASubClassCode.FAClassCodeId);
            return View(fASubClassCode);
        }

        // POST: Finance/FASubClassCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FAClassCodeId,Code,Name")] FASubClassCode fASubClassCode)
        {
            if (id != fASubClassCode.Id)
            {
                return NotFound();
            }
            ModelState.Remove("FAClassCode");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fASubClassCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FASubClassCodeExists(fASubClassCode.Id))
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
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fASubClassCode.FAClassCodeId);
            return View(fASubClassCode);
        }

        // GET: Finance/FASubClassCodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FASubClassCodes == null)
            {
                return NotFound();
            }

            var fASubClassCode = await _context.FASubClassCodes
                .Include(f => f.FAClassCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fASubClassCode == null)
            {
                return NotFound();
            }

            return View(fASubClassCode);
        }

        // POST: Finance/FASubClassCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FASubClassCodes == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.FASubClassCodes'  is null.");
            }
            var fASubClassCode = await _context.FASubClassCodes.FindAsync(id);
            if (fASubClassCode != null)
            {
                _context.FASubClassCodes.Remove(fASubClassCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FASubClassCodeExists(Guid id)
        {
          return (_context.FASubClassCodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
