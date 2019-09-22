using System;
using Books.Api.Core.Abstractions;
using Books.Api.Core.Entities;
using Books.Api.Infrastructure.Helpers;
using MongoDB.Driver;

namespace Books.Api.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoClient _client;

        private readonly Lazy<EntitiesPersister> _lazyAmendedEntities
            = new Lazy<EntitiesPersister>(() => new EntitiesPersister());

        private readonly Lazy<EntitiesPersister> _lazyNewEntities
            = new Lazy<EntitiesPersister>(() => new EntitiesPersister());

        private readonly Lazy<EntitiesPersister> _lazyRemovedEntities
            = new Lazy<EntitiesPersister>(() => new EntitiesPersister());

        public UnitOfWork(MongoClient client)
        {
            _client = client;
        }

        private EntitiesPersister NewEntities => _lazyNewEntities.Value;
        private EntitiesPersister AmendedEntities => _lazyAmendedEntities.Value;

        public void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            using (var session = _client.StartSession())
            {
                session.StartTransaction();
                _lazyNewEntities.Value.PersistAllNew();
                session.CommitTransaction();
            }
        }

        public void Rollback()
        {
            NewEntities.Clear();
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            AmendedEntities.Add(new EntityRepositoryPair(entity, repository));
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            NewEntities.Add(new EntityRepositoryPair(entity, repository));
        }
    }
}