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
    public class CustomerPostingGroupsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CustomerPostingGroupsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/CustomerPostingGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerPostingGroups.ToListAsync());
        }

        // GET: Finance/CustomerPostingGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPostingGroup = await _context.CustomerPostingGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPostingGroup == null)
            {
                return NotFound();
            }

            return View(customerPostingGroup);
        }

        // GET: Finance/CustomerPostingGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/CustomerPostingGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description")] CustomerPostingGroup customerPostingGroup)
        {
            if (ModelState.IsValid)
            {
                customerPostingGroup.Id = Guid.NewGuid();
                _context.Add(customerPostingGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerPostingGroup);
        }

        // GET: Finance/CustomerPostingGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPostingGroup = await _context.CustomerPostingGroups.FindAsync(id);
            if (customerPostingGroup == null)
            {
                return NotFound();
            }
            return View(customerPostingGroup);
        }

        // POST: Finance/CustomerPostingGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description")] CustomerPostingGroup customerPostingGroup)
        {
            if (id != customerPostingGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPostingGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPostingGroupExists(customerPostingGroup.Id))
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
            return View(customerPostingGroup);
        }

        // GET: Finance/CustomerPostingGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPostingGroup = await _context.CustomerPostingGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPostingGroup == null)
            {
                return NotFound();
            }

            return View(customerPostingGroup);
        }

        // POST: Finance/CustomerPostingGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerPostingGroup = await _context.CustomerPostingGroups.FindAsync(id);
            if (customerPostingGroup != null)
            {
                _context.CustomerPostingGroups.Remove(customerPostingGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerPostingGroupExists(Guid id)
        {
            return _context.CustomerPostingGroups.Any(e => e.Id == id);
        }
    }
}
