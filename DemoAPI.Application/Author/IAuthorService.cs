namespace DemoAPI.Application.Author
{
	public interface IAuthorService
	{
		Task<AuthorDto> GetAuthorByIdAsync(int id);
		Task GetAuthorsAsync(int page, int pageSize);
	}
}
