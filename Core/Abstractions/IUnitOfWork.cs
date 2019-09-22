
using BooksApi.Core.Entities;

namespace BooksApi.Core.Abstractions
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);

        void Commit();
        void Rollback();
    }
}