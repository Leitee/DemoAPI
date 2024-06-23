namespace DemoAPI.Commons
{
	using Newtonsoft.Json;

	/// <summary>
	/// Error
	/// </summary>
	public class Error
	{
		/// <summary>
		/// Gets or sets a unique identifier for this particular occurrence of the problem.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the HTTP status code applicable to this problem, expressed as a string value.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Status { get; set; }

		/// <summary>
		/// Gets or sets an application-specific error code, expressed as a string value.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Code { get; set; }

		/// <summary>
		/// Gets or sets a short, human-readable summary of the problem that SHOULD NOT change from occurrence to occurrence of the problem, except for purposes of localization.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets a human-readable explanation specific to this occurrence of the problem. Like title, this field’s value can be localized.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		/// <summary>
		/// Gets or sets additional data
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public dynamic AdditionalData { get; set; }
	}
}
