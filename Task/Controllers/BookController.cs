using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Shared.DataTransferObjects.AuthorDtos;
using Shared.DataTransferObjects.BookDtos;

namespace Task.Controllers
{
    public class BookController : Controller
    {
        private readonly IServiceManager _service;
        public BookController(IServiceManager service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.BookService.GetAllBooksAsync(false);
            return View(allBooks);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookForManipulationDto book)
        {
            await _service.BookService.CreateBookAsync(book);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Guid bookId)
        {
            var book = await _service.BookService.GetBookAsync(bookId, trackChanges: false);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookForManipulationDto book)
        {
            await _service.BookService.UpdateBookAsync(book.Id, book, trackChanges: true);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid bookId)
        {
            await _service.BookService.DeleteBookAsync(bookId, trackChanges: false);
            return RedirectToAction("Index");
        }
    }
}
