using FUBusiness.Data.Entities;
using FURepositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleTest.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginModel(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public string LoginIdentifier { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; } = "";

        public void OnGet()
        {
            // Just display login form
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(LoginIdentifier) || string.IsNullOrEmpty(Password))
            {
                Message = "Please fill all fields!";
                return Page();
            }

            var user = await _userService.AuthenticateAsync(LoginIdentifier, Password);

            if (user == null)
            {
                Message = "Invalid credentials!";
                return Page();
            }

            // Save session after successful login
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToPage("/Index");  // redirect to home
        }
    }
}
    
