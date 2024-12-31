using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza _pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override string ToString()
        {
            return _pizza.ToString();
        }

        public override decimal getPrice()
        {
            return _pizza.getPrice();
        }
    }

    public class ExtraToppingsDecorator : PizzaDecorator
    {
        private List<PizzaTopping> _extraToppings;

        public ExtraToppingsDecorator(Pizza pizza, List<PizzaTopping> extraToppings) : base(pizza)
        {
            _extraToppings = extraToppings;
        }

        public override string ToString()
        {
            var baseDescription = base.ToString();
            var extraToppingsDescription = "Extra toppings: " + string.Join(", ", _extraToppings);
            return baseDescription + "\n" + extraToppingsDescription;
        }

        public override decimal getPrice()
        {
            var basePrice = base.getPrice();
            var extraToppingsPrice = _extraToppings.Count * 150; // taking each topping amount 150Rs
            return basePrice + extraToppingsPrice;
        }
    }

    public class SpecialPackagingDecorator : PizzaDecorator
    {
        public SpecialPackagingDecorator(Pizza pizza) : base(pizza)
        {
        }

        public override string ToString()
        {
            var baseDescription = base.ToString();
            var packagingDescription = "Special packaging included.";
            return baseDescription + "\n" + packagingDescription;
        }

        public override decimal getPrice()
        {
            var basePrice = base.getPrice();
            var packagingPrice = (decimal) 200.0; 
            return basePrice + packagingPrice;
        }
    }

    public class BeveragesDecorator : PizzaDecorator
    {
        public BeveragesDecorator(Pizza pizza) : base(pizza)
        {

        }

        public override string ToString()
        {
            var baseDescription = base.ToString();
            var packagingDescription = "Beverages included.";
            return baseDescription + "\n" + packagingDescription;
        }

        public override decimal getPrice()
        {
            var basePrice = base.getPrice();
            var beveragePrice = (decimal) 400.0; 
            return basePrice + beveragePrice;
        }
    }

    public class SeasonalSpecialDecorator : PizzaDecorator
    {
        public SeasonalSpecialDecorator(Pizza pizza) : base(pizza)
        {

        }

        public override string ToString()
        {
            var baseDescription = base.ToString();
            var packagingDescription = "Seasonal discount included";
            return baseDescription + "\n" + packagingDescription;
        }

        public override decimal getPrice()
        {
            var basePrice = base.getPrice();
            var seasonalDiscount = (decimal)0.15;
            return basePrice * ((decimal)1.0 - seasonalDiscount);
        }
    }
}