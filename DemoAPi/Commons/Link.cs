namespace DemoAPI.Commons
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;

	/// <summary>
	/// Link
	/// </summary>
	public class Link
	{
		/// <summary>
		/// Gets or sets link rel
		/// </summary>
		[JsonProperty(PropertyName = JsonPropertyNames.Relation, NullValueHandling = NullValueHandling.Ignore)]
		public string Relation { get; set; }

		/// <summary>
		/// Gets or sets link href
		/// </summary>
		[JsonProperty(PropertyName = JsonPropertyNames.Href, NullValueHandling = NullValueHandling.Ignore)]
		public string Href { get; set; }

		/// <summary>
		/// Gets or sets link method
		/// </summary>
		[JsonProperty(PropertyName = JsonPropertyNames.Method, NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(StringEnumConverter))]
		public LinkMethod Method { get; set; }
	}
}
