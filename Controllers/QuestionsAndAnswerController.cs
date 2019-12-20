using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using QandAn.Models;
using QandAn.Services;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{

    public class QuestionsAndAnswerController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AlinUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly StackService _stackService;
        private readonly Random rand = new Random();
        private Timer timer;

        public QuestionsAndAnswerController(StackService stackService, ApplicationDbContext context, UserManager<AlinUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _stackService = stackService;
        }

        public void SimulateLife(object state)
        {
            var count = _context.Answers.Count();
            _context.Answers.ToList()[rand.Next(0, count)].Rating += 1;
            _context.SaveChanges();
        }

        // GET: QuestionsAndAnswer
        
        public async Task<IActionResult> Index(string searchString)
        {

            
            ViewData["Filter"] = searchString;
            var question = from s in _context.Questions
                            select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                question = question.Where(s => s.QuestionTitle.Contains(searchString));
            }
            
            return View(await question.Include(q => q.User).ToListAsync());
        }
        
        [HttpPost]
        public async void AddRating(int answerId, int value)
        {
            var user = await _userManager.GetUserAsync(User);
            var answer = await _context.Answers.Include(a => a.Voting).Where(a => a.ID == answerId).FirstOrDefaultAsync();


            if (!answer.Voting.ToList().Contains(user))
            {
                answer.Voting.Add(user);
                answer.Rating += value;
                await _context.SaveChangesAsync();
            }
            
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

        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Import()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Import(QandAn.ViewModels.ImportViewModel model)
        {
            Tuple<string, string> data = _stackService.GetData(model.Url);
            var user = await _userManager.GetUserAsync(User);
            Question question = new Question{ User=user, UserId=user.Id, 
                                              QuestionTitle=data.Item1,
                                              QuestionContent=data.Item2, 
                                              QuestionCreateTime = DateTime.Now };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            user.Questions.Add(question);

            return RedirectToAction("Index");
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

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                user.Questions.Add(question);

                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        [Authorize(Roles = "Admin,User")]
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,QuestionTitle, QuestionContent")] Question question)
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
                    tempQuestion.QuestionTitle = question.QuestionTitle;
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

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
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

        
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async void CreateAnswer(string AnswerContent, int questionId)
        {
           
            var user = await _userManager.GetUserAsync(User);   
            DateTime time = DateTime.Now;
            Question question = await _context.Questions
                                    .Include(u => u.Answers)
                                    .ThenInclude(u => u.User)
                                    .Where(d => d.ID == questionId)
                                    .FirstOrDefaultAsync();
                                
            var answer = new Answer { AnswerContent = AnswerContent , User = user, Question = question, AnswerTime = time };
            _context.Answers.Add(answer);
            _context.SaveChanges();

            question.Answers.Add(answer);
            _context.SaveChanges();
          
        }

        //[HttpPost, ActionName("DeleteAnswer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnswer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                            .Include(u => u.Question)
                            .Include(u => u.User)
                            .Where(d => d.ID == id)
                            .FirstOrDefaultAsync();
            if (answer == null)
            {
                return NotFound();
            }

           return View(answer);
        }

        [HttpPost, ActionName("DeleteAnswer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswerConfirmed(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
                                    
            var user = await _userManager.GetUserAsync(User);
            var is_admin =  await _userManager.IsInRoleAsync(user, "Admin");

            if ((answer.UserId == user.Id) || is_admin)
            {
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(answer);
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
