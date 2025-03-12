using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Accounts
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ISystemAccountService _accountService;

        public IndexModel(ISystemAccountService accountService)
        {
            _accountService = accountService;
        }

        public List<SystemAccount> Accounts { get; set; } = new List<SystemAccount>();

        public async Task OnGetAsync()
        {
            Accounts = (List<SystemAccount>)await _accountService.GetAllAccountsAsync();
        }
    }
}
