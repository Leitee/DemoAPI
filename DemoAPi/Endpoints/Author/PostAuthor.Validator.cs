using FluentValidation;

namespace DemoAPI.Endpoints.Author
{
	public class PostAuthorValidator : AbstractValidator<GetAuthorByIdRequest>
  {
    public PostAuthorValidator()
    {
      RuleFor(x => x.Firstname).NotEmpty().MaximumLength(50);
		}
  }
}
