using System.Collections.Generic;
using Books.Api.Core.Entities;

namespace Books.Api.Core.Abstractions
{
    public interface IRepository<TDomain> where TDomain : IAggregateRoot
    {
        void Add(TDomain entity);
        void Update(TDomain entity);
        void Remove(TDomain entity);
        IEnumerable<TDomain> FindAll();
        TDomain FindOne(int id);
    }
}