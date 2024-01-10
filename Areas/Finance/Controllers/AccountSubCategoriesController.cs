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
    public class AccountSubCategoriesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public AccountSubCategoriesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: AccountSubCategories
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.AccountSubCategories.Include(a => a.AccountCategory);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: AccountSubCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AccountSubCategories == null)
            {
                return NotFound();
            }

            var accountSubCategory = await _context.AccountSubCategories
                .Include(a => a.AccountCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountSubCategory == null)
            {
                return NotFound();
            }

            return View(accountSubCategory);
        }

        // GET: AccountSubCategories/Create
        public IActionResult Create()
        {
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name");
            return View();
        }

        // POST: AccountSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountCategoryId")] AccountSubCategoryViewModel accountSubCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var accountSubCategory = new AccountSubCategory { Name = accountSubCategoryViewModel.Name, AccountCategoryId = accountSubCategoryViewModel.AccountCategoryId };
                accountSubCategory.Id = Guid.NewGuid();
                _context.Add(accountSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name", accountSubCategoryViewModel.AccountCategoryId);
            return View(accountSubCategoryViewModel);
        }

        // GET: AccountSubCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AccountSubCategories == null)
            {
                return NotFound();
            }

            var accountSubCategory = await _context.AccountSubCategories.FindAsync(id);
            if (accountSubCategory == null)
            {
                return NotFound();
            }
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name", accountSubCategory.AccountCategoryId);
            return View(accountSubCategory);
        }

        // POST: AccountSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,AccountCategoryId")] AccountSubCategory accountSubCategory)
        {
            if (id != accountSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountSubCategoryExists(accountSubCategory.Id))
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
            ViewData["AccountCategoryId"] = new SelectList(_context.AccountCategories, "Id", "Name", accountSubCategory.AccountCategoryId);
            return View(accountSubCategory);
        }

        // GET: AccountSubCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AccountSubCategories == null)
            {
                return NotFound();
            }

            var accountSubCategory = await _context.AccountSubCategories
                .Include(a => a.AccountCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountSubCategory == null)
            {
                return NotFound();
            }

            return View(accountSubCategory);
        }

        // POST: AccountSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AccountSubCategories == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.AccountSubCategories'  is null.");
            }
            var accountSubCategory = await _context.AccountSubCategories.FindAsync(id);
            if (accountSubCategory != null)
            {
                _context.AccountSubCategories.Remove(accountSubCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountSubCategoryExists(Guid id)
        {
            return (_context.AccountSubCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
