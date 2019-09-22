using BooksApi.Core.Abstractions;
using BooksApi.Infrastructure.Documents;
using ExpressMapper.Extensions;

namespace BooksApi.Infrastructure.Mappers
{
    public class BookMapper : IMapper<Book, Core.Entities.Book>
    {
        public Book ToDocument(Core.Entities.Book entity)
        {
            return entity.Map<Core.Entities.Book, Book>();
        }

        public Core.Entities.Book ToDomain(Book book)
        {
            return book.Map<Book, Core.Entities.Book>();
        }
    }
}