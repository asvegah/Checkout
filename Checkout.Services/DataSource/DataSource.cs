using Checkout.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.DataSource
{
    public class DataSource
    {
        public IEnumerable<Item> Inventory { get; set; }
    }
}
