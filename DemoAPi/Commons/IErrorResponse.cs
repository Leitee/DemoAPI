namespace DemoAPI.Commons
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	/// <summary>
	/// Error response contract
	/// </summary>
	public interface IErrorResponse
	{
		/// <summary>
		/// Gets list of error objects
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		IReadOnlyList<Error> Errors { get; }
	}
}
