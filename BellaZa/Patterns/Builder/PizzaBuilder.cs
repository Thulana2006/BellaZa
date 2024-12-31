using System.Collections.Generic;
using BellaZa.configuration;

namespace BellaZa.Patterns.Builder
{
    public class PizzaBuilder
    {
        public PizzaSize size;
        public PizzaCrust crust;
        public PizzaSauce sauce;
        public PizzaCheese cheese;
        public List<PizzaTopping> toppings = new List<PizzaTopping>();

        public PizzaBuilder setSize(PizzaSize size)
        {
            this.size = size;
            return this;
        }

        public PizzaBuilder addCrust(PizzaCrust crust)
        {
            this.crust = crust;
            return this;
        }

        public PizzaBuilder addSauce(PizzaSauce sauce)
        {
            this.sauce = sauce;
            return this;
        }

        public PizzaBuilder addCheese(PizzaCheese cheese)
        {
            this.cheese = cheese;
            return this;
        }

        public PizzaBuilder addTopping(PizzaTopping topping)
        {
            if (toppings.Count < PizzaMaxToppings.getMaxToppingsCount(this.size))
                this.toppings.Add(topping);
            return this;
        }

        public PizzaBuilder addToppings(List<PizzaTopping> toppings)
        {
            foreach (PizzaTopping topping in toppings)
                addTopping(topping);
            return this;
        }

        public PizzaBuilder clearToppings()
        {
            this.toppings.Clear();
            return this;
        }

        public Pizza build()
        {
            return new Pizza(this);
        }
    }
}
