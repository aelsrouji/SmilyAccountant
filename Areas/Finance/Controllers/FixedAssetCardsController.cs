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
    public class FixedAssetCardsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public FixedAssetCardsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/FixedAssetCards
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.FixedAssetCards.Include(f => f.FAClassCode).Include(f => f.FASubClassCode).Include(f => f.Employee);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Finance/FixedAssetCards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FixedAssetCards == null)
            {
                return NotFound();
            }

            var fixedAssetCard = await _context.FixedAssetCards
                .Include(f => f.FAClassCode)
                .Include(f => f.FASubClassCode)
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FixedAssetCardId == id);
            if (fixedAssetCard == null)
            {
                return NotFound();
            }

            return View(fixedAssetCard);
        }

        // GET: Finance/FixedAssetCards/Create
        public IActionResult Create()
        {
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name");
            ViewData["FASubClassCodeId"] = new SelectList(_context.FASubClassCodes, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName");
            return View();
        }

        // POST: Finance/FixedAssetCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixedAssetCardId,Description,FAClassCodeId,FASubClassCodeId,SerialNumber,EmployeeId,DepreciationStartingDate,NoOfDepreciataionYears,DepreciationEndingDate,BookValue")] FixedAssetCard fixedAssetCard)
        {
            ModelState.Remove("FAClassCode");
            ModelState.Remove("FASubClassCode");
            ModelState.Remove("Employee");

            if (ModelState.IsValid)
            {
                fixedAssetCard.FixedAssetCardId = Guid.NewGuid();
                _context.Add(fixedAssetCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fixedAssetCard.FAClassCodeId);
            ViewData["FASubClassCodeId"] = new SelectList(_context.FASubClassCodes, "Id", "Name", fixedAssetCard.FASubClassCodeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", fixedAssetCard.EmployeeId);

            return View(fixedAssetCard);
        }

        // GET: Finance/FixedAssetCards/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FixedAssetCards == null)
            {
                return NotFound();
            }

            var fixedAssetCard = await _context.FixedAssetCards.FindAsync(id);
            if (fixedAssetCard == null)
            {
                return NotFound();
            }
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fixedAssetCard.FAClassCodeId);
            ViewData["FASubClassCodeId"] = new SelectList(_context.FASubClassCodes, "Id", "Name", fixedAssetCard.FASubClassCodeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", fixedAssetCard.EmployeeId);

            return View(fixedAssetCard);
        }

        // POST: Finance/FixedAssetCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FixedAssetCardId,Description,FAClassCodeId,FASubClassCodeId,SerialNumber,EmployeeId,DepreciationStartingDate,NoOfDepreciataionYears,DepreciationEndingDate,BookValue")] FixedAssetCard fixedAssetCard)
        {
            if (id != fixedAssetCard.FixedAssetCardId)
            {
                return NotFound();
            }

            ModelState.Remove("FAClassCode");
            ModelState.Remove("FASubClassCode");
            ModelState.Remove("Employee");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixedAssetCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixedAssetCardExists(fixedAssetCard.FixedAssetCardId))
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
            ViewData["FAClassCodeId"] = new SelectList(_context.FAClassCodes, "Id", "Name", fixedAssetCard.FAClassCodeId);
            ViewData["FASubClassCodeId"] = new SelectList(_context.FASubClassCodes, "Id", "Name", fixedAssetCard.FASubClassCodeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", fixedAssetCard.EmployeeId);

            return View(fixedAssetCard);
        }

        // GET: Finance/FixedAssetCards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FixedAssetCards == null)
            {
                return NotFound();
            }

            var fixedAssetCard = await _context.FixedAssetCards
                .Include(f => f.FAClassCode)
                .Include(f => f.FASubClassCode)
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FixedAssetCardId == id);
            if (fixedAssetCard == null)
            {
                return NotFound();
            }

            return View(fixedAssetCard);
        }

        // POST: Finance/FixedAssetCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FixedAssetCards == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.FixedAssetCards'  is null.");
            }
            var fixedAssetCard = await _context.FixedAssetCards.FindAsync(id);
            if (fixedAssetCard != null)
            {
                _context.FixedAssetCards.Remove(fixedAssetCard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixedAssetCardExists(Guid id)
        {
          return (_context.FixedAssetCards?.Any(e => e.FixedAssetCardId == id)).GetValueOrDefault();
        }
    }
}
