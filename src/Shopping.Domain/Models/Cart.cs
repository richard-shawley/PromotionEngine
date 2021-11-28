using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();
        public IEnumerable<CartItem> Items => _items.AsReadOnly();
        public decimal Total { get; private set; }

        public void AddItem(CartItem item)
        {

        }

        public void RemoveItem(CartItem item)
        {

        }
    }
}
