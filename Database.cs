using Checkout.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    public class Database
    {
        public IEnumerable<Item> Inventory { get; set; }

        public Database()
        {
            Inventory = new List<Item>
                {
                    new Item{SKU = "A99", Price = 0.50m},
                    new Item{SKU = "B15", Price = 0.30m},
                    new Item{SKU = "C40", Price = 0.60m},
                };
        }
    }
}
