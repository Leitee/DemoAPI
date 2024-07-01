using Ardalis.Result;
using DemoAPI.Application.Abstractions;
using MediatR;

namespace DemoAPI.Application.Author
{
	public record GetAuthorByIdQuery(Guid Id) : IQuery<AuthorDto>;


	public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Result<AuthorDto>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorByIdHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<Result<AuthorDto>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var author = await _authorService.GetAuthorByIdAsync(request.Id);

			if (author == null)
			{
				return Result.NotFound("The author with the specified ID does not exist.");
			}

			return Result.Success(author.ToAuthorDto());
		}
	}
}
