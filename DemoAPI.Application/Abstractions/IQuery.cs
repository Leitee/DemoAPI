using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Abstractions
{
	public interface IQuery<TResponse> : IRequest<Result<TResponse>>
	{
	}

	public interface IQueryPaged<TResponse> : IRequest<PagedResult<TResponse>>
	{
	}
}