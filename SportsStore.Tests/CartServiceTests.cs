using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using SportsStore.Tests.MockRepositories;
using BuisnessLayer.Services;
using BuisnessLayer.Models;
using BuisnessLayer.Entityes;

namespace SportsStore.Tests
{
    public class CartServiceTests
    {
        private readonly MockProductReposiotory repository;

        private readonly Cart cart;

        private readonly CartService cartService;

        public CartServiceTests()
        {
            repository = new MockProductReposiotory();
            cart = new Cart();
            cartService = new CartService(repository, cart);
        }

        [Fact]
        public void GetCart_Should_Return_Cart()
        {
            Cart cartFromService = cartService.GetCart();

            Assert.Equal(cartFromService, cart);
        }

        [Fact]
        public void PutProductToCart_Should_Add_Product_To_Cart()
        {
            Product product = new Product()
            {
                Description = "Description",
                IsEnable = true,
                Name = "Name",
                Price = 10,
                ProductCategory = "Category",
                ProductID = 0
            };
            repository.SaveProduct(product);

            cartService.PutProductToCart(product.ProductID);
            Product productInCart = cart.Lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID).Product;

            Assert.Equal(productInCart.Name, product.Name);
        }

        [Fact]
        public void DeleteProductFromCart_Should_Remove_Product_From_Cart()
        {
            Product product = new Product()
            {
                Description = "Description",
                IsEnable = true,
                Name = "Name",
                Price = 10,
                ProductCategory = "Category",
                ProductID = 0
            };
            repository.SaveProduct(product);
            cartService.PutProductToCart(product.ProductID);

            cartService.DeleteProductFromCart(product.ProductID);

            CartLine cartLine = cart.Lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);

            Assert.Null(cartLine);
        }
    }
}
