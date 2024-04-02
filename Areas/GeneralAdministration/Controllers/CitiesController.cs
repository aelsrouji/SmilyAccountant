using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Data;

namespace SmilyAccountant.Areas.GeneralAdministration.Controllers
{
    [Area("GeneralAdministration")]
    public class CitiesController : Controller
    {
        private readonly SmilyAccountantContext _context;

        public CitiesController(SmilyAccountantContext context)
        {
            _context = context;
        }

        // GET: GeneralAdministration/Cities
        public async Task<IActionResult> Index()
        {
            var smilyAccountantContext = _context.Cities.Include(c => c.Country).Include(c => c.State);
            return View(await smilyAccountantContext.ToListAsync());
        }

        // GET: GeneralAdministration/Cities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: GeneralAdministration/Cities/Create
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.Countries.Where(c => c.IsActive == true), "Id", "Name");
            return View();

            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            //ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            //return View();
        }

        // POST: GeneralAdministration/Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,UpdatedDate,CountryId,StateId")] City city)
        {
            ModelState.Remove(nameof(Country));
            ModelState.Remove(nameof(State));

            //var cityWithSameName = GetCityByName(cityViewModel.Name, cityViewModel.CountryId, cityViewModel.StateId);

            //if (cityWithSameName != null)
            //{
            //    ModelState.AddModelError("Name", "City with the same name exists.");
            //}

            if (ModelState.IsValid)
            {
                //var currentUser = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity;

                //var city = new City
                //{
                //    Id = Guid.NewGuid(),
                //    Name = cityViewModel.Name,
                //    CountryId = cityViewModel.CountryId,
                //    StateId = cityViewModel.StateId,
                //    IsActive = cityViewModel.IsActive,

                //    CreatedBy = currentUser.Name,
                //    ModifiedBy = currentUser.Name,
                //    CreatedDate = DateTime.UtcNow,
                //    UpdatedDate = DateTime.UtcNow
                //};

                //_context.Add(city);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));


                city.Id = Guid.NewGuid();
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries.Where(c => c.IsActive == true), "Id", "Name", city.CountryId);

            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            //ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: GeneralAdministration/Cities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var cityViewModel = new CityViewModel
            //{
            //    Id = city.Id,
            //    Name = city.Name,
            //    CountryId = city.CountryId,
            //    StateId = city.StateId,
            //    IsActive = city.IsActive
            //};

            //ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            //return View(cityViewModel);

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            //ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", city.StateId);
            ViewData["CountryID"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            return View(city);
        }

        // POST: GeneralAdministration/Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,UpdatedDate,CountryId,StateId")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Country));
            ModelState.Remove(nameof(State));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries.Where(c => c.IsActive == true), "Id", "Name", city.CountryId);

            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            //ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: GeneralAdministration/Cities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: GeneralAdministration/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(Guid id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }


        [HttpGet]
        public IActionResult GetStatesByCountry(string id)
        {
            Guid countryId;

            if (Guid.TryParse(id, out countryId))
            {
                List<State> states = new List<State>();

                states = _context.States.Where(c => c.IsActive == true && c.CountryID == countryId).ToList();
                states.Insert(0, new State { Id = new Guid(id), Name = "-- Select State -- ", Code = string.Empty, CreatedBy = string.Empty, IsActive = true });

                return Json(new SelectList(states, "Id", "Name"));
            }
            return StatusCode(500);

        }
    }
}
