using BuisnessLayer.Repositories;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ViewLayer.ViewModels;

namespace ViewLayer.Services
{
    public class CartService
    {
        private readonly IProductRepository repository;

        private Cart cart;

        public CartService(IProductRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public Cart GetCart() => cart;

        public void PutProductToCart(int productId)
        {
            Product product = repository.FindProduct(productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
        }

        public void DeleteProductFromCart(int productId)
        {
            Product product = repository.FindProduct(productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
        }
    }
}
