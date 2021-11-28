namespace Shopping.Domain.Entities
{
    public record PromotionCriteria
    {
        public Product Product { get; init; } = default!;
        public int Quantity { get; set; }
    }
}
