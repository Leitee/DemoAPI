namespace DemoAPI.Application.Author
{
	using DemoAPI.Domain.Entities;

	public interface IAuthorService
	{
		Task<AuthorEntity> CreateAuthorAsync(AuthorEntity author);
		Task<AuthorEntity> GetAuthorByIdAsync(Guid id);
		Task<List<AuthorEntity>> GetAuthorsAsync(int page, int pageSize);
	}
}
