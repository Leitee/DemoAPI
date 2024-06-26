using Ardalis.Result;
using System.Text.Json.Serialization;

namespace DemoAPI.Application
{
	public class PagedListResult<TDto> : Result<IEnumerable<TDto>>
    {
		[JsonInclude]
		public PagedInfo PagedInfo { get; init; }

		public PagedListResult(PagedInfo pagedInfo, IEnumerable<TDto> value)
			: base(value)
		{
			PagedInfo = pagedInfo;
		}
	}
}
