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
    public class AccountCategoriesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public AccountCategoriesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: AccountCategories
        public async Task<IActionResult> Index()
        {
            return _context.AccountCategories != null ?
                        View(await _context.AccountCategories.ToListAsync()) :
                        Problem("Entity set 'SmilyAccountantContext.AccountCategories'  is null.");
        }

        // GET: AccountCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AccountCategories == null)
            {
                return NotFound();
            }

            var accountCategory = await _context.AccountCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountCategory == null)
            {
                return NotFound();
            }

            return View(accountCategory);
        }

        // GET: AccountCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AccountCategory accountCategory)
        {
            if (ModelState.IsValid)
            {
                accountCategory.Id = Guid.NewGuid();
                _context.Add(accountCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountCategory);
        }

        // GET: AccountCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AccountCategories == null)
            {
                return NotFound();
            }

            var accountCategory = await _context.AccountCategories.FindAsync(id);
            if (accountCategory == null)
            {
                return NotFound();
            }
            return View(accountCategory);
        }

        // POST: AccountCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] AccountCategory accountCategory)
        {
            if (id != accountCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountCategoryExists(accountCategory.Id))
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
            return View(accountCategory);
        }

        // GET: AccountCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AccountCategories == null)
            {
                return NotFound();
            }

            var accountCategory = await _context.AccountCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountCategory == null)
            {
                return NotFound();
            }

            return View(accountCategory);
        }

        // POST: AccountCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AccountCategories == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.AccountCategories'  is null.");
            }
            var accountCategory = await _context.AccountCategories.FindAsync(id);
            if (accountCategory != null)
            {
                _context.AccountCategories.Remove(accountCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountCategoryExists(Guid id)
        {
            return (_context.AccountCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
