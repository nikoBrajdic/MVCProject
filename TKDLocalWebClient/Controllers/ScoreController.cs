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
    [Route("bodovi")]
    public class ScoreController : Controller
    {

        private readonly TKDManagerDbContext _context;

        public ScoreController(TKDManagerDbContext context)
        {
            _context = context;
        }

        // GET: Scores
        [Route("[action]")]
        [Route("{[action]:regex(^(Pocetna|Inde(ks|x).*)?$)}")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Dict = new Dictionary<string, string>
            {
                { nameof(Score.Round), "krug" },
                { nameof(Score.Index), "indeks" },
                { nameof(Score.Contestant), "ime" },
                { nameof(Score.MinorMean), "srednja" },
                { nameof(Score.MinorTotal), "srednja svi" },
                { nameof(Score.GrandTotal), "svi" },
                { nameof(Score.AccuracyMinorTotal), "T" },
                { nameof(Score.PresentationMinorTotal), "D" },
                { nameof(Score.AccuracyGrandTotal), "svi T" },
                { nameof(Score.PresentationGrandTotal), "svi D" },
                { nameof(Score.Accuracy1), "T1" },
                { nameof(Score.Accuracy2), "T2" },
                { nameof(Score.Accuracy3), "T3" },
                { nameof(Score.Accuracy4), "T4" },
                { nameof(Score.Accuracy5), "T5" },
                { nameof(Score.Accuracy6), "T6" },
                { nameof(Score.Accuracy7), "T7" },
                { nameof(Score.Accuracy8), "T8" },
                { nameof(Score.Accuracy9), "T9" },
                { nameof(Score.Presentation1), "D1" },
                { nameof(Score.Presentation2), "D2" },
                { nameof(Score.Presentation3), "D3" },
                { nameof(Score.Presentation4), "D4" },
                { nameof(Score.Presentation5), "D5" },
                { nameof(Score.Presentation6), "D6" },
                { nameof(Score.Presentation7), "D7" },
                { nameof(Score.Presentation8), "D8" },
                { nameof(Score.Presentation9), "D9" }
            };

            //wrote it like this so i wouldn't forget what's what, + it has extended functionality
            var tKDManagerDbContext = _context.Scores.Include(s => s.Contestant);
            return View(await tKDManagerDbContext.ToListAsync());
        }

        // GET: Scores/Details/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Pregled|Deta(lji|ils))$)}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Contestant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // GET: Scores/Create
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public IActionResult Create()
        {
            ViewData["ContestantId"] = new SelectList(_context.Contestants, "ID", "Name");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Kreiraj|Novi|Create)$)}")]
        public async Task<IActionResult> Create([Bind("Round,Index,MinorMean,MinorTotal,GrandTotal,AccuracyMinorTotal,PresentationMinorTotal,AccuracyGrandTotal,PresentationGrandTotal,Presentation1,Presentation2,Presentation3,Presentation4,Presentation5,Presentation6,Presentation7,Presentation8,Presentation9,Accuracy1,Accuracy2,Accuracy3,Accuracy4,Accuracy5,Accuracy6,Accuracy7,Accuracy8,Accuracy9,ContestantId")] Score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContestantId"] = new SelectList(_context.Contestants, "ID", "Name", score.ContestantId);
            return View(score);
        }

        // GET: Scores/Edit/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["ContestantId"] = new SelectList(_context.Contestants, "ID", "Name", score.ContestantId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Uredi|Edit(iraj))$)}/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Round,Index,MinorMean,MinorTotal,GrandTotal,AccuracyMinorTotal,PresentationMinorTotal,AccuracyGrandTotal,PresentationGrandTotal,Presentation1,Presentation2,Presentation3,Presentation4,Presentation5,Presentation6,Presentation7,Presentation8,Presentation9,Accuracy1,Accuracy2,Accuracy3,Accuracy4,Accuracy5,Accuracy6,Accuracy7,Accuracy8,Accuracy9,ContestantId")] Score score)
        {
            if (id != score.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoreExists(score.ID))
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
            ViewData["ContestantId"] = new SelectList(_context.Contestants, "ID", "Name", score.ContestantId);
            return View(score);
        }

        // GET: Scores/Delete/5
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Contestant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Route("{[action]:regex(^(Izbrisi|Delete)$)}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var score = await _context.Scores.FindAsync(id);
            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoreExists(int id)
        {
            return _context.Scores.Any(e => e.ID == id);
        }
    }
}
