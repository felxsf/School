namespace School.Application.Common;

public record PageQuery(int Page = 1, int PageSize = 10, string? SortBy = null, string SortDir = "asc");

public record PagedResult<T>(IEnumerable<T> Items, int Total, int Page, int PageSize)
{
    public int TotalPages => (int)Math.Ceiling(Total / (double)PageSize);
}
