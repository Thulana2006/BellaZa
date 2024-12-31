using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class PizzaOrderCommand : ICommand
    {
        private PizzaOrder _order;

        public PizzaOrderCommand(PizzaOrder order)
        {
            _order = order;
        }

        public void Execute()
        {
            _order.Next();
        }
    }
    
    public class CancelOrderCommand : ICommand
    {
        private readonly OrderService _orderService;
        private readonly PizzaOrder _order;

        public CancelOrderCommand(OrderService orderService, PizzaOrder order)
        {
            _orderService = orderService;
            _order = order;
        }

        public void Execute()
        {
            _orderService.CancelOrder(_order);
        }
    }

    public class RateOrderCommand : ICommand
    {
        private readonly OrderService _orderService;
        private readonly PizzaOrder _order;
        private readonly double _rating;

        public RateOrderCommand(OrderService orderService, PizzaOrder order, double rating)
        {
            _orderService = orderService;
            _order = order;
            _rating = rating;
        }

        public void Execute()
        {
            _orderService.RateOrder(_order, _rating);
        }
    }

    public class OrderService
    {
        public void CancelOrder(PizzaOrder order)
        {
            order.SetState(new OrderCancelledState());
        }

        public void RateOrder(PizzaOrder order, double rating)
        {
            order.Rating = rating;
        }
    }

    public class CommandInvoker
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            _commands.Clear();
        }
    }

    public class OrderCancelledState : PizzaOrderState
    {
        public override void Handle(PizzaOrder context)
        {
            Console.WriteLine(context.Pizza.Name + ": Pizza order is cancelled.");
        }

        public override string ToString()
        {
            return "cancelled";
        }
    }
}