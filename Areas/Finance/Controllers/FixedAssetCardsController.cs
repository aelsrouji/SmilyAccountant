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
              return _context.FixedAssetCards != null ? 
                          View(await _context.FixedAssetCards.ToListAsync()) :
                          Problem("Entity set 'SmilyAccountantContext.FixedAssetCards'  is null.");
        }

        // GET: Finance/FixedAssetCards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FixedAssetCards == null)
            {
                return NotFound();
            }

            var fixedAssetCard = await _context.FixedAssetCards
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
            return View();
        }

        // POST: Finance/FixedAssetCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixedAssetCardId,Description,FAClassCodeId,FASubClassCodeId,SerialNumber,EmployeeId")] FixedAssetCard fixedAssetCard)
        {
            if (ModelState.IsValid)
            {
                fixedAssetCard.FixedAssetCardId = Guid.NewGuid();
                _context.Add(fixedAssetCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(fixedAssetCard);
        }

        // POST: Finance/FixedAssetCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FixedAssetCardId,Description,FAClassCodeId,FASubClassCodeId,SerialNumber,EmployeeId")] FixedAssetCard fixedAssetCard)
        {
            if (id != fixedAssetCard.FixedAssetCardId)
            {
                return NotFound();
            }

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
