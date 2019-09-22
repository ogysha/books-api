using Books.Api.Core.Entities.Builder;

namespace Books.Api.Core.Entities
{
    public interface IWithId
    {
        IWithBookName WithId(string id);
    }
}