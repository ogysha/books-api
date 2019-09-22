using System;
using System.Linq;
using Books.Api.Core.Entities;
using Books.Api.Core.Services;
using Books.Api.Infrastructure.Mappers;
using Books.Api.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace Books.Api.Should
{
    public class BooksServiceShould
    {
        public BooksServiceShould()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var unitOfWork = new UnitOfWork(mongoClient);
            _booksService = new BookService(
                unitOfWork,
                new BookRepository(unitOfWork, mongoClient.GetDatabase("BookstoreDb"), new BookMapper()));
        }

        private readonly BookService _booksService;

        [Fact]
        public void Create_a_new_book()
        {
            var booksCountBeforeInsertion = _booksService.Get().Count();

            var book = Book.Builder.CreateNew()
                .WithId(new ObjectId().ToString())
                .WithBookName("Alice in Wonderland")
                .Build();
            _booksService.Create(book);

            Assert.Equal(booksCountBeforeInsertion + 1, _booksService.Get().Count());
        }
    }
}