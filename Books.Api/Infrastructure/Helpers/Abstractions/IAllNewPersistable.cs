namespace Books.Api.Infrastructure.Helpers.Abstractions
{
    public interface IAllNewPersistable : IClearable, IAddable
    {
        void PersistAllNew();
    }
}