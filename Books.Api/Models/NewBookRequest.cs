namespace Books.Api.Models
{
    public class NewBookRequest
    {
        public int BookId { get; set; }
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}