

using Checkout.Interfaces;

namespace Checkout.Models
{
    public class Item
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public ISpecialOffer SpecialOffer { get; set; }
    }
}