using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using FURepositories.Interfaces;

namespace SampleTest.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public RegisterInputModel RegisterData { get; set; } = new RegisterInputModel();

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var result = await _userService.RegisterAsync(RegisterData.FullName, RegisterData.Email, RegisterData.Password, RegisterData.Role);
            var result = await _userService.RegisterAsync(RegisterData.FullName, RegisterData.Email, RegisterData.Password,2);
            Message = result ? "Registration successful!" : "Email already exists!";
            return Page();
        }

        public class RegisterInputModel
        {
            [Required]
            public string FullName { get; set; } = string.Empty;

            [Required, EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            //[Required]
            //public int Role { get; set; }
        }
    }
}
