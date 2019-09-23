using System;
using Books.Api.Core.Abstractions;
using Books.Api.Core.Entities;
using Books.Api.Infrastructure.Helpers;
using Books.Api.Infrastructure.Helpers.Abstractions;
using MongoDB.Driver;

namespace Books.Api.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoClient _client;

        private readonly Lazy<IAllAmendedPersistable> _lazyAmendedEntities
            = new Lazy<IAllAmendedPersistable>(() => new EntitiesPersister());

        private readonly Lazy<IAllNewPersistable> _lazyNewEntities
            = new Lazy<IAllNewPersistable>(() => new EntitiesPersister());

        private readonly Lazy<IAllRemovedPersistable> _lazyRemovedEntities
            = new Lazy<IAllRemovedPersistable>(() => new EntitiesPersister());

        public UnitOfWork(MongoClient client)
        {
            _client = client;
        }

        private IAllNewPersistable NewEntities => _lazyNewEntities.Value;
        private IAllAmendedPersistable AmendedEntities => _lazyAmendedEntities.Value;
        private IAllRemovedPersistable RemovedEntities => _lazyRemovedEntities.Value;

        public void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            using (var session = _client.StartSession())
            {
                session.StartTransaction();

                NewEntities.PersistAllNew();
                AmendedEntities.PersistAllAmended();
                RemovedEntities.PersistAllDeleted();

                session.CommitTransaction();
            }
        }

        public void Rollback()
        {
            NewEntities.Clear();
            AmendedEntities.Clear();
            RemovedEntities.Clear();
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