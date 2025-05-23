﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;
using Shared.DataTransferObjects.AuthorDtos;
using Shared.DataTransferObjects.BookDtos;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Add()
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookForManipulationDto book)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
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
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
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
