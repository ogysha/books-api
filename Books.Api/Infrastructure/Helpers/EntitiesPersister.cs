using System.Collections.Generic;
using Books.Api.Infrastructure.Helpers.Abstractions;

namespace Books.Api.Infrastructure.Helpers
{
    public class EntitiesPersister : IAllAmendedPersistable, IAllNewPersistable, IAllRemovedPersistable
    {
        private readonly IList<EntityRepositoryPair> _entities = new List<EntityRepositoryPair>();

        public void PersistAllNew()
        {
            foreach (var entityRepositoryPair in _entities)
            {
                entityRepositoryPair.PersistNew();
            }
        }

        public void PersistAllAmended()
        {
            foreach (var entityRepositoryPair in _entities)
            {
                entityRepositoryPair.PersistAmended();
            }
        }
        
        public void PersistAllDeleted()
        {
            foreach (var entityRepositoryPair in _entities)
            {
                entityRepositoryPair.PersistDeleted();
            }
        }

        public void Clear()
        {
            _entities.Clear();
        }

        public void Add(EntityRepositoryPair entityRepositoryPair)
        {
            if (_entities.Contains(entityRepositoryPair)) return;

            _entities.Add(entityRepositoryPair);
        }
    }
}