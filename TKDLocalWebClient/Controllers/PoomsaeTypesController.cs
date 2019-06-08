using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TKDLocalWebClient.DAL;
using TKDLocalWebClient.Model;

namespace TKDLocalWebClient.Web.Controllers
{
    public class PoomsaeTypesController : Controller
    {
        private readonly TKDManagerDbContext _context;

        public PoomsaeTypesController(TKDManagerDbContext context)
        {
            _context = context;
        }

        // GET: PoomsaeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PoomsaeTypes.ToListAsync());
        }

        // GET: PoomsaeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsaeType = await _context.PoomsaeTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poomsaeType == null)
            {
                return NotFound();
            }

            return View(poomsaeType);
        }

        // GET: PoomsaeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoomsaeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PoomsaeType poomsaeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poomsaeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poomsaeType);
        }

        // GET: PoomsaeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsaeType = await _context.PoomsaeTypes.FindAsync(id);
            if (poomsaeType == null)
            {
                return NotFound();
            }
            return View(poomsaeType);
        }

        // POST: PoomsaeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PoomsaeType poomsaeType)
        {
            if (id != poomsaeType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poomsaeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoomsaeTypeExists(poomsaeType.ID))
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
            return View(poomsaeType);
        }

        // GET: PoomsaeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsaeType = await _context.PoomsaeTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poomsaeType == null)
            {
                return NotFound();
            }

            return View(poomsaeType);
        }

        // POST: PoomsaeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poomsaeType = await _context.PoomsaeTypes.FindAsync(id);
            _context.PoomsaeTypes.Remove(poomsaeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoomsaeTypeExists(int id)
        {
            return _context.PoomsaeTypes.Any(e => e.ID == id);
        }
    }
}
