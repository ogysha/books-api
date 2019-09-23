using System.Collections.Generic;
using System.Linq;
using Books.Api.Core.Domain;
using Books.Api.Core.Entities;
using Books.Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Books.Api.Controllers
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
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Infrastructure.Entities.Book> Create(NewBookRequest newBookRequest)
        {
            var newBook = Book.Builder.CreateNew()
                .WithId(new ObjectId().ToString())
                .WithBookName(newBookRequest.BookName)
                .Build();

            _bookService.Create(newBook);

            return CreatedAtRoute("GetBook", new {id = newBook.Id}, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            _bookService.Update(bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            _bookService.Remove(book);

            return NoContent();
        }
    }
}