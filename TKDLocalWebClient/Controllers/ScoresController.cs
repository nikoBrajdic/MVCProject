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
    public class ScoresController : Controller
    {
        private readonly TKDManagerDbContext _context;

        public ScoresController(TKDManagerDbContext context)
        {
            _context = context;
        }

        // GET: Scores
        public async Task<IActionResult> Index()
        {
            var tKDManagerDbContext = _context.Scores.Include(s => s.Contestant);
            return View(await tKDManagerDbContext.ToListAsync());
        }

        // GET: Scores/Details/5
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
        public async Task<IActionResult> Create([Bind("ID,Round,Index,MinorMean,MinorTotal,GrandTotal,AccuracyMinorTotal,PresentationMinorTotal,AccuracyGrandTotal,PresentationGrandTotal,Presentation1,Presentation2,Presentation3,Presentation4,Presentation5,Presentation6,Presentation7,Presentation8,Presentation9,Accuracy1,Accuracy2,Accuracy3,Accuracy4,Accuracy5,Accuracy6,Accuracy7,Accuracy8,Accuracy9,ContestantId")] Score score)
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
