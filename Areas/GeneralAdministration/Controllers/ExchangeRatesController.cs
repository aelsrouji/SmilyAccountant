using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.GeneralAdministration.Controllers
{
    [Area("GeneralAdministration")]
    public class ExchangeRatesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public ExchangeRatesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GeneralAdministration/ExchangeRates
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.ExchangeRates.Include(e => e.FromCurrency).Include(e => e.ToCurrency);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: GeneralAdministration/ExchangeRates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .Include(e => e.FromCurrency)
                .Include(e => e.ToCurrency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // GET: GeneralAdministration/ExchangeRates/Create
        public IActionResult Create()
        {
            ViewData["FromCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name");
            ViewData["ToCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name");
            return View();
        }

        // POST: GeneralAdministration/ExchangeRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FromCurrencyId,ToCurrencyId,ExchangeRateValue,ExchangeRateDate")] ExchangeRate exchangeRate)
        {
            ModelState.Remove("FromCurrency");
            ModelState.Remove("ToCurrency");

            if (ModelState.IsValid)
            {
                if (ValidEntry(exchangeRate))
                {
                    await DeactivateOtherEntries(exchangeRate);

                    exchangeRate.Id = Guid.NewGuid();
                    exchangeRate.IsActive = true;
                    _context.Add(exchangeRate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["FromCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.FromCurrencyId);
            ViewData["ToCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.ToCurrencyId);
            return View(exchangeRate);
        }

        private async Task DeactivateOtherEntries(ExchangeRate exchangeRate)
        {
            var existingExchangeRates = _context.ExchangeRates.Where(x => x.FromCurrencyId == exchangeRate.FromCurrencyId && x.ToCurrencyId == exchangeRate.ToCurrencyId);
            if (existingExchangeRates == null)
            {
                return;
            }
            else
            {
                foreach (var item in existingExchangeRates)
                {
                    item.IsActive = false;
                    _context.Update(item);
                }
                await _context.SaveChangesAsync();
            }
        }

        private bool ValidEntry(ExchangeRate exchangeRate)
        {
            if (exchangeRate.FromCurrencyId == exchangeRate.ToCurrencyId)
            {
                return false;
            }
            return true;
        }

        // GET: GeneralAdministration/ExchangeRates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            ViewData["FromCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.FromCurrencyId);
            ViewData["ToCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.ToCurrencyId);
            return View(exchangeRate);
        }

        // POST: GeneralAdministration/ExchangeRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FromCurrencyId,ToCurrencyId,ExchangeRateValue,ExchangeRateDate,IsActive")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.Id)
            {
                return NotFound();
            }
            ModelState.Remove("FromCurrency");
            ModelState.Remove("ToCurrency");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.Id))
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
            ViewData["FromCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.FromCurrencyId);
            ViewData["ToCurrencyId"] = new SelectList(_context.Currencies, "Id", "Name", exchangeRate.ToCurrencyId);
            return View(exchangeRate);
        }

        // GET: GeneralAdministration/ExchangeRates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .Include(e => e.FromCurrency)
                .Include(e => e.ToCurrency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: GeneralAdministration/ExchangeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate != null)
            {
                _context.ExchangeRates.Remove(exchangeRate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(Guid id)
        {
            return _context.ExchangeRates.Any(e => e.Id == id);
        }
    }
}
