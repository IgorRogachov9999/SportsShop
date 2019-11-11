using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SportsStore.Tests.MockRepositories
{
    public class CartLineMock
    {
        public int Product { get; set; }

        public int Quantity { get; set; }

        public CartLineMock(int product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    public class CartMock
    {
        public LinkedList<CartLineMock> cartLines;

        public CartMock()
        {
            cartLines = new LinkedList<CartLineMock>();
        }

        public void AddItem(int product, int quantity)
        {
            cartLines.AddLast(new CartLineMock(product, quantity));
        }

        public void RemoveLine(int product)
        {
            cartLines.Remove(cartLines.FirstOrDefault(c => c.Product == product));
        }
    }
}
