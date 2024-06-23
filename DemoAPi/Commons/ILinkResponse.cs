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
