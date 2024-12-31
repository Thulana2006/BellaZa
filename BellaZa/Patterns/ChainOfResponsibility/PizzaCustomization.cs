using BellaZa.Patterns.Builder;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BellaZa.Pizza;

namespace BellaZa
{
    public abstract class CustomizationHandler
    {
        protected CustomizationHandler nextHandler;

        public CustomizationHandler SetNext(CustomizationHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public abstract void HandleCustomization(PizzaBuilder pizza, JObject customization);
    }

    public class CrustHandler : CustomizationHandler
    {
        public override void HandleCustomization(PizzaBuilder pizza, JObject customization)
        {
            if (customization.ContainsKey("crust"))
            {
                pizza.addCrust(customization["crust"].ToObject<PizzaCrust>());
                Console.WriteLine($"Set crust to: {customization}");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleCustomization(pizza, customization);
            }
        }
    }

    public class SauceHandler : CustomizationHandler
    {
        public override void HandleCustomization(PizzaBuilder pizza, JObject customization)
        {
            if (customization.ContainsKey("sauce"))
            {
                pizza.addSauce(customization["sauce"].ToObject<PizzaSauce>());

                Console.WriteLine($"Set crust to: {customization}");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleCustomization(pizza, customization);
            }
        }
    }

    public class CheeseHandler : CustomizationHandler
    {
        public override void HandleCustomization(PizzaBuilder pizza, JObject customization)
        {
            if (customization.ContainsKey("cheese"))
            {
                pizza.addCheese(customization["cheese"].ToObject<PizzaCheese>());

                Console.WriteLine($"Set crust to: {customization}");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleCustomization(pizza, customization);
            }
        }
    }

    public class ToppingHandler : CustomizationHandler
    {
        public override void HandleCustomization(PizzaBuilder pizza, JObject customization)
        {
            if (customization.ContainsKey("Toppings"))
            {
                foreach(JProperty topping in customization["Toppings"])
                    pizza.addTopping(topping.ToObject<PizzaTopping>());
                Console.WriteLine($"Added topping: {customization}");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleCustomization(pizza, customization);
            }
        }
    }
}
