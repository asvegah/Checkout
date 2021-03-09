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

        internal void Setup()
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

        [Fact]
        public void CalculateSingleItem_A_Total()
        {
            //Arrange
            Setup();
            ICheckout checkout = new Checkout.Services.Checkout(_repository);

            //Act
            checkout.Scan("A99");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.Equal(0.5m, total);
        }

        [Fact]
        public void CaculateTwosItems_A_WithoutSpecialOffer_Total()
        {
            //Arrange
            Setup();
            ICheckout checkout = new Checkout.Services.Checkout(_repository);

            //Act
            checkout.Scan("A99");
            checkout.Scan("A99");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.Equal(1m, total);
        }

        [Fact]
        public void CaculateTwosItems_B_WithSpecialOffer_Total()
        {
            //Arrange
            Setup();
            ICheckout checkout = new Checkout.Services.Checkout(_repository);

            //Act
            checkout.Scan("B15");
            checkout.Scan("B15");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.Equal(0.45m, total);
        }

        [Fact]
        public void MultipleItems_MultipleSpecialOffers_Total()
        {
            //Arrange
            Setup();
            ICheckout checkout = new Checkout.Services.Checkout(_repository);

            //Act
            checkout.Scan("B15");
            checkout.Scan("A99");
            checkout.Scan("B15");
            checkout.Scan("B15");
            checkout.Scan("A99");
            checkout.Scan("B15");
            checkout.Scan("A99");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.Equal(2.20m, total);
        }




    }
}
