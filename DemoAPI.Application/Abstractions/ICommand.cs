﻿using Ardalis.Result;
using MediatR;

namespace DemoAPI.Application.Abstractions
{
	public interface ICommand: IRequest<Result>
	{
	}

	public interface ICommand<TResponse> : IRequest<Result<TResponse>>
	{
	}
}
