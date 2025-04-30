using Microsoft.EntityFrameworkCore;

namespace EMS.API.DTOs
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public List<T> Items { get; private set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }

    }

}