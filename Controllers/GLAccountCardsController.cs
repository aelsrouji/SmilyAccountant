﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Models;

namespace SmilyAccountant.Controllers
{
    public class GLAccountCardsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public GLAccountCardsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GLAccountCards
        public async Task<IActionResult> Index()
        {
              return _context.GLAccountCards != null ? 
                          View(await _context.GLAccountCards.ToListAsync()) :
                          Problem("Entity set 'SmilyAccountantContext.GLAccountCards'  is null.");
        }

        // GET: GLAccountCards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }

            return View(gLAccountCard);
        }

        // GET: GLAccountCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GLAccountCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountNo,AccountName,Balance,AccountCategoryId,AccountSubCategoryId,DebitCredit,AccountTypeId")] GLAccountCard gLAccountCard)
        {
            if (ModelState.IsValid)
            {
                gLAccountCard.Id = Guid.NewGuid();
                _context.Add(gLAccountCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gLAccountCard);
        }

        // GET: GLAccountCards/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards.FindAsync(id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }
            return View(gLAccountCard);
        }

        // POST: GLAccountCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AccountNo,AccountName,Balance,AccountCategoryId,AccountSubCategoryId,DebitCredit,AccountTypeId")] GLAccountCard gLAccountCard)
        {
            if (id != gLAccountCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gLAccountCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GLAccountCardExists(gLAccountCard.Id))
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
            return View(gLAccountCard);
        }

        // GET: GLAccountCards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.GLAccountCards == null)
            {
                return NotFound();
            }

            var gLAccountCard = await _context.GLAccountCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gLAccountCard == null)
            {
                return NotFound();
            }

            return View(gLAccountCard);
        }

        // POST: GLAccountCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.GLAccountCards == null)
            {
                return Problem("Entity set 'SmilyAccountantContext.GLAccountCards'  is null.");
            }
            var gLAccountCard = await _context.GLAccountCards.FindAsync(id);
            if (gLAccountCard != null)
            {
                _context.GLAccountCards.Remove(gLAccountCard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GLAccountCardExists(Guid id)
        {
          return (_context.GLAccountCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
