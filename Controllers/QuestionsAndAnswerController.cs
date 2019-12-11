using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using QandAn.Models;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
   
    public class QuestionsAndAnswerController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AlinUser> _userManager;

        public QuestionsAndAnswerController(ApplicationDbContext context, UserManager<AlinUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: QuestionsAndAnswer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.Include(q => q.User).ToListAsync());
        }

        // GET: QuestionsAndAnswer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: QuestionsAndAnswer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionsAndAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,QuestionContent,QuestionCreateTime")] Question question)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                question.User = user;
                question.UserId = user.Id;
            
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                user.Questions.Add(question);

                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: QuestionsAndAnswer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: QuestionsAndAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User,QuestionContent,QuestionCreateTime")] Question question)
        {
            if (id != question.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.ID))
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
            return View(question);
        }

        // GET: QuestionsAndAnswer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: QuestionsAndAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }

        public async Task<IActionResult> MoreAnswer(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return PartialView("AnswerListPartial", question.Answers);
        }

          [HttpPost]
        public async Task<IActionResult> CreateAnswer([Bind("ID,User,ID,AnswerContent")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                answer.AnswerTime = DateTime.Now;
                _context.Add(answer);
                await _context.SaveChangesAsync();
                                  
                                  
            }
            return RedirectToAction("Details", new { 
                id = answer.QuestionID });
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
