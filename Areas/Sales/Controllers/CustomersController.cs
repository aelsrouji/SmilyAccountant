using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Sales.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class CustomersController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CustomersController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: Sales/Customers
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.Customers.Include(c => c.CustomerDiscGroup)
                .Include(c => c.CustomerPostingGroup)
                .Include(c => c.CustomerPriceGroup)
                .Include(c => c.GeneralBusPostingGroup)
                .Include(c => c.TaxAreaCode)
                .Include(c => c.SalesPerson)
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City);
                
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: Sales/Customers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.CustomerDiscGroup)
                .Include(c => c.CustomerPostingGroup)
                .Include(c => c.CustomerPriceGroup)
                .Include(c => c.GeneralBusPostingGroup)
                .Include(c => c.TaxAreaCode)
                .Include(c => c.SalesPerson)
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Sales/Customers/Create
        public IActionResult Create()
        {
            ViewData["CustomerDiscGroupId"] = new SelectList(_context.CustomerDiscountGroups, "Id", "Code");
            ViewData["CustomerPostingGroupId"] = new SelectList(_context.CustomerPostingGroups, "Id", "Code");
            ViewData["CustomerPriceGroupId"] = new SelectList(_context.CustomerPriceGroups, "Id", "Code");
            ViewData["GeneralBusPostingGroupId"] = new SelectList(_context.GeneralBusPostingGroups, "Id", "Code");
            ViewData["TaxAreaCodeId"] = new SelectList(_context.TaxAreaCodes, "Id", "Code");
            ViewData["SalesPersonId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            return View();
        }

        // POST: Sales/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Balanace,BalanaceAsVendor,CreditLimit,SalesPersonId,TotalSalesFiscalYear,Costs,Profit,ProfitPercentage,LastDateModified,Address,Address2,CountryId,StateId,CityId,PostalCode,Phone,MobilePhone,Email,HomePage,VatRegistrationNo,CopySellToAddrToQte,TaxLiable,TaxAreaCodeId,TaxIdentificationType,TaxExcemptionNo,GeneralBusPostingGroupId,CustomerPostingGroupId,CustomerPriceGroupId,CustomerDiscGroupId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = Guid.NewGuid();
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerDiscGroupId"] = new SelectList(_context.CustomerDiscountGroups, "Id", "Code", customer.CustomerDiscGroupId);
            ViewData["CustomerPostingGroupId"] = new SelectList(_context.CustomerPostingGroups, "Id", "Code", customer.CustomerPostingGroupId);
            ViewData["CustomerPriceGroupId"] = new SelectList(_context.CustomerPriceGroups, "Id", "Code", customer.CustomerPriceGroupId);
            ViewData["GeneralBusPostingGroupId"] = new SelectList(_context.GeneralBusPostingGroups, "Id", "Code", customer.GeneralBusPostingGroupId);
            ViewData["TaxAreaCodeId"] = new SelectList(_context.TaxAreaCodes, "Id", "Code", customer.TaxAreaCodeId);
            ViewData["SalesPersonId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            return View(customer);
        }

        // GET: Sales/Customers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CustomerDiscGroupId"] = new SelectList(_context.CustomerDiscountGroups, "Id", "Code", customer.CustomerDiscGroupId);
            ViewData["CustomerPostingGroupId"] = new SelectList(_context.CustomerPostingGroups, "Id", "Code", customer.CustomerPostingGroupId);
            ViewData["CustomerPriceGroupId"] = new SelectList(_context.CustomerPriceGroups, "Id", "Code", customer.CustomerPriceGroupId);
            ViewData["GeneralBusPostingGroupId"] = new SelectList(_context.GeneralBusPostingGroups, "Id", "Code", customer.GeneralBusPostingGroupId);
            ViewData["TaxAreaCodeId"] = new SelectList(_context.TaxAreaCodes, "Id", "Code", customer.TaxAreaCodeId);
            ViewData["SalesPersonId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");


            return View(customer);
        }

        // POST: Sales/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Number,Name,Balanace,BalanaceAsVendor,CreditLimit,SalesPersonId,TotalSalesFiscalYear,Costs,Profit,ProfitPercentage,LastDateModified,Address,Address2,CountryId,StateId,CityId,PostalCode,Phone,MobilePhone,Email,HomePage,VatRegistrationNo,CopySellToAddrToQte,TaxLiable,TaxAreaCodeId,TaxIdentificationType,TaxExcemptionNo,GeneralBusPostingGroupId,CustomerPostingGroupId,CustomerPriceGroupId,CustomerDiscGroupId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["CustomerDiscGroupId"] = new SelectList(_context.CustomerDiscountGroups, "Id", "Code", customer.CustomerDiscGroupId);
            ViewData["CustomerPostingGroupId"] = new SelectList(_context.CustomerPostingGroups, "Id", "Code", customer.CustomerPostingGroupId);
            ViewData["CustomerPriceGroupId"] = new SelectList(_context.CustomerPriceGroups, "Id", "Code", customer.CustomerPriceGroupId);
            ViewData["GeneralBusPostingGroupId"] = new SelectList(_context.GeneralBusPostingGroups, "Id", "Code", customer.GeneralBusPostingGroupId);
            ViewData["TaxAreaCodeId"] = new SelectList(_context.TaxAreaCodes, "Id", "Code", customer.TaxAreaCodeId);
            ViewData["SalesPersonId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            return View(customer);
        }

        // GET: Sales/Customers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.CustomerDiscGroup)
                .Include(c => c.CustomerPostingGroup)
                .Include(c => c.CustomerPriceGroup)
                .Include(c => c.GeneralBusPostingGroup)
                .Include(c => c.TaxAreaCode)
                .Include(c => c.SalesPerson)
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Sales/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
