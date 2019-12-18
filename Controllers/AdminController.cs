using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QandAn.Data;

using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    
    public class AdminController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AlinUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AdminController(ApplicationDbContext context, UserManager<AlinUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
          
        }

        // GET: QuestionsAndAnswer
        Dictionary <AlinUser, string> usrole = new Dictionary<AlinUser, string>();
        public async Task<IActionResult> UserList()
        {
            foreach (var user in _userManager.Users.ToList())
            {   
                var is_admin =  await _userManager.IsInRoleAsync(user, "Admin");
                if(is_admin)
                {
                    usrole.Add(user,"admin");
                }
                else
                {
                    usrole.Add(user, "user");
                }
            }
            return View(usrole);
        }

       
        
    }
}
