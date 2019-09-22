
using Books.Api.Core.Entities.Builder;

namespace Books.Api.Core.Entities
{
    // TODO: use builder in mapper, remove public ctor and setters
    public class Book : IAggregateRoot
    {
        public Book()
        {
        }

        private Book(int id, string bookName)
        {
            Id = id;
            BookName = bookName;
        }

        public int Id { get; set; }

        public string BookName { get; set; }
        
        public int BookId { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public class Builder : IWithBookName, IBuildable
        {
            private int _id;
            private string _bookName;

            public static IWithBookName CreateNew()
            {
                return new Builder();
            }

            public IBuildable WithBookName(string bookName)
            {
                _bookName = bookName;
                return this;
            }

            public Book Build()
            {
                return new Book(_id, _bookName);
            }
        }
    }
}