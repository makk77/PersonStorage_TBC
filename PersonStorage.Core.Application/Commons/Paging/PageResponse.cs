namespace PersonStorage.Core.Application.Commons.Paging;

public class PageResponse<T>
{
    public List<T> Data { get; set; } = new List<T>();

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
