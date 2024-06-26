namespace DemoAPI.Commons
{
	public class PaginatedResponse<TDto> : ApiResponse<IEnumerable<TDto>> where TDto : class
	{
		public long TotalRecords { get; set; }
		public long PageSize { get; set; }
		public long PageNumber { get; set; }
		public long TotalPages { get; set; }
	}
}
