using FastEndpoints;
using FluentValidation;

namespace DemoAPI.Endpoints.Author
{
	public class GetAuthorByIdValidator : Validator<GetAuthorByIdRequest>
  {
      public GetAuthorByIdValidator()
      {
        RuleFor(x => x.Id)
          .NotEmpty();
		  }
    }
}
