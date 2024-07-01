using Ardalis.Result;
using DemoAPI.Application.Abstractions;
using MediatR;

namespace DemoAPI.Application.Author
{
	public record CreateAuthorCommand(string FirstName, string LastName, DateOnly BirthDay) : ICommand<AuthorDto>;

	public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Result<AuthorDto>>
	{
		private readonly IAuthorService _authorService;

		public CreateAuthorHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<Result<AuthorDto>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
		{
			var author = new AuthorDto
			{
				Name = $"{request.FirstName} {request.LastName}"
			};

			var createdAuthor = await _authorService.CreateAuthorAsync(author.ToEntity());

			return Result.Success(createdAuthor.ToAuthorDto());
		}
	}
}
