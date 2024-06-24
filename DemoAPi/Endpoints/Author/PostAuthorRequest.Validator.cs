using FluentValidation;

namespace DemoAPI.Endpoints.Author
{
	public class PostAuthorValidator : AbstractValidator<GetAuthorByIdRequest>
  {
    public PostAuthorValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
		}
  }
}
