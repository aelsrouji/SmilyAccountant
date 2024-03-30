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
                          View(await _context.GeneralJournals.Where(p => p.IsPosted == false)
                          //Include(f => f.FixedAssetCards)
                          .Include(c => c.Currency).
                          Include(f => f.GLAccountCard).ToListAsync())
                          :
                          Problem("Entity set 'SmilyAccountantContext.GeneralJournals'  is null.");
        }

        public async Task<IActionResult> PostedRecords()
        {
            return _context.GeneralJournals != null ?
                        View(await _context.GeneralJournals.Where(p => p.IsPosted == true)
                        //Include(f => f.FixedAssetCards)
                        .Include(c => c.Currency)
                        .Include(f => f.GLAccountCard).ToListAsync())
                        :
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
                Include(f => f.GLAccountCards)
                .Include(c => c.Currencies)
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
            //ViewData["FixedAssetCards"] = new SelectList(_context.FixedAssetCards, "FixedAssetCardId", "Description");
            ViewData["GLAccountCards"] = new SelectList(_context.GLAccountCards, "Id", "AccountName");
            ViewData["Currencies"] = new SelectList(_context.Currencies, "Id", "Name");

            return View();
        }

        // POST: Finance/GeneralJournals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostingDate,DocumentType,DocumentNumber,GLAccountCardId,Description,CurrencyId,GeneralPostingType,Amount,AmountWithTax,Comment")] GeneralJournalViewModel generalJournalViewModel)
        {
            if (ModelState.IsValid)
            {
                var generalJournal = new GeneralJournal
                {
                    Id = Guid.NewGuid(),
                    PostingDate = generalJournalViewModel.PostingDate,
                    DocumentType = generalJournalViewModel.DocumentType,
                    DocumentNumber = generalJournalViewModel.DocumentNumber,
                    //FixedAssetCardId = generalJournalViewModel.FixedAssetCardId,
                    GLAccountCardId = generalJournalViewModel.GLAccountCardId,
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

            //ViewData["FixedAssetCards"] = new SelectList(_context.FixedAssetCards, "FixedAssetCardId", "Description");
            ViewData["GLAccountCards"] = new SelectList(_context.GLAccountCards, "Id", "AccountName");
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PostingDate,DocumentType,DocumentNumber,GLAccountCardId,Description,CurrencyId,GeneralPostingType,Amount,AmountWithTax,Comment")] GeneralJournal generalJournal)
        {
            if (id != generalJournal.Id)
            {
                return NotFound();
            }

            //ModelState.Remove("FixedAssetCard");
            ModelState.Remove("GLAccountCard");
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

            ViewData["GLAccountCards"] = new SelectList(_context.GLAccountCards, "Id", "AccountName");
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


        [HttpPost, ActionName("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post()
        {
            if (_context.GeneralJournals == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.GeneralJournals'  is null");
            }
            var unpostedGJ = _context.GeneralJournals.Where(p => p.IsPosted == false).ToList();

            // initial ChartOfAccount table with new records if not existing
            foreach (var item in unpostedGJ)
            {
                var chartOfAccount = GetChartOfAccountByGLAccountCardId(item.GLAccountCardId).Result;
                if (chartOfAccount == null)
                {
                    _context.ChartOfAccounts.Add(new ChartOfAccount
                    {
                        Id = new Guid(),
                        GLAccountCardId = item.GLAccountCardId,
                        NetChange = 0,
                        NetBalanace = 0
                    });
                    _context.SaveChangesAsync().Wait();
                }
            }

            foreach (var item in unpostedGJ)
            {
                item.IsPosted = true;
                _context.Update(item);

                // updating Chart of Accounts table
                // this should be enhanced to reduce updates
                var chartOfAccount = GetChartOfAccountByGLAccountCardId(item.GLAccountCardId).Result;
                if (chartOfAccount != null) // it should not be null
                //{
                //    _context.ChartOfAccounts.Add(new ChartOfAccount
                //    {
                //        Id = new Guid(),
                //        GLAccountCardId = item.GLAccountCardId,
                //        NetChange = GetNetChange(item),
                //        NetBalanace = GetNetBalance(item)//what is the difference between net balance and net change?
                //    }); 
                //}
                //else
                {
                    chartOfAccount.NetChange = GetNetChange(item);
                    chartOfAccount.NetBalanace = GetNetBalance(item);
                    _context.Update(chartOfAccount);
                }

            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private decimal GetNetBalance(GeneralJournal generalJournal)
        {
            var chartOfAccount = GetChartOfAccountByGLAccountCardId(generalJournal.GLAccountCardId).Result;
            decimal netBalance;
            if (chartOfAccount != null)
            {
                netBalance = chartOfAccount.NetBalanace + generalJournal.Amount;
            }
            else
            {
                netBalance = generalJournal.Amount;
            }
            return netBalance;

        }

        private decimal GetNetChange(GeneralJournal generalJournal)
        {
            var chartOfAccount = GetChartOfAccountByGLAccountCardId(generalJournal.GLAccountCardId).Result;
            decimal netChange;
            if (chartOfAccount != null)
            {
                netChange = chartOfAccount.NetChange + generalJournal.Amount;
            }
            else
            {
                netChange = generalJournal.Amount;
            }
            return netChange;

        }

        private async Task<ChartOfAccount> GetChartOfAccountByGLAccountCardId(Guid id)
        {
            return await _context.ChartOfAccounts.FirstOrDefaultAsync(p => p.GLAccountCardId == id);
        }
    }
}
