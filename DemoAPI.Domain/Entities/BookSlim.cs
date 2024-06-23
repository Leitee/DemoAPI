namespace DemoAPI.Domain.Entities
{
	public class BookSlim
	{
		public Guid ReferenceId { get; set; }
		public required string Title { get; set; }
	}
}
