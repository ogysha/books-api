using BooksApi.Core.Abstractions;
using BooksApi.Core.Entities;

namespace BooksApi.Infrastructure.Helpers
{
    public class EntityRepositoryPair
    {
        public EntityRepositoryPair(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            Entity = entity;
            Repository = repository;
        }

        public IAggregateRoot Entity { get; }
        public IUnitOfWorkRepository Repository { get; }

        public void PersistNew()
        {
            Repository.PersistCreationOf(Entity);
        }
    }
}