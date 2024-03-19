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
    public class ChartOfAccountsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public ChartOfAccountsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/ChartOfAccounts
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.ChartOfAccounts.Include(c => c.GLAccountCard)
                .Include(t => t.GLAccountCard.AccountType)
                .Include(ac => ac.GLAccountCard.AccountCategory)
                .Include(asc => asc.GLAccountCard.AccountSubCategory);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Finance/ChartOfAccounts/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var chartOfAccount = await _context.ChartOfAccounts
        //        .Include(c => c.GLAccountCard)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (chartOfAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(chartOfAccount);
        //}

        // GET: Finance/ChartOfAccounts/Create
        //public IActionResult Create()
        //{
        //    ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "Id");
        //    return View();
        //}

        // POST: Finance/ChartOfAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,GLAccountCardId,NetChange,NetBalanace")] ChartOfAccount chartOfAccount)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        chartOfAccount.Id = Guid.NewGuid();
        //        _context.Add(chartOfAccount);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "Id", chartOfAccount.GLAccountCardId);
        //    return View(chartOfAccount);
        //}

        // GET: Finance/ChartOfAccounts/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var chartOfAccount = await _context.ChartOfAccounts.FindAsync(id);
        //    if (chartOfAccount == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "Id", chartOfAccount.GLAccountCardId);
        //    return View(chartOfAccount);
        //}

        // POST: Finance/ChartOfAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,GLAccountCardId,NetChange,NetBalanace")] ChartOfAccount chartOfAccount)
        //{
        //    if (id != chartOfAccount.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(chartOfAccount);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ChartOfAccountExists(chartOfAccount.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "Id", chartOfAccount.GLAccountCardId);
        //    return View(chartOfAccount);
        //}

        // GET: Finance/ChartOfAccounts/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var chartOfAccount = await _context.ChartOfAccounts
        //        .Include(c => c.GLAccountCard)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (chartOfAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(chartOfAccount);
        //}

        // POST: Finance/ChartOfAccounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var chartOfAccount = await _context.ChartOfAccounts.FindAsync(id);
        //    if (chartOfAccount != null)
        //    {
        //        _context.ChartOfAccounts.Remove(chartOfAccount);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ChartOfAccountExists(Guid id)
        {
            return _context.ChartOfAccounts.Any(e => e.Id == id);
        }
    }
}
