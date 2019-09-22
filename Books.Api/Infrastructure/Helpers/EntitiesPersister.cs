using System.Collections.Generic;

namespace Books.Api.Infrastructure.Helpers
{
    public class EntitiesPersister
    {
        private readonly IList<EntityRepositoryPair> _entities = new List<EntityRepositoryPair>();
        public void PersistAllNew()
        {
            foreach (var entityRepositoryPair in _entities)
            {
                entityRepositoryPair.PersistNew();
            }
        }

        internal void Clear()
        {
            _entities.Clear();
        }

        internal void Add(EntityRepositoryPair entityRepositoryPair)
        {
            if (_entities.Contains(entityRepositoryPair)) return;

            _entities.Add(entityRepositoryPair);
        }
    }
}