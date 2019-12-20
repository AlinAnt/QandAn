
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QandAn.Data;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    public class QuestionListController : Controller
    {
        private readonly UserManager<AlinUser> _userManager;
        private readonly ApplicationDbContext _dbContext;


        public QuestionListController(ApplicationDbContext dbContext, UserManager<AlinUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

            
    }
}