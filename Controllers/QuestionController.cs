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
        private DatabaseService _databaseService;

        public QuestionController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, DatabaseService databaseService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _databaseService = databaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || !_dbContext.Questions.Any(q => q.ID == id))
                return NotFound();
            
            var question = await _databaseService.GetQuestionById(id);

            return View(question);
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null && !_dbContext.Questions.Any(q => q.ID == id))
                return NotFound();

            var question = await _databaseService.GetQuestionById(id);
            return View(question);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,QuestionTitle, QuestionContent")] Question question)
        {
            if (!_dbContext.Questions.Any(q => q.ID == question.ID))
                return NotFound();
        

            var tempQuestion = await _databaseService.GetQuestionById(question.ID);
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
            var answer = await _databaseService.GetAnswerById(answerId);

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
            Question question = await _databaseService.GetQuestionById(questionId);
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

            var answer = await _databaseService.GetAnswerById((int) id);

           return View(answer);
        }
        
        [HttpPost, ActionName("DeleteAnswer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswerConfirmed(int id)
        {
            var answer = await _databaseService.GetAnswerById(id);

            var user = await _userManager.GetUserAsync(User);
            var is_admin =  await _userManager.IsInRoleAsync(user, "Admin");

            if (is_admin || (answer.UserId == user.Id))
            {
                _dbContext.Answers.Remove(answer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Question", new {id = answer.Question.ID});

            }
            return View(answer);
        }
       
        
    }
}