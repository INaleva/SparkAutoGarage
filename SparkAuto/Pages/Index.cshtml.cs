﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SparkAuto.Utility;

namespace SparkAuto.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated )
            {
                return RedirectToPage("/ServiceTypes/Index");
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
    }
}