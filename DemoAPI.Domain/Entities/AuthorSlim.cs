namespace DemoAPI.Domain.Entities
{
	public class AuthorSlim
	{
		public Guid ReferenceId { get; set; }
		public required string Name { get; set; }
	}
}