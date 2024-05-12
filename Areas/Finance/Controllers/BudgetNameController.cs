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
    public class BudgetNameController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public BudgetNameController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/BudgetName
        public async Task<IActionResult> Index()
        {
            return View(await _context.Budgets.ToListAsync());
        }

        // GET: Finance/BudgetName/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Budget", new { id });
            

            var budget = await _context.Budgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // GET: Finance/BudgetName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/BudgetName/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                budget.Id = Guid.NewGuid();
                _context.Add(budget);
                await _context.SaveChangesAsync();   
            }

            var gLAccountCards = _context.GLAccountCards.ToListAsync().Result;

            foreach (var gLAccountCard in gLAccountCards)
            {
                if (!BudgetDetailsExists(budget.Id, gLAccountCard.Id))
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        var newBudgetDetailsRecord = new BudgetDetails
                        {
                            Id = Guid.NewGuid(),
                            BudgetId = budget.Id,
                            GLAccountCard = gLAccountCard,
                            GLAccountCardId = gLAccountCard.Id,
                            BudgetMonth = i,
                            BudgetYear = DateTime.UtcNow.Year
                        };
                        _context.Add(newBudgetDetailsRecord);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            //if not valid do this
            //ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Name", budgetDetails.BudgetId);
            //ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "AccountName", budgetDetails.GLAccountCardId);
            //return View(budgetDetails);
        }

        private bool BudgetDetailsExists(Guid budgetId, Guid glAccountCardId)
        {
            return _context.BudgetsDetails.Any(x => x.BudgetId == budgetId && x.GLAccountCardId == glAccountCardId);
        }
          

        // GET: Finance/BudgetName/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return View(budget);
        }

        // POST: Finance/BudgetName/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Budget budget)
        {
            if (id != budget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.Id))
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
            return View(budget);
        }

        // GET: Finance/BudgetName/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var budget = await _context.Budgets
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (budget == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(budget);
        //}

        // POST: Finance/BudgetName/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var budget = await _context.Budgets.FindAsync(id);
        //    if (budget != null)
        //    {
        //        _context.Budgets.Remove(budget);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool BudgetExists(Guid id)
        {
            return _context.Budgets.Any(e => e.Id == id);
        }
    }
}
