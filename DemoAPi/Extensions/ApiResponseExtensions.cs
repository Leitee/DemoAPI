namespace DemoAPI.Extensions
{
	using Ardalis.Result;
	using DemoAPI.Application;
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

			return (ApiResponse<TDto>)ProcessErrorResponse(result);
		}

		public static IBaseResponse ToApiResponse(this Result result)
		{

			if (result.IsSuccess)
			{
				return new ApiResponse<object>();
			}

			return ProcessErrorResponse(result);
		}

		public static PaginatedResponse<TDto> ToApiResponse<TDto>(this PagedListResult<TDto> result)
			where TDto : class
		{
			if (result.IsSuccess)
			{
				return new PaginatedResponse<TDto>
				{
					Data = result.Value,
					TotalRecords = result.PagedInfo.TotalRecords,
					PageSize = result.PagedInfo.PageSize,
					PageNumber = result.PagedInfo.PageNumber,
					TotalPages = result.PagedInfo.TotalPages
				};
			}

			return (PaginatedResponse<TDto>)ProcessErrorResponse(result);
		}

		private static IBaseResponse ProcessErrorResponse(IResult result)
		{
			var resp = new ApiResponse<object>();
			string errorMsg = string.Empty;

			// procesar y armar las distintas respustas de acuerdo al tipo de error
			// resp.AddError(new Error { Title = "Bad Request", Status = result.Status.ToString(), Detail =  errorMsg});

			return resp;
		}
	}
}
