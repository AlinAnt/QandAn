 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QandAn.Models;
using QandAn.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    public class AnswerController : Controller
    {
        private readonly UserManager<AlinUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AnswerController(ApplicationDbContext dbContext,  UserManager<AlinUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int questionId)
        {
            Question question = await _dbContext.Questions
                    .Include(u => u.Answers)
                    .ThenInclude(u => u.User)
                    .Include(u => u.UserId)
                    .Where(d => d.ID == questionId)
                    .FirstOrDefaultAsync();
            if(question == null)
                return NotFound();
            return View(question);
        }
    }
}
