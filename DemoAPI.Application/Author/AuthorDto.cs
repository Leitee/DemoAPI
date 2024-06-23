namespace DemoAPI.Application.Author
{
	using DemoAPI.Application.Book;
	using DemoAPI.Domain.Entities;

	public record AuthorDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public IEnumerable<BookDto>? Books { get; set; }

		public AuthorEntity ToEntity()
		{
			return new AuthorEntity
			{
				Id = Id,
				Name = Name,
				Books = Books?.Select(b => b.TooSlim())
			};
		}

		public AuthorSlim ToSlim()
		{
			return new AuthorSlim
			{
				ReferenceId = Id,
				Name = Name
			};
		}
	}

	public static partial class MapperExtensions
	{
		public static AuthorDto ToAuthorDto(this AuthorEntity author)
		{
			return new AuthorDto
			{
				Id = author.Id,
				Name = author.Name,
				Books = author.Books?.Select(b => b.ToBookDto()).ToList()
			};
		}

		public static AuthorDto ToAuthorDto(this AuthorSlim author)
		{
			return new AuthorDto
			{
				Id = author.ReferenceId,
				Name = author.Name
			};
		}
	}
}
