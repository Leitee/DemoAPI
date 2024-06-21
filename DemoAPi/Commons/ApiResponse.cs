// <copyright file="ApiResponse.cs" company="Betting Technologies Australia PTY LTD">
// Copyright by Betting Technologies Australia PTY LTD. All rights reserved.
// </copyright>

namespace DemoAPI.Commons
{
	using System.Linq;
	using System.Collections.Generic;
	using Newtonsoft.Json;

	/// <summary>
	/// Encapsulation of paramters for a BettingEdge Authentication Response
	/// This is the base definition from which all BettingEdge Response definitions are inherited
	/// </summary>
	public class ApiResponse<TModel> : IBaseResponse
	{
		[JsonProperty(PropertyName = JsonPropertyNames.Data, NullValueHandling = NullValueHandling.Ignore)]
		public TModel Data { get; set; }

		/// <inheritdoc/>
		[JsonProperty(PropertyName = JsonPropertyNames.Links, NullValueHandling = NullValueHandling.Ignore)]
		public List<Link> Links { get; set; }

		/// <inheritdoc/>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IReadOnlyList<Error> Errors { get; private set; }

		/// <inheritdoc/>
		public void AddError(Error error)
		{
			ArgumentNullException.ThrowIfNull(error, nameof(error));

			if (Errors == null)
			{
				Errors = new List<Error> { error };
				return;
			}

			var currentErrors = Errors.ToList();
			currentErrors.Add(error);
			Errors = currentErrors;
		}

		/// <inheritdoc/>
		public bool HasError()
		{
			return Errors != null && Errors.Any();
		}
	}
}
