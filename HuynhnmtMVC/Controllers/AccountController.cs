using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using System.Threading.Tasks;

namespace HuynhnmtMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index(string search)
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            if (!string.IsNullOrEmpty(search))
            {
                accounts = accounts.Where(c => c.Email.Contains(search)).ToList();
                return View(accounts);
            }
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.CreateAccountAsync(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.UpdateAccountAsync(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account != null)
            {
                await _accountService.DeleteAccountAsync(id); // Pass id instead of account
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
