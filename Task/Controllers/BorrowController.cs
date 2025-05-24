using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;

namespace Task.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IServiceManager _service;
        public BorrowController(IServiceManager service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAuthors = await _service.AuthorService.GetAllAuthorsAsync(trackChanges: false);
            List<SelectListItem> AuthorsList = allAuthors.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var AllGenres = await _service.GenreService.GetAllGenresAsync(trackChanges: false);
            List<SelectListItem> GenresList = AllGenres.Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.Id.ToString()
            }).ToList();
            ViewData["authors"] = AuthorsList;
            ViewData["genres"] = GenresList;
            var allBooks = await _service.BookService.GetAllBooksAsync(false);
            return View(allBooks);
        }
        public async Task<IActionResult> Transactions()
        {
            var transactions = await _service.TransactionService.GetAllTransactionsAsync(trackChanges: false);
            return View(transactions);
        }
        public async Task<IActionResult> Borrow(Guid bookId)
        {
            try
            {
                await _service.BookService.BorrowBookAsync(bookId, trackChanges: true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Error", ex.Message);
            }
        }
        public async Task<IActionResult> Return(Guid bookId)
        {
            try
            {
                await _service.BookService.ReturnBookAsync(bookId, trackChanges: true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Error", ex.Message);
            }
        }
    }
}
