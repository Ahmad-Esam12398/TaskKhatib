using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Shared.DataTransferObjects.AuthorDtos;

namespace Task.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IServiceManager _service;

        public AuthorController(IServiceManager service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAuthors = await _service.AuthorService.GetAllAuthorsAsync(false);
            return View(allAuthors);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AuthorForManipulationDto author)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            await _service.AuthorService.CreateAuthorAsync(author);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Guid AuthorId)
        {
            var author = await _service.AuthorService.GetAuthorAsync(AuthorId, trackChanges: false);
            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AuthorForManipulationDto author)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            await _service.AuthorService.UpdateAuthorAsync(author.Id, author, trackChanges: true);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid AuthorId)
        {
            await _service.AuthorService.DeleteAuthorAsync(AuthorId, trackChanges: false);
            return RedirectToAction("Index");
        }
    }
}
