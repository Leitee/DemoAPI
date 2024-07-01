using Ardalis.Result;
using FluentValidation;
using MediatR;

namespace DemoAPI.Application.Behaviors
{
	public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
  {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
      if (!_validators.Any())
        return await next();

      var errors = _validators
        .Select(v => v.Validate(request))
        .SelectMany(valRes => valRes.Errors)
        .Where(failure => failure != null)
        .Select(failure => new ValidationError(
          failure.PropertyName,
          failure.ErrorMessage,
          failure.ErrorCode,
          ValidationSeverity.Error))// see enum convert
        .Distinct()
        .ToArray();

        if (errors.Any())
        {
          // TODO: implement error handling
        }

        return await next();
		}
  }
}
