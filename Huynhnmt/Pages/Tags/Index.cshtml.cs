using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Tags
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ITagService _tagService;

        public IndexModel(ITagService tagService)
        {
            _tagService = tagService;
        }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public async Task OnGetAsync()
        {
            Tags = (List<Tag>)await _tagService.GetAllTagsAsync();
        }
    }
}
