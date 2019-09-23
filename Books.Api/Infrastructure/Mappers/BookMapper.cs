using Books.Api.Core.Abstractions;
using Books.Api.Infrastructure.Entities;
using MongoDB.Bson;

namespace Books.Api.Infrastructure.Mappers
{
    public class BookMapper : IMapper<Book, Core.Entities.Book>
    {
        public Book ToDocument(Core.Entities.Book entity)
        {
            return new Book
            {
                Id = new ObjectId(entity.Id),
                Author = entity.Author,
                Category = entity.Category,
                Price = entity.Price,
                BookName = entity.BookName
            };
        }

        public Core.Entities.Book ToDomain(Book book)
        {
            return Core.Entities.Book.Builder.CreateNew()
                .WithId(book.Id.ToString())
                .WithBookName(book.BookName)
                .Build();
        }
    }
}