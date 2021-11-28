using Shopping.Domain.Entities;

namespace Shopping.Domain.Models
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => Quantity * Product.Price;

        public CartItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            Quantity = quantity;
        }

        public void IncreaseQuantity(int increaseBy)
            => Quantity += increaseBy;

        public void DecreaseQuantity(int decreaseBy)
        {
            if (Quantity - decreaseBy <= 0) throw new ArgumentOutOfRangeException(nameof(decreaseBy), "Cart item quantity cannot be decreased below 1");
            Quantity -= decreaseBy;
        }
    }
}
