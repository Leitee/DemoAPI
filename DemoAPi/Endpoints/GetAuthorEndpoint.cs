using DemoAPI.Application.Author;
using DemoAPI.Commons;
using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;

namespace DemoAPI.Endpoints
{
	public class GetAuthorEndpoint : Endpoint<GetAuthorRequest, Microsoft.AspNetCore.Http.IResult>
	{
		private readonly IMediator _mediator;

		public GetAuthorEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		public override void Configure()
		{
			Verbs(Http.GET);
			Routes("/api/authors/{id:int}");
			AllowAnonymous();
		}

		public override async Task<Microsoft.AspNetCore.Http.IResult> ExecuteAsync(GetAuthorRequest req, CancellationToken ct)
		{
			var response = await _mediator.Send(req, ct);
			return response.ToMinimalApiResult();
		}
	}

	public class GetAuthorsEndpoint : Endpoint<GetAuthorsRequest, Microsoft.AspNetCore.Http.IResult>
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

		public override async Task<Microsoft.AspNetCore.Http.IResult> ExecuteAsync(GetAuthorsRequest req, CancellationToken ct)
		{
			var response = await _mediator.Send(req, ct);
			return response.ToMinimalApiResult();
		}
	}

}
