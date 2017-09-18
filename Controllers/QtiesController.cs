using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOAuth.Data;
using StackOAuth.Models;

namespace StackOAuth.Controllers
{
    public class QtiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QtiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Qties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qties.ToListAsync());
        }

        // GET: Qties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtiesModel = await _context.Qties
                .SingleOrDefaultAsync(m => m.Id == id);
            if (qtiesModel == null)
            {
                return NotFound();
            }

            return View(qtiesModel);
        }

        // GET: Qties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionId,TagsId")] QtiesModel qtiesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qtiesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qtiesModel);
        }

        // GET: Qties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtiesModel = await _context.Qties.SingleOrDefaultAsync(m => m.Id == id);
            if (qtiesModel == null)
            {
                return NotFound();
            }
            return View(qtiesModel);
        }

        // POST: Qties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionId,TagsId")] QtiesModel qtiesModel)
        {
            if (id != qtiesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qtiesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QtiesModelExists(qtiesModel.Id))
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
            return View(qtiesModel);
        }

        // GET: Qties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtiesModel = await _context.Qties
                .SingleOrDefaultAsync(m => m.Id == id);
            if (qtiesModel == null)
            {
                return NotFound();
            }

            return View(qtiesModel);
        }

        // POST: Qties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qtiesModel = await _context.Qties.SingleOrDefaultAsync(m => m.Id == id);
            _context.Qties.Remove(qtiesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QtiesModelExists(int id)
        {
            return _context.Qties.Any(e => e.Id == id);
        }
    }
}
