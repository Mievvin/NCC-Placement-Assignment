using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NHSWebApp.Pages
{
    public class CovidModel : PageModel
    {
        private readonly ILogger<CovidModel> _logger;

        public CovidModel(ILogger<CovidModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
    }
}