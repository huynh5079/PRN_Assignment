using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Tags
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ITagService _tagService;

        public EditModel(ITagService tagService)
        {
            _tagService = tagService;
        }

        [BindProperty]
        public Tag Tag { get; set; } = new Tag();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null)
                return NotFound();

            Tag = tag;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _tagService.UpdateTagAsync(Tag);
            return RedirectToPage("./Index");
        }
    }
}
