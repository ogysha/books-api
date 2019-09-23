namespace Books.Api.Infrastructure.Helpers.Abstractions
{
    public interface IAllRemovedPersistable : IClearable, IAddable
    {
        void PersistAllDeleted();
    }
}