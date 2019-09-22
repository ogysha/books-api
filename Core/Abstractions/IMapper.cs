using BooksApi.Core.Entities;

namespace BooksApi.Core.Abstractions
{
    public interface IMapper<TDocument, TDomain> where TDomain : IAggregateRoot
    {
        TDocument ToDocument(TDomain entity);
        TDomain ToDomain(TDocument book);
    }
}