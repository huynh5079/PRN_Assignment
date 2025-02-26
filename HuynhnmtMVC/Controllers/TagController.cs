using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HuynhnmtMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return View(tags);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);
            await _tagService.CreateTagAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);
            await _tagService.UpdateTagAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag != null) await _tagService.DeleteTagAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
