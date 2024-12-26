using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    // Observer pattern interfaces
    public interface IOrderObserver
    {
        void Update(string orderStatus);
    }

    public class Customer : IOrderObserver
    {
        public string Name { get; set; }

        public void Update(string orderStatus)
        {
            Console.WriteLine($"{Name} is notified: Order status - {orderStatus}");
        }
    }

    // Subject (Order)
    public class Order
    {
        private List<IOrderObserver> observers = new List<IOrderObserver>();
        private string status;

        public void Subscribe(IOrderObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IOrderObserver observer)
        {
            observers.Remove(observer);
        }

        public void SetStatus(string status)
        {
            this.status = status;
            Notify();
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(status);
            }
        }
    }
}