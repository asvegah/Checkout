using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice();
    }
}
