namespace Application.Common;

public sealed class PageList<T> where T: class
{
    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public bool HasNextPage => CurrentPage < TotalPages;

    public bool HasPreviousPage => CurrentPage > 1;

    public List<T> Items { get; set; }

    public PageList(List<T> items, int totalCount, int currentPage, int pageSize)
    {
        TotalCount = totalCount;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        Items = items;
    }

    public static PageList<T> Create(List<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PageList<T>(items, count, pageNumber, pageSize);
    }
}