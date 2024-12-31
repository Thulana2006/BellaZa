using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public abstract class PizzaOrderState
    {
        public abstract void Handle(PizzaOrder context);
    }

    public class OrderPlacedState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Order has been placed");
            context.SetState(new InPreparationState());
        }

        public override string ToString()
        {
            return "order placed";
        }
    }

    public class InPreparationState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Pizza is being prepared.");

            if(context.Mode == PizzaMode.pickup)
                context.SetState(new ReadyForPickupState());
            else
                context.SetState(new OutForDeliveryState());
        }

        public override string ToString()
        {
            return "preparing";
        }
    }

    public class OutForDeliveryState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Pizza is out for delivery.");
            context.SetState(new DeliveredState());
        }

        public override string ToString()
        {
            return "delivering";
        }
    }

    public class ReadyForPickupState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Pizza is ready for pickup.");
        }

        public override string ToString()
        {
            return "ready";
        }
    }

    public class DeliveredState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Pizza is delivered.");
        }

        public override string ToString()
        {
            return "delivered";
        }
    }
}