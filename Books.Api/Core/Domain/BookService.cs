using System.Collections.Generic;
using Books.Api.Core.Abstractions;
using Book = Books.Api.Core.Entities.Book;

namespace Books.Api.Core.Domain
{
    public class BookService
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork, IRepository<Book> booksRepository)
        {
            _unitOfWork = unitOfWork;
            _booksRepository = booksRepository;
        }

        public IEnumerable<Book> Get()
        {
            return _booksRepository.FindAll();
        }

        public Book Get(string id)
        {
            return _booksRepository.FindOne(id);
        }

        public void Create(Book book)
        {
            _booksRepository.Add(book);
            _unitOfWork.Commit();
        }

        public void Update(Book bookIn)
        {
            _booksRepository.Update(bookIn);
            _unitOfWork.Commit();
        }

        public void Remove(Book bookIn)
        {
            _booksRepository.Remove(bookIn);
            _unitOfWork.Commit();
        }
    }
}