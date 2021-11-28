using FluentAssertions;
using NUnit.Framework;
using Shopping.Domain.Entities;
using Shopping.Domain.Models;

namespace Shopping.Tests
{
    [TestFixture]
    public class CartItemTests
    {
        [Test]
        public void IncreaseQuantity_IncreasesQuantity()
        {
            var cartItem = new CartItem(
                new Product
                {
                    Sku = "TEST",
                    Price = 50.0M
                },
                1);

            cartItem.IncreaseQuantity(2);

            cartItem.Quantity.Should().Be(3);
        }

        [Test]
        public void DecreaseQuantity_DecreasesQuantity()
        {
            var cartItem = new CartItem(
                new Product
                {
                    Sku = "TEST",
                    Price = 50.0M
                },
                3);

            cartItem.DecreaseQuantity(2);

            cartItem.Quantity.Should().Be(1);
        }

        [Test]
        public void DecreaseQuantity_ThrowsIfQuantityZero()
        {
            var cartItem = new CartItem(
                new Product
                {
                    Sku = "TEST",
                    Price = 50.0M
                },
                3);

            Action act = () => cartItem.DecreaseQuantity(3);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
