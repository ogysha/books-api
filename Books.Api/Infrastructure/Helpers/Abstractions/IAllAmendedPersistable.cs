namespace Books.Api.Infrastructure.Helpers.Abstractions
{
    public interface IAllAmendedPersistable : IClearable, IAddable
    {
        void PersistAllAmended();
    }
}