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
using System.Web;
using Microsoft.AspNetCore.Http;
using NCCWebApp.Data;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using RestSharp;
using System.Diagnostics;
using Newtonsoft.Json;
using Nancy.Json;
using Microsoft.AspNetCore.Razor.Language;

namespace NHSWebApp.Pages
{
    [Authorize]
    public class PrescriptionModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public PrescriptionModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty, EmailAddress, Required, Display(Name = "Email Address")]
        public string OrderEmail { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            OrderEmail = userName;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        class RootObject
        {
            [JsonProperty("hasPart")]
            public List<hasPart> hasPart { get; set; }
        }

        class hasPart
        {
            [JsonProperty("@type")]
            public string type { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
            [JsonProperty("text")]
            public string text { get; set; }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (ModelState.IsValid)
            {
                var pageURL = "https://api.nhs.uk/conditions/"; //Calls the API to receive treatment information about the condition the user input during registration
                var finalPageURL = String.Concat(pageURL, user.Condition);
                var subscriptionKey = "58ceba1b9c0749ab823ab64db4676835";

                var client = new RestClient(finalPageURL);
                var request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("subscription-key", subscriptionKey);
                IRestResponse response = client.Execute(request);
                var content = response.Content;

                RootObject obj = new JavaScriptSerializer().Deserialize<RootObject>(content);
                var symptomstext = "";
                foreach (var item in obj.hasPart) //Iterates through the parts of the JSON response to find the correct one
                {
                    if (item.name== "self_care")
                    {
                        symptomstext = item.text;
                    }
                }
                //Section below sets up the email with the information from above 
                var body = $@"Hello {user.Email} ! Please see below to see the prescription regarding {user.Condition} .<br/>
                {symptomstext}";
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = @"C:\MailPickup";
                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = $@"NHSWebApp - Your {user.Condition} prescription";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("treatment@nhswebapp.co.uk");
                    await smtp.SendMailAsync(message);
                }
                return RedirectToPage("EmailSuccess");
            }
            return Page();
        }

    }
}

