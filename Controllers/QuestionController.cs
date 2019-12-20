using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using QandAn.Models;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    public class QuestionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public QuestionController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || !_dbContext.Questions.Any(q => q.ID == id))
            {
                return NotFound();
            }
            
            Question question = await _dbContext.Questions
                                                .Include(u => u.Answers)
                                                .ThenInclude(u => u.User)
                                                .Where(d => d.ID == id)
                                                .FirstOrDefaultAsync();
            return View(question);
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null && !_dbContext.Questions.Any(q => q.ID == id))
            {
                return NotFound();
            }

            var question = await _dbContext.Questions.FindAsync(id);
            return View(question);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,QuestionTitle, QuestionContent")] Question question)
        {
            if (!_dbContext.Questions.Any(q => q.ID ==question.ID))
            {   
                return NotFound();
            }

            var tempQuestion = await _dbContext.Questions.FindAsync(question.ID);
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid & tempQuestion.UserId == user.Id)
            {

                tempQuestion.QuestionTitle = question.QuestionTitle;
                tempQuestion.QuestionContent = question.QuestionContent;
                _dbContext.Update(tempQuestion);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "QuestionList");

            }
            return View(question);
        }

        [HttpPost]
        public async void AddRating(int answerId, int value)
        {
            var user = await _userManager.GetUserAsync(User);
            var answer = await _dbContext.Answers.Include(a => a.Voting).Where(a => a.ID == answerId).FirstOrDefaultAsync();

            if (!answer.Voting.ToList().Contains(user))
            {
                answer.Voting.Add(user);
                answer.Rating += value;
                await _dbContext.SaveChangesAsync();
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async void CreateAnswer(string AnswerContent, int questionId)
        {
            if (!_dbContext.Questions.Any(q => q.ID == questionId) || AnswerContent is null)
                return;

            var user = await _userManager.GetUserAsync(User);   
            DateTime time = DateTime.Now;
            Question question = await _dbContext.Questions
                                                .Include(u => u.Answers)
                                                .ThenInclude(u => u.User)
                                                .Where(d => d.ID == questionId)
                                                .FirstOrDefaultAsync();
                                
            var answer = new Answer { AnswerContent = AnswerContent , User = user, Question = question, AnswerTime = time };
            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            question.Answers.Add(answer);
            _dbContext.SaveChanges();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnswer(int? id)
        {
            if (id == null || !_dbContext.Answers.Any(q => q.ID == id))
                return NotFound();

            var answer = await _dbContext.Answers
                                         .Include(u => u.Question)
                                         .Include(u => u.User)
                                         .Where(d => d.ID == id)
                                         .FirstOrDefaultAsync();

           return View(answer);
        }
        
        [HttpPost, ActionName("DeleteAnswer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswerConfirmed(int id)
        {
            var answer = _dbContext.Answers.Include(a => a.Question)
                                           .ThenInclude(q => q.Answers)
                                           .Where(a => a.ID == id)
                                           .FirstOrDefault();


            var user = await _userManager.GetUserAsync(User);
            var is_admin =  await _userManager.IsInRoleAsync(user, "Admin");

            if ((answer.UserId == user.Id) || is_admin)
            {
                _dbContext.Answers.Remove(answer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Question", new {id = answer.Question.ID});

            }
            return View(answer);
        }
       
        
    }
}