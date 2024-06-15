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
    public class GeneralBusPostingGroupsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public GeneralBusPostingGroupsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Finance/GeneralBusPostingGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneralBusPostingGroups.ToListAsync());
        }

        // GET: Finance/GeneralBusPostingGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBusPostingGroup = await _context.GeneralBusPostingGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBusPostingGroup == null)
            {
                return NotFound();
            }

            return View(generalBusPostingGroup);
        }

        // GET: Finance/GeneralBusPostingGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finance/GeneralBusPostingGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description")] GeneralBusPostingGroup generalBusPostingGroup)
        {
            if (ModelState.IsValid)
            {
                generalBusPostingGroup.Id = Guid.NewGuid();
                _context.Add(generalBusPostingGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalBusPostingGroup);
        }

        // GET: Finance/GeneralBusPostingGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBusPostingGroup = await _context.GeneralBusPostingGroups.FindAsync(id);
            if (generalBusPostingGroup == null)
            {
                return NotFound();
            }
            return View(generalBusPostingGroup);
        }

        // POST: Finance/GeneralBusPostingGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description")] GeneralBusPostingGroup generalBusPostingGroup)
        {
            if (id != generalBusPostingGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalBusPostingGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralBusPostingGroupExists(generalBusPostingGroup.Id))
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
            return View(generalBusPostingGroup);
        }

        // GET: Finance/GeneralBusPostingGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBusPostingGroup = await _context.GeneralBusPostingGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBusPostingGroup == null)
            {
                return NotFound();
            }

            return View(generalBusPostingGroup);
        }

        // POST: Finance/GeneralBusPostingGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var generalBusPostingGroup = await _context.GeneralBusPostingGroups.FindAsync(id);
            if (generalBusPostingGroup != null)
            {
                _context.GeneralBusPostingGroups.Remove(generalBusPostingGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralBusPostingGroupExists(Guid id)
        {
            return _context.GeneralBusPostingGroups.Any(e => e.Id == id);
        }
    }
}
