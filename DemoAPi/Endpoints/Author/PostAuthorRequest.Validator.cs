using FastEndpoints;
using FluentValidation;

namespace DemoAPI.Endpoints.Author
{
	public class PostAuthorValidator : Validator<GetAuthorByIdRequest>
  {
    public PostAuthorValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
		}
  }
}
