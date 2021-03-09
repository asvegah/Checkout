using Checkout.Interfaces;
using Checkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkout.Services
{
    public class Repository
    {
        private readonly IEnumerable<Item> _inventory;

        public Repository(IDataSource dataSource)
        {
            _inventory = dataSource.Inventory;
        }

        public Item GetItem(string scannedItem)
        {
            Item item = _inventory
                .Where(i => i.SKU == scannedItem)
                .Select(i => i).SingleOrDefault();

            if (item == null)
            {
                Console.WriteLine("Item does not exist");
            }

            return item;
        }

        public bool ContainsSpecialOffer(Item scannedItem)
        {
            return scannedItem.SpecialOffer != null;
        }
    }
}
