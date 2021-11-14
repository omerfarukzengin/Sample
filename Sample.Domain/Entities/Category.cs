namespace Sample.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public decimal MinimumStockQuantity { get; set; }
    }
}
