using System.Collections.Generic;
using System;
using System.Text;
namespace Order.Entities
{
    class OrderItem
    {
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public List<Product> ProductList { get; private set; } = new List<Product>();

        public OrderItem(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }
        public double SubTotal()
        {
            return Quantity * Price;
        }
        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            ProductList.Remove(product);
        }
    }
}