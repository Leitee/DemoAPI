using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Author
{
	public record GetAuthorsListRequest(int Page, int PageSize) : IRequest<PagedListResult<AuthorDto>>;

	public class GetAuthorsListHandler : IRequestHandler<GetAuthorsListRequest, PagedListResult<AuthorDto>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorsListHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<PagedListResult<AuthorDto>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
		{
			var authorList = await _authorService.GetAuthorsAsync(request.Page, request.PageSize);
			var totalPages = (int)Math.Ceiling(authorList.Count / (double)request.PageSize);
			var pageInfo = new PagedInfo(request.Page, request.PageSize, totalPages, authorList.Count);

			return new PagedListResult<AuthorDto>(pageInfo, authorList.Select(x => x.ToAuthorDto()));
		}
	}
}
