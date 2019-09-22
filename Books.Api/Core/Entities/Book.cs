using Books.Api.Core.Entities.Builder;

namespace Books.Api.Core.Entities
{
    // TODO: use builder in mapper, remove public ctor and setters
    public class Book : IAggregateRoot
    {
        public Book()
        {
        }

        private Book(string id, string bookName)
        {
            Id = id;
            BookName = bookName;
        }

        public string Id { get; set; }

        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public class Builder : IWithId, IWithBookName, IBuildable
        {
            private string _bookName;
            private string _id;

            public Book Build()
            {
                return new Book(_id, _bookName);
            }

            public IBuildable WithBookName(string bookName)
            {
                _bookName = bookName;
                return this;
            }

            public static IWithId CreateNew()
            {
                return new Builder();
            }

            public IWithBookName WithId(string id)
            {
                _id = id;
                return this;
            }
        }
    }
}