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
    public class CustomerPriceGroupsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CustomerPriceGroupsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/CustomerPriceGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerPriceGroups.ToListAsync());
        }

        // GET: Finance/CustomerPriceGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPriceGroup = await _context.CustomerPriceGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPriceGroup == null)
            {
                return NotFound();
            }

            return View(customerPriceGroup);
        }

        // GET: Finance/CustomerPriceGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/CustomerPriceGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description")] CustomerPriceGroup customerPriceGroup)
        {
            if (ModelState.IsValid)
            {
                customerPriceGroup.Id = Guid.NewGuid();
                _context.Add(customerPriceGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerPriceGroup);
        }

        // GET: Finance/CustomerPriceGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPriceGroup = await _context.CustomerPriceGroups.FindAsync(id);
            if (customerPriceGroup == null)
            {
                return NotFound();
            }
            return View(customerPriceGroup);
        }

        // POST: Finance/CustomerPriceGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description")] CustomerPriceGroup customerPriceGroup)
        {
            if (id != customerPriceGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPriceGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPriceGroupExists(customerPriceGroup.Id))
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
            return View(customerPriceGroup);
        }

        // GET: Finance/CustomerPriceGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPriceGroup = await _context.CustomerPriceGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPriceGroup == null)
            {
                return NotFound();
            }

            return View(customerPriceGroup);
        }

        // POST: Finance/CustomerPriceGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerPriceGroup = await _context.CustomerPriceGroups.FindAsync(id);
            if (customerPriceGroup != null)
            {
                _context.CustomerPriceGroups.Remove(customerPriceGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerPriceGroupExists(Guid id)
        {
            return _context.CustomerPriceGroups.Any(e => e.Id == id);
        }
    }
}
