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
   
    public class Search : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AlinUser> _userManager;

        public Search(ApplicationDbContext context, UserManager<AlinUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> SearchString(string searchString)
        {
            var questions = from q in _context.Questions
                            select q;
            if(!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.QuestionTitle.Contains(searchString));
            }
            return View(await questions.ToListAsync());
        }
    }
}