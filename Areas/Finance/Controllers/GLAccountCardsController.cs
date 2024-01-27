using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Areas.Finance.Models.ViewModels;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class GLAccountCardsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public GLAccountCardsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GLAccountCards
        public async Task<IActionResult> Index()
        {
            return _context.GLAccountCards != null ?
                        View(await _context.GLAccountCards.
                        Include("AccountCategory").Include("AccountSubCategory").Include("AccountType").ToListAsync()) :
                        Problem("Entity set 'SmilyAccountantContext.GLAccountCards'  is null.");
        }

        // GET: GLAccountCards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards
                       .Include("AccountCategory")
                .Include("AccountSubCategory")
                .Include("AccountType")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }

            return View(gLAccountCard);
        }

        // GET: GLAccountCards/Create
        public IActionResult Create()
        {
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name");
            ViewData["AccountSubCategoryId"] = new SelectList(_context.AccountSubCategories, "Id", "Name");
            ViewData["AccountTypeId"] = new SelectList(_context.AccountTypes, "Id", "Name");
            return View();
        }

        // POST: GLAccountCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountNo,AccountName,Balance,AccountCategoryId,AccountSubCategoryId,DebitCredit,AccountTypeId")] GLAccountCardViewModel gLAccountCardViewModel)
        {
            if (ModelState.IsValid)
            {
                var gLAccountCard = new GLAccountCard
                {
                    Id = Guid.NewGuid(),
                    AccountName = gLAccountCardViewModel.AccountName,
                    AccountCategoryId = gLAccountCardViewModel.AccountCategoryId,
                    AccountSubCategoryId = gLAccountCardViewModel.AccountSubCategoryId,
                    AccountTypeId = gLAccountCardViewModel.AccountTypeId,
                    AccountNo = gLAccountCardViewModel.AccountNo,
                    Balance = gLAccountCardViewModel.Balance,
                    DebitCredit = gLAccountCardViewModel.DebitCredit
                };

                _context.Add(gLAccountCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name");
            ViewData["AccountSubCategoryId"] = new SelectList(_context.AccountSubCategories, "Id", "Name");
            ViewData["AccountTypeId"] = new SelectList(_context.AccountTypes, "Id", "Name");

            return View(gLAccountCardViewModel);
        }

        // GET: GLAccountCards/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards.FindAsync(id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }

            var gLAccountCardViewModel = new GLAccountCardViewModel
            {
                Id = Guid.NewGuid(),
                AccountName = gLAccountCard.AccountName,
                AccountCategoryId = gLAccountCard.AccountCategoryId,
                AccountSubCategoryId = gLAccountCard.AccountSubCategoryId,
                AccountTypeId = gLAccountCard.AccountTypeId,
                AccountNo = gLAccountCard.AccountNo,
                Balance = gLAccountCard.Balance,
                DebitCredit = gLAccountCard.DebitCredit
            };


            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name");
            ViewData["AccountSubCategoryId"] = new SelectList(_context.AccountSubCategories, "Id", "Name");
            ViewData["AccountTypeId"] = new SelectList(_context.AccountTypes, "Id", "Name");

            return View(gLAccountCardViewModel);
        }

        // POST: GLAccountCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AccountNo,AccountName,Balance,AccountCategoryId,AccountSubCategoryId,DebitCredit,AccountTypeId")] GLAccountCardViewModel gLAccountCardViewModel)
        {
            if (id != gLAccountCardViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var gLAccountCard = new GLAccountCard
                    {
                        Id = gLAccountCardViewModel.Id,
                        AccountName = gLAccountCardViewModel.AccountName,
                        AccountCategoryId = gLAccountCardViewModel.AccountCategoryId,
                        AccountSubCategoryId = gLAccountCardViewModel.AccountSubCategoryId,
                        AccountTypeId = gLAccountCardViewModel.AccountTypeId,
                        AccountNo = gLAccountCardViewModel.AccountNo,
                        Balance = gLAccountCardViewModel.Balance,
                        DebitCredit = gLAccountCardViewModel.DebitCredit
                    };

                    _context.Update(gLAccountCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GLAccountCardExists(gLAccountCardViewModel.Id))
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
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name");
            ViewData["AccountSubCategoryId"] = new SelectList(_context.AccountSubCategories, "Id", "Name");
            ViewData["AccountTypeId"] = new SelectList(_context.AccountTypes, "Id", "Name");

            return View(gLAccountCardViewModel);
        }

        // GET: GLAccountCards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards
                .Include("AccountCategory")
                .Include("AccountSubCategory")
                .Include("AccountType")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }

            return View(gLAccountCard);
        }

        // POST: GLAccountCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.GLAccountCards == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.GLAccountCards'  is null.");
            }
            var gLAccountCard = await _context.GLAccountCards.FindAsync(id);
            if (gLAccountCard != null)
            {
                _context.GLAccountCards.Remove(gLAccountCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GLAccountCardExists(Guid id)
        {
            return (_context.GLAccountCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
