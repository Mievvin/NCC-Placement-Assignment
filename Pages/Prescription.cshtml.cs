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
            //UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
        }
        /*
        // Stores UserManager
        private readonly UserManager<ApplicationUser> _manager;

        // Inject UserManager using dependency injection.
        // Works only if you choose "Individual user accounts" during project creation.
        public PrivacyModel(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        // You can also just take part after return and use it in async methods.
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }

        // Generic demo method.
        public async Task DemoMethod()
        {
            var user = await GetCurrentUser();

            string userId = user.Id;
            string userCondition = user.Condition;
        }
        */
    }
}
