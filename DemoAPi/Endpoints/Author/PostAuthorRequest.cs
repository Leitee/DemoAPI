namespace DemoAPI.Endpoints.Author
{
	using Ardalis.Result.AspNetCore;
	using DemoAPI.Application.Author;
	using DemoAPI.Commons;
	using FastEndpoints;
	using MediatR;

	public record PostAuthorRequest
	{
		public const string Route = "api/authors";

		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateOnly BirthDay { get; set; }
	}

	public class PostAuthorEndpoint : Endpoint<PostAuthorRequest, ApiResponse<AuthorDto>>
	{
		private readonly IMediator _mediator;

		public PostAuthorEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		public override void Configure()
		{
			Post(PostAuthorRequest.Route);
		}

		public async Task<IResult> Handle(PostAuthorRequest request, CancellationToken cancellationToken)
		{
			var command = new CreateAuthorCommand(request.Firstname, request.Lastname, request.BirthDay);

			var response = await _mediator.Send(command, cancellationToken);

			return response.ToMinimalApiResult();
		}
	}
}

