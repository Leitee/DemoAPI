using DemoAPI.Application.Author;

namespace DemoAPI.Application.Book
{
	using DemoAPI.Domain.Entities;

	public record BookDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public AuthorDto? Author { get; set; }

		public BookEntity ToEntity()
		{
			return new BookEntity
			{
				Id = Id,
				Title = Title,
				Author = Author?.ToSlim()
			};
		}

		public BookSlim TooSlim()
		{
			return new BookSlim
			{
				ReferenceId = Id,
				Title = Title
			};
		}
	}

	public static partial class MapperExtensions
	{
		public static BookDto ToBookDto(this BookEntity book)
		{
			return new BookDto
			{
				Id = book.Id,
				Title = book.Title,
				Author = book.Author?.ToAuthorDto()
			};
		}

		public static BookDto ToBookDto(this BookSlim book)
		{
			return new BookDto
			{
				Id = book.ReferenceId,
				Title = book.Title
			};
		}
	}
}
