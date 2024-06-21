namespace DemoAPI.Application.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public AuthorSlim Author { get; set; }

    }
}