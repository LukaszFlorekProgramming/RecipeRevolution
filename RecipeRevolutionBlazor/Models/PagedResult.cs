using System.Text.Json.Serialization;


namespace RecipeRevolutionBlazor.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        [JsonConstructor]
        public PagedResult(List<T> items, int totalPages, int itemsFrom, int itemsTo, int totalItemsCount)
        {
            Items = items;
            TotalPages = totalPages;
            ItemsFrom = itemsFrom;
            ItemsTo = itemsTo;
            TotalItemsCount = totalItemsCount;
        }
    }
}
