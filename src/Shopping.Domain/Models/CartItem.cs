using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            Quantity = quantity;
        }

        public void IncreaseQuantity(int increaseBy)
        {

        }

        public void DecreaseQuantity(int decreaseBy)
        {

        }
    }
}
