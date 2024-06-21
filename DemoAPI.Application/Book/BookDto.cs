using DemoAPI.Application.Author;

namespace DemoAPI.Application.Book
{
	public record BookDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public int AuthorId { get; set; }
		public AuthorDto Author { get; set; }
	}
}
