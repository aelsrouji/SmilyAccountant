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
    public class VendorsController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public VendorsController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GeneralAdministration/Vendors
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.Vendors.Include(v => v.City).Include(v => v.Country).Include(v => v.PrimaryContact).Include(v => v.SecondaryContact);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: GeneralAdministration/Vendors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.City)
                .Include(v => v.Country)
                .Include(v => v.PrimaryContact)
                .Include(v => v.SecondaryContact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: GeneralAdministration/Vendors/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["PrimaryContactId"] = new SelectList(_context.Contacts, "Id", "Name");
            ViewData["SecondaryContactId"] = new SelectList(_context.Contacts, "Id", "Name");
            return View();
        }

        // POST: GeneralAdministration/Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendorNo,Name,BalanceLCY,BalanceLCYasCustomer,BalanceDue,Address,Address2,CityId,StateProvince,CountryId,PostalCode,Phone,MobilePhone,Email,PrimaryContactId,SecondaryContactId")] Vendor vendor)
        {
            ModelState.Remove(nameof(City));
            ModelState.Remove("StateProvince");
            ModelState.Remove(nameof(Country));
            ModelState.Remove("PrimaryContact");
            ModelState.Remove("SecondaryContact");

            if (ModelState.IsValid)
            {
                vendor.Id = Guid.NewGuid();
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", vendor.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", vendor.CountryId);
            ViewData["PrimaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.PrimaryContactId);
            ViewData["SecondaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.SecondaryContactId);
            return View(vendor);
        }

        // GET: GeneralAdministration/Vendors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", vendor.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", vendor.CountryId);
            ViewData["PrimaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.PrimaryContactId);
            ViewData["SecondaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.SecondaryContactId);
            return View(vendor);
        }

        // POST: GeneralAdministration/Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VendorNo,Name,BalanceLCY,BalanceLCYasCustomer,BalanceDue,Address,Address2,CityId,StateProvince,CountryId,PostalCode,Phone,MobilePhone,Email,PrimaryContactId,SecondaryContactId")] Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(City));
            ModelState.Remove("StateProvince");
            ModelState.Remove(nameof(Country));
            ModelState.Remove("PrimaryContact");
            ModelState.Remove("SecondaryContact");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", vendor.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", vendor.CountryId);
            ViewData["PrimaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.PrimaryContactId);
            ViewData["SecondaryContactId"] = new SelectList(_context.Contacts, "Id", "Name", vendor.SecondaryContactId);
            return View(vendor);
        }

        // GET: GeneralAdministration/Vendors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.City)
                .Include(v => v.Country)
                .Include(v => v.PrimaryContact)
                .Include(v => v.SecondaryContact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: GeneralAdministration/Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(Guid id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}
