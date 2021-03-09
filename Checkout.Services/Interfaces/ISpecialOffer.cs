using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface ISpecialOffer
    {
        int Qty { get; set; }
        decimal SpecialPrice { get; set; }
    }
}
