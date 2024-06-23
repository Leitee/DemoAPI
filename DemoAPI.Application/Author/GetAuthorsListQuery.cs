using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Author
{
	public record GetAuthorsListRequest(int Page, int PageSize) : IRequest<PagedResult<List<AuthorDto>>>;

	public class GetAuthorsListHandler : IRequestHandler<GetAuthorsListRequest, PagedResult<List<AuthorDto>>>
	{
		private readonly IAuthorService _authorService;

		public GetAuthorsListHandler(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public async Task<PagedResult<List<AuthorDto>>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
		{
			var authorList = await _authorService.GetAuthorsAsync(request.Page, request.PageSize);
			var totalPages = (int)Math.Ceiling(authorList.Count / (double)request.PageSize);
			var pageInfo = new PagedInfo(request.Page, request.PageSize, totalPages, authorList.Count);

			return new PagedResult<List<AuthorDto>>(pageInfo, authorList.Select(x => x.ToAuthorDto()).ToList());
		}
	}
}
