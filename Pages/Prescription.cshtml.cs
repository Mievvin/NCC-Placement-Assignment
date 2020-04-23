using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NCCWebApp.Models;

namespace NHSWebApp.Pages
{
    [Authorize]
    public class PrescriptionModel : PageModel
    {
        public string UserId { get; set; }
        private readonly ILogger<PrescriptionModel> _logger;

        public PrescriptionModel(ILogger<PrescriptionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            
        }
    }
}
