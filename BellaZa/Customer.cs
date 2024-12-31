using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    // Observer pattern interfaces
    

    public class Customer : IOrderObserver
    {
        public string Name { get; set; }

        public void Update(string orderStatus)
        {
            Console.WriteLine($"{Name} is notified: Order status - {orderStatus}");
        }
    }

    // Subject (Order)
    
}