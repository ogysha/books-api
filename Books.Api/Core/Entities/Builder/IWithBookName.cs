namespace Books.Api.Core.Entities.Builder
{
    public interface IWithBookName
    {
        IBuildable WithBookName(string bookName);
    }
}