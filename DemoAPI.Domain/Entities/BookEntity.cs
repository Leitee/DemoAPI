namespace DemoAPI.Domain.Entities
{
	public class BookEntity
	{
		public Guid Id { get; set; }
		public required string Title { get; set; }
		public AuthorSlim? Author { get; set; }
	}
}