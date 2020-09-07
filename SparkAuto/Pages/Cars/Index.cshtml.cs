﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models.ViewModel;

namespace SparkAuto.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public CarAndCustomerViewModel CarAndCustomerVM { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string userId = null)
        {
            if(userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            CarAndCustomerVM = new CarAndCustomerViewModel()
            {
                Cars = _db.Car.Where(c => c.UserId == userId).ToList(),
                ApplicationUserObj = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId),
            };

            return Page();
        }
    }
}