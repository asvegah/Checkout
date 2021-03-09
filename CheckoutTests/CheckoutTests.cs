using Checkout.DataSource;
using Checkout.Interfaces;
using Checkout.Models;
using Checkout.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace CheckoutTests
{
    public class CheckoutTests 
    {
        private IRepository _repository;
        public void Setup()
        {
            var dataSource = new DataSource
            {

                 Inventory = new List<Item>
                 {
                        new Item{ SKU = "A99", Price = 0.50m, SpecialOffer = new SpecialOffer {Qty = 3, SpecialPrice = 1.30m} },
                        new Item{ SKU = "B15", Price = 0.30m, SpecialOffer = new SpecialOffer {Qty = 2, SpecialPrice = 0.45m} },
                        new Item{ SKU = "C40", Price = 0.60m },
                 }
        };

            _repository = new Repository(dataSource);
        }

    }
}
