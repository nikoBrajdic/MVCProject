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
    public class CategoriesController : Controller
    {
        private readonly TKDManagerDbContext _context;

        public CategoriesController(TKDManagerDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var tKDManagerDbContext = _context.Categories.Include(c => c.Poomsae11).Include(c => c.Poomsae12).Include(c => c.Poomsae21).Include(c => c.Poomsae22).Include(c => c.Poomsae31).Include(c => c.Poomsae32);
            return View(await tKDManagerDbContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Poomsae11)
                .Include(c => c.Poomsae12)
                .Include(c => c.Poomsae21)
                .Include(c => c.Poomsae22)
                .Include(c => c.Poomsae31)
                .Include(c => c.Poomsae32)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["Poomsae11ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            ViewData["Poomsae12ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            ViewData["Poomsae21ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            ViewData["Poomsae22ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            ViewData["Poomsae31ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            ViewData["Poomsae32ID"] = new SelectList(_context.Poomsaes, "ID", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortName,IsFreestyle,CurrentRound,Poomsae11ID,Poomsae12ID,Poomsae21ID,Poomsae22ID,Poomsae31ID,Poomsae32ID")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Poomsae11ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["Poomsae11ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortName,IsFreestyle,CurrentRound,Poomsae11ID,Poomsae12ID,Poomsae21ID,Poomsae22ID,Poomsae31ID,Poomsae32ID")] Category category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.ID))
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
            ViewData["Poomsae11ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(_context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Poomsae11)
                .Include(c => c.Poomsae12)
                .Include(c => c.Poomsae21)
                .Include(c => c.Poomsae22)
                .Include(c => c.Poomsae31)
                .Include(c => c.Poomsae32)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }
    }
}
