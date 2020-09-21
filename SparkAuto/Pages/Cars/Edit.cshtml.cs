﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Models.ViewModel;

namespace SparkAuto.Pages.Cars
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Car Car { get; set; }

        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _db.Car.Include(c => c.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
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

           // _db.Attach(Car).State = EntityState.Modified;

            try
            {
               // await _db.SaveChangesAsync();
                StatusMessage = "This feature is disabled";

            }
            catch (DbUpdateConcurrencyException)
            {
              return NotFound();
            }

            return RedirectToPage("./Index", new { userId = Car.UserId });
        }
    }
    
}