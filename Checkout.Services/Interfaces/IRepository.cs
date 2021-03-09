using Checkout.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface IRepository
    {
        Item GetItem(string scannedItem);
        bool ContainsSpecialOffer(Item scannedItem);
    }

}
