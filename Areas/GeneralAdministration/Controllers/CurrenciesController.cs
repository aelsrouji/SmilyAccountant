using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.GeneralAdministration.Controllers
{
    [Area("GeneralAdministration")]
    public class CurrenciesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CurrenciesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/Currencies
        public async Task<IActionResult> Index()
        {
            return _context.Currencies != null ?
                        View(await _context.Currencies.ToListAsync()) :
                        Problem("Entity set 'SmilyAccountantContext.Currencies'  is null.");
        }

        // GET: Finance/Currencies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Currencies == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // GET: Finance/Currencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/Currencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                currency.Id = Guid.NewGuid();
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        // GET: Finance/Currencies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Currencies == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        // POST: Finance/Currencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Code")] Currency currency)
        {
            if (id != currency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyExists(currency.Id))
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
            return View(currency);
        }

        // GET: Finance/Currencies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Currencies == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // POST: Finance/Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Currencies == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.Currencies'  is null.");
            }
            var currency = await _context.Currencies.FindAsync(id);
            if (currency != null)
            {
                _context.Currencies.Remove(currency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyExists(Guid id)
        {
            return (_context.Currencies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
