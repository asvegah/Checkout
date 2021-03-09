using Checkout.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface IDataSource
    {
        IEnumerable<Item> Inventory { get; set; }
    }
}
