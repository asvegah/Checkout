

using Checkout.Interfaces;

namespace Checkout.Models
{
    public class SpecialOffer : ISpecialOffer
    {
        public int Qty { get; set; }
        public decimal SpecialPrice { get; set; }
    }
}