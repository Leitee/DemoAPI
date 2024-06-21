using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Author
{
	public class GetAuthorRequest : IRequest<Result<AuthorDto>>
	{
		public int Id { get; set; }
	}

	public class GetAuthorsRequest : IRequest<PagedResult<AuthorDto>>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}

	public class GetAuthorHandler : IRequestHandler<GetAuthorRequest, Result<AuthorDto>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<Result<AuthorDto>> Handle(GetAuthorRequest request, CancellationToken cancellationToken)
		{
			var author = await _authorService.GetAuthorByIdAsync(request.Id);

			if (author == null)
			{
				return Result.NotFound("The author with the specified ID does not exist.");
			}

			return Result.Success<AuthorDto>(author);
		}
	}

	public class GetAuthorsHandler : IRequestHandler<GetAuthorsRequest, PagedResult<AuthorDto>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorsHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<PagedResult<AuthorDto>> Handle(GetAuthorsRequest request, CancellationToken cancellationToken)
		{
			var paginatedResult = await _authorService.GetAuthorsAsync(request.Page, request.PageSize);
			var totalPages = (int)Math.Ceiling(paginatedResult.TotalCount / (double)request.PageSize);
			var pageInfo = new PagedInfo(request.Page, request.PageSize, totalPages, paginatedResult.TotalCount);

			return new PagedResult<AuthorDto>(pageInfo, paginatedResult.Items);
		}
	}
}
