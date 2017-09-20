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
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Answers.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.Answers
                .Include(q => q.ApplicationUser)
                .Include(i => i.QuestionsModel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] string id, [FromForm] string body)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newAnswer = new AnswersModel {QuestionsModelId = id, Body = body, ApplicationUserId = user.Id};
                _context.Add(newAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Questions", new {id});
            }
            return View();
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.Answers.SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }
            return View(answersModel);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Body,VoteCount,PostDate,UserId,QuestionId")] AnswersModel answersModel)
        {
            if (id != answersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswersModelExists(answersModel.Id))
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
            return View(answersModel);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.Answers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var answersModel = await _context.Answers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Answers.Remove(answersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswersModelExists(string id)
        {
            return _context.Answers.Any(e => e.Id == id);
        }
    }
}
