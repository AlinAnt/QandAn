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
        
        
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Question question = await _context.Questions
                    .Include(u => u.Answers)
                    .ThenInclude(u => u.User)
                    .Where(d => d.ID == id)
                    .FirstOrDefaultAsync();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,QuestionContent,QuestionCreateTime")] Question question)
        {
            ViewBag.Answers = new Answer();
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                question.User = user;
                question.UserId = user.Id;
            
                DateTime time = DateTime.Now;
                question.QuestionCreateTime = time;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,QuestionContent")] Question question)
        {
            if (id != question.ID)
            {   
                return NotFound();
            }
            var tempQuestion = await _context.Questions.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid & tempQuestion.UserId == user.Id)
            {
                try
                {  
                    tempQuestion.QuestionContent = question.QuestionContent;
                    _context.Update(tempQuestion);
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


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FindAsync(id);
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
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid & question.UserId == user.Id)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }

        public async Task<IActionResult> MoreAnswer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return PartialView("AnswerListPartial", question.Answers);
        }

          [HttpPost]
        public async Task<IActionResult> CreateAnswer(string AnswerContent, int questionId)
        {
           
                var user = await _userManager.GetUserAsync(User);
                Question question = await _context.Questions
                                        .Include(u => u.Answers)
                                        .ThenInclude(u => u.User)
                                        .Where(d => d.ID == questionId)
                                        .FirstOrDefaultAsync();
                                  
                var answer = new Answer { AnswerContent = AnswerContent , User = user, Question = question };
                _context.Answers.Add(answer);
                _context.SaveChanges();

                question.Answers.Add(answer);
                _context.SaveChanges();

            return RedirectToAction("Details", "QuestionsAndAnswer", new {id = questionId});
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
