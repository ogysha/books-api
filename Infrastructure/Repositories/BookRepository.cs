using System.Collections.Generic;
using System.Linq;
using BooksApi.Core.Abstractions;
using BooksApi.Core.Entities;
using MongoDB.Driver;
using Book = BooksApi.Infrastructure.Documents.Book;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookRepository : IRepository<Core.Entities.Book>, IUnitOfWorkRepository
    {
        private const string Name = "Books";
        private readonly IMongoCollection<Book> _books;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Book, Core.Entities.Book> _bookMapper;

        public BookRepository(IUnitOfWork unitOfWork, IMongoDatabase database, IMapper<Book, Core.Entities.Book> bookMapper)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _books = database.GetCollection<Book>(Name);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            Book book = _bookMapper.ToDocument((Core.Entities.Book) entity);
            _books.InsertOne(book);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            Book updatedBook = _bookMapper.ToDocument((Core.Entities.Book) entity);
            _books.ReplaceOne(book => book.Id == updatedBook.Id, updatedBook);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            Book bookToDelete = _bookMapper.ToDocument((Core.Entities.Book) entity);
            _books.DeleteOne(book => book.Id == bookToDelete.Id);
        }

        public void Add(Core.Entities.Book entity)
        {
            _unitOfWork.RegisterNew(entity, this);
        }

        public void Update(Core.Entities.Book entity)
        {
            _unitOfWork.RegisterAmended(entity, this);
        }

        public void Remove(Core.Entities.Book entity)
        {
            _unitOfWork.RegisterDeleted(entity, this);
        }

        public IEnumerable<Core.Entities.Book> FindAll()
        {
            return _books.Find(FilterDefinition<Book>.Empty).ToEnumerable()
                .Select(book => _bookMapper.ToDomain(book));
        }

        public Core.Entities.Book FindOne(int id)
        {
            var book =_books.Find(b => b.BookId == id).ToEnumerable()
                .FirstOrDefault();

            return _bookMapper.ToDomain(book);
        }
    }
}