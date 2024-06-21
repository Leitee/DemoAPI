// <copyright file="IBaseResponse.cs" company="Betting Technologies Australia PTY LTD">
// Copyright by Betting Technologies Australia PTY LTD. All rights reserved.
// </copyright>

namespace DemoAPI.Commons
{
	/// <summary>
	/// Encapsulation of paramters for a BettingEdge Response
	/// This is the base definition from which all BettingEdge Response definitions are inherited
	/// </summary>
	public interface IBaseResponse : ILinkResponse, IErrorResponse
	{
		/// <summary>
		/// Adds an error object to Errors list
		/// </summary>
		/// <param name="error">error object</param>
		void AddError(Error error);

		/// <summary>
		/// Determines if there are any errors in the response
		/// </summary>
		/// <returns>true or false indicating if there are any errors</returns>
		bool HasError();
	}
}
