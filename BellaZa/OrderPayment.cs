using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }
    
    public class PaypalPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} LKR via paypal.");
        }
    }

    public class StripePayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} LKR via stripe.");
        }
    }

    public class TwoCheckOutPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} LKR via 2CheckOut.");
        }
    }

    // Payment context class
    public class PaymentContext
    {
        private readonly IPaymentStrategy paymentStrategy;

        public PaymentContext(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public void ExecutePayment(decimal amount)
        {
            paymentStrategy.ProcessPayment(amount);
        }
    }
}
