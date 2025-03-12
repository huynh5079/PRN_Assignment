using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Tags
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ITagService _tagService;

        public CreateModel(ITagService tagService)
        {
            _tagService = tagService;
        }

        [BindProperty]
        public Tag Tag { get; set; } = new Tag();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _tagService.AddTagAsync(Tag);
            return RedirectToPage("./Index");
        }
    }
}
