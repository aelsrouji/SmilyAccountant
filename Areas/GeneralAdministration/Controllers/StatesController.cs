using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.GeneralAdministration.Controllers
{
    [Area("GeneralAdministration")]
    public class StatesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public StatesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GeneralAdministration/States
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.States.Include(s => s.Country);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: GeneralAdministration/States/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: GeneralAdministration/States/Create
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: GeneralAdministration/States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,UpdatedDate,CountryID")] State state)
        {
            ModelState.Remove(nameof(Country));
            if (ModelState.IsValid)
            {
                state.Id = Guid.NewGuid();
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name", state.CountryID);
            return View(state);
        }

        // GET: GeneralAdministration/States/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name", state.CountryID);
            return View(state);
        }

        // POST: GeneralAdministration/States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,UpdatedDate,CountryID")] State state)
        {
            if (id != state.Id)
            {
                return NotFound();
            }
            ModelState.Remove(nameof(Country));
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.Id))
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
            ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name", state.CountryID);
            return View(state);
        }

        // GET: GeneralAdministration/States/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: GeneralAdministration/States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var state = await _context.States.FindAsync(id);
            if (state != null)
            {
                _context.States.Remove(state);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateExists(Guid id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}
