namespace DemoAPI.Endpoints.Author
{
	using Ardalis.Result.AspNetCore;
	using DemoAPI.Application.Author;
	using FastEndpoints;
	using MediatR;

	public record PostAuthor
  {
    public const string Route = "api/authors";

    public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateOnly BirthDay { get; set; }
	}

	public class PostAuthorEndpoint : Endpoint<PostAuthor, IResult>
	{
		private readonly IMediator _mediator;

		public PostAuthorEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		public override void Configure()
		{
			Post(PostAuthor.Route);
		}

		public async Task<IResult> Handle(PostAuthor request, CancellationToken cancellationToken)
		{
			var command = new CreateAuthorCommand(request.Firstname, request.Lastname, request.BirthDay);

			var response =	await _mediator.Send(command, cancellationToken);

			return response.ToMinimalApiResult();
		}
	}
}
