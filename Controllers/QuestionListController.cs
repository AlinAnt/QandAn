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
    public class QuestionListController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private DatabaseService _databaseService;

        public QuestionListController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, DatabaseService databaseService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _databaseService = databaseService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["Filter"] = searchString;
            var question = _dbContext.Questions.Where(s => s.QuestionTitle.Contains(searchString ?? ""));
            
            return View(await question.Include(q => q.User).ToListAsync());
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("ID,QuestionTitle, QuestionContent,QuestionCreateTime")] Question question)
        {
            ViewBag.Answers = new Answer();
            if (ModelState.IsValid)
            {  
                var user = await _userManager.GetUserAsync(User);
                question.User = user;
                question.UserId = user.Id;
            
                DateTime time = DateTime.Now;
                question.QuestionCreateTime = time;

                _dbContext.Questions.Add(question);
                await _dbContext.SaveChangesAsync();
                user.Questions.Add(question);

                return RedirectToAction("Index", "QuestionList");

            }
            return View(question);
        }
        
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_dbContext.Questions.Any(q => q.ID == id))
                return NotFound();
            

            var question = await _databaseService.GetQuestionById(id);
                            
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _dbContext.Questions.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid & question.UserId == user.Id)
            {
                _dbContext.Questions.Remove(question);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "QuestionList");
            }
            
            return View(question);
        }


    }
}