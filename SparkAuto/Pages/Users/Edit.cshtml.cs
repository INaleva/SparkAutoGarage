using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Utility;

namespace SparkAuto.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;


        public EditModel(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var userInDb = await _db.ApplicationUser.SingleOrDefaultAsync(u => u.Id == ApplicationUser.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userInDb.Name = ApplicationUser.Name;
                    userInDb.PhoneNumber = ApplicationUser.PhoneNumber;
                    userInDb.Address = ApplicationUser.Address;
                    userInDb.City = ApplicationUser.City;
                    userInDb.PostalCode = ApplicationUser.PostalCode;
                    userInDb.IsAdmin = ApplicationUser.IsAdmin;


                    if (ApplicationUser.IsAdmin)
                    {
                        await _userManager.AddToRoleAsync(userInDb, SD.AdminEndUser);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(userInDb, SD.AdminEndUser);
                        await _userManager.AddToRoleAsync(userInDb, SD.CustomerEndUser);
                    }

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }


    }
}