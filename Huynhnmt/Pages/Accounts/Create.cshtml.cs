using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Accounts
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ISystemAccountService _accountService;

        public CreateModel(ISystemAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public SystemAccount Account { get; set; } = new SystemAccount();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _accountService.AddAccountAsync(Account);
            return RedirectToPage("./Index");
        }
    }
}
