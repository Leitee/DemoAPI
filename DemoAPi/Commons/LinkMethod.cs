// <copyright file="LinkMethod.cs" company="Betting Technologies Australia PTY LTD">
// Copyright by Betting Technologies Australia PTY LTD. All rights reserved.
// </copyright>

// ReSharper disable InconsistentNaming
namespace DemoAPI.Commons
{
	using System.ComponentModel;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;

	/// <summary>
	/// Link method
	/// </summary>
	[DefaultValue(null)]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum LinkMethod
	{
		/// <summary>
		/// Get
		/// </summary>
		GET,

		/// <summary>
		/// Post
		/// </summary>
		POST,

		/// <summary>
		/// Put
		/// </summary>
		PUT,

		/// <summary>
		/// Delete
		/// </summary>
		DELETE,

		/// <summary>
		/// Patch
		/// </summary>
		PATCH
	}
}
