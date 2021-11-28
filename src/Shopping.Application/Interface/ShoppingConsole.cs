using Shopping.Domain.Contracts;
using Shopping.Domain.Entities;
using Shopping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Interface
{
    public class ShoppingConsole
    {
        private IProductService _productService;
        private IPromotionService _promotionService;
        private Cart _cart;
        private Checkout _checkout;

        public ShoppingConsole(IProductService productService, IPromotionService promotionService, Cart cart, Checkout checkout)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
            _checkout = checkout ?? throw new ArgumentNullException(nameof(checkout));
        }

        public void ActionMenu()
        {
            Console.WriteLine("Choose an action from the following list:");
            Console.WriteLine("\ta - Add Product To Cart");
            Console.WriteLine("\tr - Remove Product From Cart");
            Console.WriteLine("\tc - Checkout");
            Console.Write("Action: ");

            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    AddProductToCart();
                    break;
                case "r":
                    RemoveProductFromCart();
                    break;
                case "c":
                    Checkout();
                    break;
                default:
                    Console.WriteLine("Command not recognised.");
                    break;
            }

            ActionMenu();
        }

        private void AddProductToCart()
        {
            WriteAvailableProducts();

            var cartItem = ReadCartItem();
            if (cartItem == null) return;

            try
            {
                _cart.AddItem(cartItem);
                Console.WriteLine($"Added {cartItem.Quantity} of product {cartItem.Product.Sku} to cart.");
            }
            catch
            {
                Console.WriteLine("Unable to add product to cart.");
            }

            ActionMenu();
        }

        private void RemoveProductFromCart()
        {
            WriteCartItems();

            var cartItem = ReadCartItem();
            if (cartItem == null) return;

            try
            {
                _cart.RemoveItem(cartItem);
                Console.WriteLine($"Removed {cartItem.Quantity} of product {cartItem.Product.Sku} from cart.");
            }
            catch
            {
                Console.WriteLine("Unable to remove product from cart.");
            }

            ActionMenu();
        }

        private void Checkout()
        {
            WriteCartItems();

            Console.WriteLine($"Sub Total: {_cart.Total:C2}");
            Console.WriteLine($"Discount: {_checkout.Discount(_cart):C2}");
            Console.WriteLine($"Total To Pay: {_checkout.TotalAfterDiscount(_cart):C2}");
            Console.Write("Continue Shopping? (y/n): ");
            if (Console.ReadLine().ToLower() == "n") Environment.Exit(0);
        }

        private CartItem? ReadCartItem()
        {
            var product = ReadProduct();
            if (product == null) return null;

            try
            {
                Console.Write("Enter Quantity: ");
                var quantity = Convert.ToInt32(Console.ReadLine());
                return new CartItem(product, quantity);
            }
            catch
            {
                Console.WriteLine("Invalid quantity.");
            }

            return null;
        }

        private Product? ReadProduct()
        {
            Console.Write("Enter Product Sku: ");
            var sku = Console.ReadLine();
            try
            {
                var product = _productService.GetProduct(sku);
                return product;
            }
            catch
            {
                Console.WriteLine("Unable to find product.");
            }

            return null;
        }

        private void WriteAvailableProducts()
        {
            Console.WriteLine("Available Products:");
            foreach (var product in _productService.GetProducts())
                Console.WriteLine($"Sku: {product.Sku}; Price: {product.Price:C2}");
        }

        private void WriteCartItems()
        {
            Console.WriteLine("Items In Cart:");
            foreach (var cartItem in _cart.Items)
                Console.WriteLine($"Sku: {cartItem.Product.Sku}; Price: {cartItem.Product.Price:C2}; Quantity: {cartItem.Quantity}; Total: {cartItem.TotalPrice:C2}");
        }
    }
}
