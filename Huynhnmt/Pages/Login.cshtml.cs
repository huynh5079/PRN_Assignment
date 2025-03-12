using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;

namespace Huynhnmt_SE17C04_A02.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ISystemAccountService _systemAccountService;

        public LoginModel(ISystemAccountService systemAccountService)
        {
            _systemAccountService = systemAccountService;
        }

        [BindProperty]
        public string Email { get; set; } = "";
        [BindProperty]
        public string Password { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _systemAccountService.AuthenticateAsync(Email, Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.AccountName),
                new Claim(ClaimTypes.Email, user.AccountEmail),
                new Claim("AccountRole", user.AccountRole.ToString()) // Debug this
            };

            Console.WriteLine($"User {user.AccountName} has role: {user.AccountRole}");

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true });


            return RedirectToPage("/Index");
        }
    }
}
