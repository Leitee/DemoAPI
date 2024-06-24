namespace DemoAPI.Extensions
{
  using Ardalis.Result;
  using DemoAPI.Commons;

  public static class ApiResponseExtensions
  {
		public static ApiResponse<TDto> ToApiResponse<TDto>(this Result<TDto> result) where TDto : class
		{

			if (result.IsSuccess)
			{
				return new ApiResponse<TDto>
				{
					Data = result.Value
				};
			}

			var resp = new ApiResponse<TDto>();

			foreach (var error in result.Errors)
			{
				resp.AddError(new Error { Title = error });
			}

			return resp;
		}

		public static IBaseResponse ToApiResponse(this Result result)
		{

			if (result.IsSuccess)
			{
				return new ApiResponse<object>();
			}

			var resp = new ApiResponse<object>();

			foreach (var error in result.Errors)
			{
				resp.AddError(new Error { Title = error });
			}

			return resp;
		}

		public static PaginatedResponse<TCollection, TDto> ToPagedApiResponse<TCollection, TDto>(this PagedResult<TCollection> result)
			where TCollection : class, IEnumerable<TDto>
		{
			if (result.IsSuccess)
			{
				return new PaginatedResponse<TCollection, TDto>
				{
					Data = result.Value,
					TotalRecords = result.PagedInfo.TotalRecords,
					PageSize = result.PagedInfo.PageSize,
					PageNumber = result.PagedInfo.PageNumber,
					TotalPages = result.PagedInfo.TotalPages
				};
			}

			var resp = new PaginatedResponse<TCollection, TDto>();

			foreach (var error in result.Errors)
			{
				resp.AddError(new Error { Title = error });
			}

			return resp;
		}
	}
}
