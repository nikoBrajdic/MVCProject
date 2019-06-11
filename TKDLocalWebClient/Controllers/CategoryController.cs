using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TKDLocalWebClient.DAL;
using TKDLocalWebClient.Model;
using TKDLocalWebClient.Web.Models;

//
// Iz nekog razloga Attribute routing i Fluent API routing ne rade zajedno
//

namespace TKDLocalWebClient.Web.Controllers
{
    //[Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly TKDManagerDbContext Context;

        public CategoryController(TKDManagerDbContext context)
        {
            Context = context;
        }

        // GET: Categories
        //[Route("[action]")]
        //[Route("{[action]:regex(^(Pocetna|Inde(ks|x).*)$)}")]
        public async Task<IActionResult> Index() => View(await Context.Categories
            .Include(c => c.Poomsae11).Include(c => c.Poomsae12)
            .Include(c => c.Poomsae21).Include(c => c.Poomsae22)
            .Include(c => c.Poomsae31).Include(c => c.Poomsae32)
            .ToListAsync());

        [HttpPost]
        //[Route("[action]")]
        //[Route("{[action]:regex(^(Pocetna|Inde(ks|x).*)$)}")]
        public async Task<IActionResult> IndexAjax(CategoryFilterModel filter)
        {
            var query = Context.Categories
                .Include(c => c.Poomsae11).Include(c => c.Poomsae12)
                .Include(c => c.Poomsae21).Include(c => c.Poomsae22)
                .Include(c => c.Poomsae31).Include(c => c.Poomsae32)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.ShortName))
                query = query.Where(p => p.ShortName.ToLower().Contains(filter.ShortName.ToLower()));

                query = query.Where(p => p.IsFreestyle == filter.IsFreestyle);

            return PartialView("IndexPartial", await query.ToListAsync());
        }

        // GET: Categories/Details/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Pregled|Deta(lji|ils))$)}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await Context.Categories
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
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public IActionResult Create()
        {
            ViewData["Poomsae11ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            ViewData["Poomsae12ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            ViewData["Poomsae21ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            ViewData["Poomsae22ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            ViewData["Poomsae31ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            ViewData["Poomsae32ID"] = new SelectList(Context.Poomsaes, "ID", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public async Task<IActionResult> Create([Bind("Name,ShortName,IsFreestyle,CurrentRound,Poomsae11ID,Poomsae12ID,Poomsae21ID,Poomsae22ID,Poomsae31ID,Poomsae32ID")] Category category)
        {
            if (ModelState.IsValid)
            {
                Context.Add(category);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Poomsae11ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // GET: Categories/Edit/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await Context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["Poomsae11ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
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
                    Context.Update(category);
                    await Context.SaveChangesAsync();
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
            ViewData["Poomsae11ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae11ID);
            ViewData["Poomsae12ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae12ID);
            ViewData["Poomsae21ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae21ID);
            ViewData["Poomsae22ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae22ID);
            ViewData["Poomsae31ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae31ID);
            ViewData["Poomsae32ID"] = new SelectList(Context.Poomsaes, "ID", "Name", category.Poomsae32ID);
            return View(category);
        }

        // GET: Categories/Delete/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await Context.Categories
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
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await Context.Categories.FindAsync(id);
            Context.Categories.Remove(category);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return Context.Categories.Any(e => e.ID == id);
        }
    }
}
