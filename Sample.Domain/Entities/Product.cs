namespace Sample.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Quantity { get; set; }
        public bool Active { get; set; }
    }
}
