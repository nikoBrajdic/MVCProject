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
    [Route("[controller]")]
    [Route("natjecatelji")]
    public class ContestantController : Controller
    {
        private readonly TKDManagerDbContext Context;

        public ContestantController(TKDManagerDbContext Context)
        {
            this.Context = Context;
        }

        // GET: Contestants
        [Route("[action]")]
        [Route("{[action]:regex(^(Pocetna|Inde(ks|x).*)?$)}")]
        public async Task<IActionResult> Index()
        {
            var tKDManagerDbContext = Context.Contestants.Include(c => c.Category).Include(c => c.Team);
            return View(await tKDManagerDbContext.ToListAsync());
        }

        // GET: Contestants/Details/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Pregled|Deta(lji|ils))$)}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await Context.Contestants
                .Include(c => c.Category)
                .Include(c => c.Team)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // GET: Contestants/Create
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(Context.Categories, "ID", "Name");
            ViewData["TeamId"] = new SelectList(Context.Teams, "ID", "Name");
            return View();
        }

        // POST: Contestants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public async Task<IActionResult> Create([Bind("Name,Surname,TrackPath,TeamId,CategoryId")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                Context.Add(contestant);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(Context.Categories, "ID", "Name", contestant.CategoryId);
            ViewData["TeamId"] = new SelectList(Context.Teams, "ID", "Name", contestant.TeamId);
            return View(contestant);
        }

        // GET: Contestants/Edit/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await Context.Contestants.FindAsync(id);
            if (contestant == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(Context.Categories, "ID", "Name", contestant.CategoryId);
            ViewData["TeamId"] = new SelectList(Context.Teams, "ID", "Name", contestant.TeamId);
            return View(contestant);
        }

        // POST: Contestants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,TrackPath,TeamId,CategoryId")] Contestant contestant)
        {
            if (id != contestant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(contestant);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestantExists(contestant.ID))
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
            ViewData["CategoryId"] = new SelectList(Context.Categories, "ID", "Name", contestant.CategoryId);
            ViewData["TeamId"] = new SelectList(Context.Teams, "ID", "Name", contestant.TeamId);
            return View(contestant);
        }

        // GET: Contestants/Delete/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await Context.Contestants
                .Include(c => c.Category)
                .Include(c => c.Team)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // POST: Contestants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contestant = await Context.Contestants.FindAsync(id);
            Context.Contestants.Remove(contestant);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestantExists(int id)
        {
            return Context.Contestants.Any(e => e.ID == id);
        }
    }
}
