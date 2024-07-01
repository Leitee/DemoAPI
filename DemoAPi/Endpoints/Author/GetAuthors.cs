using Ardalis.Result.AspNetCore;
using DemoAPI.Application.Author;
using FastEndpoints;
using MediatR;

namespace DemoAPI.Endpoints.Author
{
	public class GetAuthorsEndpoint : EndpointWithoutRequest<IResult>
	{
		private readonly IMediator _mediator;

		public GetAuthorsEndpoint(IMediator mediator)
		{
				_mediator = mediator;
		}

		public override void Configure()
		{
				Verbs(Http.GET);
				Routes("/api/authors");
				AllowAnonymous();
		}

		public override async Task<IResult> ExecuteAsync(CancellationToken ct)
		{
				var response = await _mediator.Send(new GetAuthorsListRequest(Page: 1, PageSize: 10), ct);
				return response.ToMinimalApiResult();
		}
	}
}
