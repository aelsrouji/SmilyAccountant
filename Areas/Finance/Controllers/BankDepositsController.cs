using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class BankDepositsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public BankDepositsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/BankDeposits
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.BankDeposits.Include(b => b.BankAccount);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Finance/BankDeposits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankDeposit = await _context.BankDeposits
                .Include(b => b.BankAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankDeposit == null)
            {
                return NotFound();
            }

            return View(bankDeposit);
        }

        // GET: Finance/BankDeposits/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "No");
            return View();
        }

        // POST: Finance/BankDeposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankAccountId,DepositAmount,PostingDate")] BankDeposit bankDeposit)
        {
            ModelState.Remove("BankAccount");

            if (ModelState.IsValid)
            {
                bankDeposit.Id = Guid.NewGuid();
                _context.Add(bankDeposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "No", bankDeposit.BankAccountId);
            return View(bankDeposit);
        }

        // GET: Finance/BankDeposits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankDeposit = await _context.BankDeposits.FindAsync(id);
            if (bankDeposit == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "No", bankDeposit.BankAccountId);
            return View(bankDeposit);
        }

        // POST: Finance/BankDeposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BankAccountId,DepositAmount,PostingDate")] BankDeposit bankDeposit)
        {
            if (id != bankDeposit.Id)
            {
                return NotFound();
            }

            ModelState.Remove("BankAccount");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankDeposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankDepositExists(bankDeposit.Id))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "No", bankDeposit.BankAccountId);
            return View(bankDeposit);
        }

        // GET: Finance/BankDeposits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankDeposit = await _context.BankDeposits
                .Include(b => b.BankAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankDeposit == null)
            {
                return NotFound();
            }

            return View(bankDeposit);
        }

        // POST: Finance/BankDeposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bankDeposit = await _context.BankDeposits.FindAsync(id);
            if (bankDeposit != null)
            {
                _context.BankDeposits.Remove(bankDeposit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankDepositExists(Guid id)
        {
            return _context.BankDeposits.Any(e => e.Id == id);
        }
    }
}
