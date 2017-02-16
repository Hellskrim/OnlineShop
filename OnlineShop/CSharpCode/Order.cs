using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.CSharpCode
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice { get { return (1 + TaxRate) * Price; } }
        public bool isPurchased { get; private set; }

        public Order(int id, decimal price)
        {
            this.Id = id;
            if (price <= 0)
            {
                throw new Exception("Price must be greater than 0.");
            }
            this.Price = price;
        }
        public void Purchase()
        {
            if (isPurchased)
            {
                throw new Exception("Order is already purchased.");
            }
            this.isPurchased = true;
        }
    }
}