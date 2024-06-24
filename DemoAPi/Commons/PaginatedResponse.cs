namespace DemoAPI.Commons
{
	public class PaginatedResponse<TCollection, TDto> : ApiResponse<TCollection> where TCollection : class, IEnumerable<TDto>
	{
		public long TotalRecords { get; set; }
		public long PageSize { get; set; }
		public long PageNumber { get; set; }
		public long TotalPages { get; set; }
	}
}
