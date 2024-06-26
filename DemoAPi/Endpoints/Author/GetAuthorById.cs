﻿using Ardalis.Result.AspNetCore;
using DemoAPI.Application.Author;
using FastEndpoints;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Endpoints.Author
{
	public record GetAuthorByIdRequest
	{
		public const string Route = "api/authors/{id}";

		[Required]
		public required Guid Id { get; init; }
	}

	public class GetAuthorById : Endpoint<GetAuthorByIdRequest, IResult>
	{
		private readonly IMediator _mediator;

		public GetAuthorById(IMediator mediator)
		{
				_mediator = mediator;
		}

		public override void Configure()
		{
				Verbs(Http.GET);
				Routes(GetAuthorByIdRequest.Route);
				AllowAnonymous();
		}

		public override async Task<IResult> ExecuteAsync(GetAuthorByIdRequest req, CancellationToken ct)
		{
			var query = new GetAuthorByIdQuery(req.Id);
			var response = await _mediator.Send(query, ct);
			return response.ToMinimalApiResult();
		}
	}
}
