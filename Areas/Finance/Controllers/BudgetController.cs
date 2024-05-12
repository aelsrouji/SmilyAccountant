using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class BudgetController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public BudgetController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/Budget
        public async Task<IActionResult> Index(Guid id)
        {
            var budgetDetailsList = _context.BudgetsDetails.Where(x => x.BudgetId == id)
                .Include(b => b.Budget).Include(b => b.GLAccountCard)
                .OrderBy(a => a.GLAccountCardId).ThenBy(b => b.BudgetMonth);

            return View(await budgetDetailsList.ToListAsync());
        }

        // GET: Finance/Budget/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDetails = await _context.BudgetsDetails
                .Include(b => b.Budget)
                .Include(b => b.GLAccountCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetDetails == null)
            {
                return NotFound();
            }

            return View(budgetDetails);
        }

        // GET: Finance/Budget/Create
        public IActionResult Create()
        {
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Name");
            ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "AccountName");
            return View();
        }

        // POST: Finance/Budget/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BudgetId")] BudgetDetails budgetDetails)
        {
            ModelState.Remove("GLAccountCard");
            ModelState.Remove("Budget");

            var glAccounts = _context.GLAccountCards.ToListAsync().Result;

            
            foreach (var gLAccount in glAccounts)
            {
                if (!BudgetDetailsExists(budgetDetails.BudgetId, gLAccount.Id))
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        var newBudgetDetailsRecord = new BudgetDetails
                        {
                            Id = Guid.NewGuid(),
                            BudgetId = budgetDetails.BudgetId,
                            GLAccountCard = gLAccount,
                            GLAccountCardId = gLAccount.Id,
                            BudgetMonth = i,
                            BudgetYear = DateTime.UtcNow.Year
                        };
                        _context.Add(newBudgetDetailsRecord);
                    }
                }
                
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id = budgetDetails.BudgetId});

            //if not valid do this
            //ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Name", budgetDetails.BudgetId);
            //ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "AccountName", budgetDetails.GLAccountCardId);
            //return View(budgetDetails);
        }

        private bool BudgetDetailsExists(Guid budgetId, Guid id)
        {
            return _context.BudgetsDetails.Any(x => x.BudgetId == budgetId && x.GLAccountCardId == id);
        }

        // GET: Finance/Budget/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDetails = await _context.BudgetsDetails.FindAsync(id);
            if (budgetDetails == null)
            {
                return NotFound();
            }
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Name", budgetDetails.BudgetId);
            ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "AccountName", budgetDetails.GLAccountCardId);
            return View(budgetDetails);
        }

        // POST: Finance/Budget/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BudgetedAmount")] BudgetDetails budgetDetails)
        {
            if (id != budgetDetails.Id)
            {
                return NotFound();
            }

            try
            {
                var budgetDetail = await _context.BudgetsDetails.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (budgetDetail == null)
                {
                    return NotFound();
                }
                budgetDetail.BudgetedAmount = budgetDetails.BudgetedAmount;
                _context.Entry(budgetDetail).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = budgetDetail.BudgetId });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetDetailsExists(budgetDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Name", budgetDetails.BudgetId);
            ViewData["GLAccountCardId"] = new SelectList(_context.GLAccountCards, "Id", "AccountName", budgetDetails.GLAccountCardId);
            return View(budgetDetails);
            
              
        }

        // GET: Finance/Budget/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDetails = await _context.BudgetsDetails
                .Include(b => b.Budget)
                .Include(b => b.GLAccountCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetDetails == null)
            {
                return NotFound();
            }

            return View(budgetDetails);
        }

        // POST: Finance/Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var budgetDetails = await _context.BudgetsDetails.FindAsync(id);
            if (budgetDetails != null)
            {
                _context.BudgetsDetails.Remove(budgetDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetDetailsExists(Guid id)
        {
            return _context.BudgetsDetails.Any(e => e.Id == id);
        }
    }
}
