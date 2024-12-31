using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public abstract class PizzaOrderState
    {
        public abstract void Handle(OrderContext context);
    }

    public class OrderPlacedState : PizzaOrderState
    {
        public override void Handle(OrderContext context)
        {
            Console.WriteLine("Order has been placed. Preparing the pizza.");
            context.SetState(new InPreparationState());
        }
    }

    public class InPreparationState : PizzaOrderState
    {
        public override void Handle(OrderContext context)
        {
            Console.WriteLine("Pizza is being prepared.");
            context.SetState(new OutForDeliveryState());
        }
    }

    public class OutForDeliveryState : PizzaOrderState
    {
        public override void Handle(OrderContext context)
        {
            Console.WriteLine("Pizza is out for delivery.");
        }
    }

    public class OrderContext
    {
        private PizzaOrderState _state;
        private PizzaMode _mode;

        public OrderContext(PizzaOrderState state, PizzaMode mode)
        {
            this._state = state;
            this._mode = mode;
        }

        public void SetState(PizzaOrderState state)
        {
            this._state = state;
        }

        public void Next()
        {
            _state.Handle(this);
        }
    }
}
