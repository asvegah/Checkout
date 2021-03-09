using Checkout.Interfaces;
using Checkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkout.Services
{
    public class Checkout : ICheckout
    {
        private readonly List<Item> _scannedItems;
        private readonly IRepository _repository;

        public Checkout(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;

            _scannedItems = new List<Item>();
        }
        public void Scan(string sku)
        {
            var item = _repository.GetItem(sku);
            if(item != null)
            {
                _scannedItems.Add(item);
            }
      
        }

        public decimal GetTotalPrice()
        {
            decimal runningValue = 0;

            var specialOffers = new List<Item>();

            foreach (var scannedItem in _scannedItems)
            {
                if (_repository.ContainsSpecialOffer(scannedItem))
                {
                    specialOffers.Add(scannedItem);
                }
                else
                {
                    runningValue = runningValue + scannedItem.Price;
                }
            }

            decimal specialOfferValue = CalculateSpecialOfferValue(specialOffers);

            return runningValue + specialOfferValue;
        }

        private static decimal CalculateSpecialOfferValue(IEnumerable<Item> specialOffer)
        {
            var specialOfferValue = 0m;

            var query = specialOffer.GroupBy(x => new { x.SKU, x.Price });

            foreach (var itemGroup in query)
            {
                var groupCount = itemGroup.Count();

                var offer = itemGroup.Select(x => x.SpecialOffer).First();

                var howManyDeals = groupCount / offer.Qty;
                var nonDeals = groupCount % offer.Qty;

                var dealValue = howManyDeals * offer.SpecialPrice;
                var nonDealValue = nonDeals * itemGroup.Key.Price;

                specialOfferValue = specialOfferValue + dealValue + nonDealValue;

            }

            return specialOfferValue;

        }
    }
}
