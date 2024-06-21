using DemoAPI.Application.Book;

namespace DemoAPI.Application.Author
{
	public record AuthorDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<BookDto> Books { get; set; }
	}
}
