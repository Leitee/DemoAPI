using FluentValidation;

namespace DemoAPI.Endpoints.Author
{
	public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdRequest>
  {
      public GetAuthorByIdValidator()
      {
        RuleFor(x => x.Id)
          .NotEmpty();
		  }
    }
}
