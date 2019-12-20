using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QandAn.Data;
using QandAn.Models;
using QandAn.Services;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    public class QuestionImportController : Controller
    {
        private readonly StackService _stackService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public QuestionImportController(StackService stackService, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _stackService = stackService;
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
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

            _dbContext.Questions.Add(question);

            await _dbContext.SaveChangesAsync();
            user.Questions.Add(question);

            return RedirectToAction("Index", "QuestionList");
        }


    }
}