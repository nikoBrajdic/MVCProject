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
    public class PoomsaesController : Controller
    {
        private readonly TKDManagerDbContext _context;

        public PoomsaesController(TKDManagerDbContext context)
        {
            _context = context;
        }

        // GET: Poomsaes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Poomsaes.ToListAsync());
        }

        // GET: Poomsaes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsae = await _context.Poomsaes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poomsae == null)
            {
                return NotFound();
            }

            return View(poomsae);
        }

        // GET: Poomsaes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poomsaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortName,Ordinal,PoomsaeTypeId")] Poomsae poomsae)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poomsae);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poomsae);
        }

        // GET: Poomsaes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsae = await _context.Poomsaes.FindAsync(id);
            if (poomsae == null)
            {
                return NotFound();
            }
            return View(poomsae);
        }

        // POST: Poomsaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortName,Ordinal,PoomsaeTypeId")] Poomsae poomsae)
        {
            if (id != poomsae.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poomsae);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoomsaeExists(poomsae.ID))
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
            return View(poomsae);
        }

        // GET: Poomsaes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poomsae = await _context.Poomsaes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poomsae == null)
            {
                return NotFound();
            }

            return View(poomsae);
        }

        // POST: Poomsaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poomsae = await _context.Poomsaes.FindAsync(id);
            _context.Poomsaes.Remove(poomsae);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoomsaeExists(int id)
        {
            return _context.Poomsaes.Any(e => e.ID == id);
        }
    }
}
