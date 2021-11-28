namespace Shopping.Domain.Models
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();
        public IEnumerable<CartItem> Items => _items.AsReadOnly();
        public decimal Total => _items.Sum(i => i.Quantity * i.Product.Price);

        public void AddItem(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var existingItem = _items.FirstOrDefault(i => i.Product == item.Product);
            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(item.Quantity);
                return;
            }

            _items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var existingItem = _items.Single(i => i.Product == item.Product);
            if (existingItem.Quantity > item.Quantity)
            {
                existingItem.DecreaseQuantity(item.Quantity);
                return;
            }

            _items.Remove(existingItem);
        }
    }
}
