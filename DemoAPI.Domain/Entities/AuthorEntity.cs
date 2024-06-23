namespace DemoAPI.Domain.Entities
{
	public class AuthorEntity
	{
		public Guid Id { get; set; }

		public required string Name { get; set; }

		public DateOnly? BirthDay { get; set; }

		public IEnumerable<BookSlim>? Books { get; set; }
	}
}