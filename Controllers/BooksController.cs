using System.Collections.Generic;
using System.Linq;
using BooksApi.Core.Entities;
using BooksApi.Core.Services;
using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> books = _bookService.Get().ToList();

            return base.Ok(books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Infrastructure.Documents.Book> Create(NewBookRequest newBookRequest)
        {
            var newBook = Book.Builder.CreateNew()
                .WithBookName(newBookRequest.BookName)
                .Build();

            _bookService.Create(newBook);

            return CreatedAtRoute("GetBook", new {id = newBook.Id.ToString()}, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            _bookService.Update(bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            _bookService.Remove(book);

            return NoContent();
        }
    }
}