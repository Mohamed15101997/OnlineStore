using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Helper
{
	public class PaginationResponse<TEntity>
	{
		public PaginationResponse(int pageNumber, int pageSize, int totalCount, IEnumerable<TEntity> data)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalCount = totalCount;
			Data = data;
		}

		public int PageNumber { get; set; }
		public int PageSize{ get; set; }
		public int TotalCount { get; set; }
		public IEnumerable<TEntity> Data { get; set; }
	}
}
