using System;
using System.Collections.Generic;
using System.Text;
using BellaZa.configuration;
using BellaZa.Patterns.Builder;

namespace BellaZa
{
    public enum PizzaMode
    {
        none,
        pickup,
        delivery
    }

    public enum PizzaSize
    {
        none,
        mini,
        large,
        extraLarge
    }

    public enum PizzaCrust
    {
        none,
        thin,
        thick,
        cauliflower,
        sicilian
    }








    public enum PizzaSauce
    {
        none,
        tomato,
        marinara
    }

    public enum PizzaCheese
    {
        none,
        mozarella,
        parmessa,
        provolone,
        cheddar,
        ricotto,
        feta
    }

    public enum PizzaTopping
    {
        none,
        pepperoni,
        mushrooms,
        sausage,
        spinach,
        bacon,
        blackOlive
    }




    public class Pizza
    {
        public PizzaSize size { get; }
        
        public PizzaCrust crust { get; }
        
        public PizzaSauce sauce { get; }

        public PizzaCheese cheese { get; }
        
        public List<PizzaTopping> toppings { get; }
        public string Name { get; set; }

        public Pizza() { }

        public Pizza(PizzaBuilder builder)
        {
            this.size = builder.size;
            this.crust = builder.crust;
            this.sauce = builder.sauce;
            this.cheese = builder.cheese;
            this.toppings = builder.toppings;

            PizzaPricing.Size = this.size; 
            this.crustPrice = PizzaPricing.getCrustPrice(this.crust);
            this.saucePrice = PizzaPricing.getSaucePrice(this.sauce);
            this.cheesePrice = PizzaPricing.getCheesePrice(this.cheese);
            this.toppingsPrice = PizzaPricing.getToppingPrice(this.toppings);

            //setting a default name by the size and cheese

            this.Name = this.size.ToString() + this.cheese.ToString();
        }

        public decimal crustPrice { get; }

        public decimal saucePrice { get; }

        public decimal cheesePrice { get; }

        public decimal toppingsPrice { get; }

        public virtual decimal getPrice()
        {
            return crustPrice + saucePrice + cheesePrice + toppingsPrice;
        }

        public string getDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----" + this.Name + "-----")
                .AppendLine(size.ToString() + " pizza")
                .AppendLine("with a " + crust.ToString() + " crust")
                .AppendLine("with " + sauce.ToString() + " sauce")
                .AppendLine("with " + cheese.ToString() + " cheese")
                .Append("and toppings as ")
                .AppendLine(String.Join(", ", toppings))
                .Append("for " + getPrice() + " LKR!");

            return sb.ToString();
        }
    }
}
