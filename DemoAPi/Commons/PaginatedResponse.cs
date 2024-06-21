namespace DemoAPI.Commons
{
	public class PaginatedResponse<TModel> : ApiResponse<List<TModel>>
	{
		public int TotalCount { get; set; }
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
	}
}
