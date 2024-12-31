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
        private PizzaOrderState _state;

        public PizzaMode Mode { get; }

        public Pizza Pizza { get; }

        public decimal DiscountedPrice { get; }

        public bool Paid { get; }

        private double _rating;

        public double Rating
        {
            get { return _rating; }
            set
            {
                if (value <= 5.0)
                {
                    _rating = value;
                }
            }
        }

        public PizzaOrder(Pizza pizza, PizzaMode mode, decimal? discountedPrice = null, bool? paid = null, PizzaOrderState state = null)
        {
            this._state = state ?? new OrderPlacedState();
            this.Mode = mode;
            this.Pizza = pizza;
            this.Paid = paid ?? true;
            this.DiscountedPrice = discountedPrice ?? pizza.getPrice();
        }

        public void SetState(PizzaOrderState state)
        {
            this._state = state;
            Notify();
        }

        public void Next()
        {
            _state.Handle(this);
        }

        public void Subscribe(IOrderObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IOrderObserver observer)
        {
            observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(_state.ToString());
            }
        }
    }
}