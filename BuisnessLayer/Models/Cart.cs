using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entityes;

namespace BuisnessLayer.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
        {
            CartLine line = lineCollection
                .FirstOrDefault(p => p.Product.ProductID == product.ProductID);
             
            if (line != null )
            {
                --line.Quantity;

                if (line.Quantity == 0)
                {
                    lineCollection.RemoveAll(l => l.Product.ProductID == line.Product.ProductID);
                }
            }
        }
            

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;

    }
}
