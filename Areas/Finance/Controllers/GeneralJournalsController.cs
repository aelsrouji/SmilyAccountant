using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Areas.Finance.Models.ViewModels;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class GeneralJournalsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public GeneralJournalsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/GeneralJournals
        public async Task<IActionResult> Index()
        {
              return _context.GeneralJournals != null ? 
                          View(await _context.GeneralJournals.
                          Include(f => f.FixedAssetCards).Include(c => c.Currencies).ToListAsync()) :
                          Problem("Entity set 'SmilyAccountantContext.GeneralJournals'  is null.");
        }

        // GET: Finance/GeneralJournals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.GeneralJournals == null)
            {
                return NotFound();
            }

            var generalJournal = await _context.GeneralJournals.
                Include(f => f.FixedAssetCards).Include(c => c.Currencies)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalJournal == null)
            {
                return NotFound();
            }

            return View(generalJournal);
        }

        // GET: Finance/GeneralJournals/Create
        public IActionResult Create()
        {
            ViewData["FixedAssetCards"] = new SelectList(_context.FixedAssetCards, "FixedAssetCardId", "Description");
            ViewData["Currencies"] = new SelectList(_context.Currencies, "Id", "Name");

            return View();
        }

        // POST: Finance/GeneralJournals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostingDate,DocumentType,DocumentNumber,FixedAssetCardId,Description,CurrencyId,GeneralPostingType,Amount,AmountWithTax,Comment")] GeneralJournalViewModel generalJournalViewModel)
        {
            if (ModelState.IsValid)
            {
                var generalJournal = new GeneralJournal
                {
                    Id = Guid.NewGuid(),
                    PostingDate = generalJournalViewModel.PostingDate,
                    DocumentType = generalJournalViewModel.DocumentType,
                    DocumentNumber = generalJournalViewModel.DocumentNumber,
                    FixedAssetCardId = generalJournalViewModel.FixedAssetCardId,
                    Description = generalJournalViewModel.Description,
                    CurrencyId = generalJournalViewModel.CurrencyId,
                    GeneralPostingType = generalJournalViewModel.GeneralPostingType,
                    Amount = generalJournalViewModel.Amount,
                    AmountWithTax = generalJournalViewModel.AmountWithTax,
                    Comment = generalJournalViewModel.Comment
                };
                 
                _context.Add(generalJournal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalJournalViewModel);
        }

        // GET: Finance/GeneralJournals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.GeneralJournals == null)
            {
                return NotFound();
            }

            ViewData["FixedAssetCards"] = new SelectList(_context.FixedAssetCards, "FixedAssetCardId", "Description");
            ViewData["Currencies"] = new SelectList(_context.Currencies, "Id", "Name");

            var generalJournal = await _context.GeneralJournals.FindAsync(id);
            if (generalJournal == null)
            {
                return NotFound();
            }
            return View(generalJournal);
        }

        // POST: Finance/GeneralJournals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PostingDate,DocumentType,DocumentNumber,FixedAssetCardId,Description,CurrencyId,GeneralPostingType,Amount,AmountWithTax,Comment")] GeneralJournal generalJournal)
        {
            if (id != generalJournal.Id)
            {
                return NotFound();
            }

            ModelState.Remove("FixedAssetCard");
            ModelState.Remove("Currency");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalJournal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralJournalExists(generalJournal.Id))
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

            ViewData["FixedAssetCards"] = new SelectList(_context.FixedAssetCards, "FixedAssetCardId", "Description");
            ViewData["Currencies"] = new SelectList(_context.Currencies, "Id", "Name");

            return View(generalJournal);
        }

        // GET: Finance/GeneralJournals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.GeneralJournals == null)
            {
                return NotFound();
            }

            var generalJournal = await _context.GeneralJournals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalJournal == null)
            {
                return NotFound();
            }

            return View(generalJournal);
        }

        // POST: Finance/GeneralJournals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.GeneralJournals == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.GeneralJournals'  is null.");
            }
            var generalJournal = await _context.GeneralJournals.FindAsync(id);
            if (generalJournal != null)
            {
                _context.GeneralJournals.Remove(generalJournal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralJournalExists(Guid id)
        {
          return (_context.GeneralJournals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
