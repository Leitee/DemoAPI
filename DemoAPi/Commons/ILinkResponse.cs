// <copyright file="ILinkResponse.cs" company="Betting Technologies Australia PTY LTD">
// Copyright by Betting Technologies Australia PTY LTD. All rights reserved.
// </copyright>

namespace DemoAPI.Commons
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	/// <summary>
	/// Link response contract
	/// </summary>
	public interface ILinkResponse
	{
		/// <summary>
		/// Gets or sets links
		/// </summary>
		[JsonProperty(PropertyName = JsonPropertyNames.Links, NullValueHandling = NullValueHandling.Ignore)]
		List<Link> Links { get; set; }
	}
}
