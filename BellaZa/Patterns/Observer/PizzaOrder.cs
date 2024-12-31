using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public interface IOrderObserver
    {
        void Update(string orderStatus);
    }
    
    public class PizzaOrder
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