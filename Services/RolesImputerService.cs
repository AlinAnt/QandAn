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

namespace QandAn.Services
{
    public class RolesImputerService 
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AlinUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesImputerService(ApplicationDbContext context, UserManager<AlinUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            Console.WriteLine("fjdsa;dlfjfjjadsfalsfdjasfjdaFJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ");
            
        }
        
        public async void RolesImputer()
        {
            string[] roleNames = { "User", "Admin"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {   
                //create the roles and seed them to the database:
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {  
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }  
        }
        
    }
}