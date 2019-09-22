
using Books.Api.Core.Entities;

namespace Books.Api.Core.Abstractions
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