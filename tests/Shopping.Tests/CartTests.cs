using FluentAssertions;
using NUnit.Framework;
using Shopping.Domain.Entities;
using Shopping.Domain.Models;
using System;

namespace Shopping.Tests
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void AddItem_AddsItem()
        {
            var cart = new Cart();
            var cartItem = new CartItem(
                new Product
                {
                    Sku = "TEST",
                    Price = 50.0M
                },
                1);

            cart.AddItem(cartItem);

            cart.Items.Should().Contain(cartItem);
        }

        [Test]
        public void AddItem_IncrementsExistingItem()
        {
            var cart = new Cart();
            var product = new Product
            {
                Sku = "TEST",
                Price = 50.0M
            };

            var cartItem = new CartItem(product, 1);

            cart.AddItem(cartItem);

            cart.AddItem(cartItem);

            var expectedItem = new CartItem(product, 2);

            cart.Items.Should().ContainEquivalentOf(expectedItem);
        }

        [Test]
        public void RemoveItem_RemovesItem()
        {
            var cart = new Cart();
            var product = new Product
            {
                Sku = "TEST",
                Price = 50.0M
            };

            var cartItem = new CartItem(product, 5);

            cart.AddItem(cartItem);

            cart.RemoveItem(cartItem);

            cart.Items.Should().BeEmpty();
        }

        [Test]
        public void RemoveItem_DecrementsItem()
        {
            var cart = new Cart();
            var product = new Product
            {
                Sku = "TEST",
                Price = 50.0M
            };

            var cartItem = new CartItem(product, 5);

            cart.AddItem(cartItem);

            var removeItem = new CartItem(product, 2);

            cart.RemoveItem(removeItem);

            var expectedItem = new CartItem(product, 3);

            cart.Items.Should().ContainEquivalentOf(expectedItem);
        }
    }
}
