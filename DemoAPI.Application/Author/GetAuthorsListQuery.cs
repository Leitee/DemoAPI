using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Author
{
	public record GetAuthorsListRequest(int Page, int PageSize) : IRequest<PagedResult<IEnumerable<AuthorDto>>>;

	public class GetAuthorsListHandler : IRequestHandler<GetAuthorsListRequest, PagedResult<IEnumerable<AuthorDto>>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorsListHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<PagedResult<IEnumerable<AuthorDto>>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
		{
			var authorList = await _authorService.GetAuthorsAsync(request.Page, request.PageSize);
			var totalPages = (int)Math.Ceiling(authorList.Count / (double)request.PageSize);
			var pageInfo = new PagedInfo(request.Page, request.PageSize, totalPages, authorList.Count);

			return new PagedResult<IEnumerable<AuthorDto>>(pageInfo, authorList.Select(x => x.ToAuthorDto()));
		}
	}
}
