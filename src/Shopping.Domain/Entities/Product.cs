namespace Shopping.Domain.Entities
{
    public record Product
    {
        public string Sku { get; init; } = default!;
        public decimal Price { get; init; } = default!;
    }
}
