using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOAuth.Data;
using StackOAuth.Models;

namespace StackOAuth.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Comments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.Comments
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commentsModel == null)
            {
                return NotFound();
            }

            return View(commentsModel);
        }

        // GET: Comments/Create
        public IActionResult Create(string QuestionId)
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] string id, [FromForm] string body)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newAnswer = new CommentsModel { QuestionId = id, Body = body, UserId = user.Id };
                var answer = await _context.Answers.SingleOrDefaultAsync(s => s.Id == id);
                _context.Add(newAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Questions", new { id });
            }
            return View();
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.Comments.SingleOrDefaultAsync(m => m.Id == id);
            if (commentsModel == null)
            {
                return NotFound();
            }
            return View(commentsModel);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Body,PostDate,UserId")] CommentsModel commentsModel)
        {
            if (id != commentsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsModelExists(commentsModel.Id))
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
            return View(commentsModel);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.Comments
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commentsModel == null)
            {
                return NotFound();
            }

            return View(commentsModel);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var commentsModel = await _context.Comments.SingleOrDefaultAsync(m => m.Id == id);
            _context.Comments.Remove(commentsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsModelExists(string id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
