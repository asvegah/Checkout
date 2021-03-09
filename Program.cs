using System;
using Checkout.Services;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {

            Database ds = new Database();
            Services.Checkout checkout = new Services.Checkout(new Repository(ds));

            Console.WriteLine("Begin scanning items. Type 'Total' when complete");

            bool scanning = true;

            while (scanning)
            {
                var input = Console.ReadLine();

                if (input != "Total")
                {
                    checkout.Scan(input);
                }
                else
                {
                    scanning = false;

                    var totalprice = checkout.GetTotalPrice();
                    Console.WriteLine($"The total price is: {totalprice}");
                    Console.Read();
                }
            }
        }
    }
}
