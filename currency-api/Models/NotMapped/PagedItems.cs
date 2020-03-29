using System.Collections.Generic;

namespace currencyApi.Models
{
    public class PagedItems<T>
    {
        public IEnumerable<T> Items  { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}