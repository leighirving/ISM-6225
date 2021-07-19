using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISM6225_Assignment4.APIHandlerManager;
using ISM6225_Assignment4.Models;
using ISM6225_Assignment4.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;




namespace ISM6225_Assignment4.Controllers
{
    public class FishingAreasController : Controller
    {

        private readonly ApplicationDbContext _context;
        

        public FishingAreasController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index (string countyName, string searchString)
        {
            IQueryable<string> countyQuery = from f in _context.FishingAreas
                                            orderby f.County
                                            select f.County;

            var fishingAreas = from f in _context.FishingAreas
                         select f;

            if (!string.IsNullOrEmpty(searchString))
            {
                fishingAreas = fishingAreas.Where(s => s.County.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(countyName))
            {
                fishingAreas = fishingAreas.Where(x => x.County == countyName);
            }

            var countyNameVM = new countyNameViewModel
            {
                Countys = new SelectList(await countyQuery.Distinct().ToListAsync()),
                FishingAreas = await fishingAreas.ToListAsync()
            };

            return View(countyNameVM);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Waterbody,Town,County,Owner, Manager, AccessType, BoatSize, RampType, UniversalAccess")] Attributes attributes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attributes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attributes);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingArea = await _context.FishingAreas.FirstOrDefaultAsync(f => f.id == id);
            if (fishingArea == null)
            {
                return NotFound();
            }

            return View(fishingArea);
        }

        



        // GET: FishingAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingArea = await _context.FishingAreas
                .FirstOrDefaultAsync(f => f.id == id);
            if (fishingArea == null)
            {
                return NotFound();
            }

            return View(fishingArea);
        }

        // POST: FishingAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishingArea = await _context.FishingAreas.FindAsync(id);
            _context.FishingAreas.Remove(fishingArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingAreaExists(int id)
        {
            return _context.FishingAreas.Any(f => f.id == id);
        }

        // GET: FishingAreas/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingArea = await _context.FishingAreas.FindAsync(id);
            if (fishingArea == null)
            {
                return NotFound();
            }
            return View(fishingArea);
        }

        // POST: FishingAreas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Waterbody,Town,County,Owner, Manager, AccessType, BoatSize, RampType, UniversalAccess")] Attributes attributes)
        {
            if (id != attributes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingAreaExists(attributes.id))
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
            return View(attributes);
        }


        public IActionResult Update()
        {
            APIHandler webHandler = new APIHandler();
        FishingAreas fishingAreas = webHandler.GetFishingAreas();
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var fishingArea in fishingAreas.data)
                {
                    if (_context.FishingAreas.Where(f => f.id.Equals(fishingArea.attributes.id)).Count() == 0)
                    {
                        _context.FishingAreas.Add(fishingArea.attributes);
                    }

                }

                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FishingAreas] ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FishingAreas] OFF");

                transaction.Commit();

            }
            return View();
        }


    }
}