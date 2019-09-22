using Books.Api.Core.Abstractions;
using Books.Api.Core.Entities;

namespace Books.Api.Infrastructure.Helpers
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