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
    public class CustomerDiscGroupsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CustomerDiscGroupsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/CustomerDiscGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerDiscountGroups.ToListAsync());
        }

        // GET: Finance/CustomerDiscGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDiscGroup = await _context.CustomerDiscountGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerDiscGroup == null)
            {
                return NotFound();
            }

            return View(customerDiscGroup);
        }

        // GET: Finance/CustomerDiscGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/CustomerDiscGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description")] CustomerDiscGroup customerDiscGroup)
        {
            if (ModelState.IsValid)
            {
                customerDiscGroup.Id = Guid.NewGuid();
                _context.Add(customerDiscGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDiscGroup);
        }

        // GET: Finance/CustomerDiscGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDiscGroup = await _context.CustomerDiscountGroups.FindAsync(id);
            if (customerDiscGroup == null)
            {
                return NotFound();
            }
            return View(customerDiscGroup);
        }

        // POST: Finance/CustomerDiscGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description")] CustomerDiscGroup customerDiscGroup)
        {
            if (id != customerDiscGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerDiscGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerDiscGroupExists(customerDiscGroup.Id))
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
            return View(customerDiscGroup);
        }

        // GET: Finance/CustomerDiscGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDiscGroup = await _context.CustomerDiscountGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerDiscGroup == null)
            {
                return NotFound();
            }

            return View(customerDiscGroup);
        }

        // POST: Finance/CustomerDiscGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerDiscGroup = await _context.CustomerDiscountGroups.FindAsync(id);
            if (customerDiscGroup != null)
            {
                _context.CustomerDiscountGroups.Remove(customerDiscGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerDiscGroupExists(Guid id)
        {
            return _context.CustomerDiscountGroups.Any(e => e.Id == id);
        }
    }
}
