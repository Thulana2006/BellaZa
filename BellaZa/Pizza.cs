using System;
using System.Collections.Generic;
using System.Text;

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
        pepperoni,
        mushrooms,
        sausage,
        spinach,
        bacon,
        blackOlive
    }

    public class Pizza
    {
        private PizzaSize size;
        private PizzaCrust crust;
        private PizzaSauce sauce;
        private PizzaCheese cheese;
        
        public List<PizzaTopping> toppings { get; }
        public string name { get; set; }

        private Pizza(PizzaBuilder builder)
        {
            this.size = builder.size;
            this.crust = builder.crust;
            this.sauce = builder.sauce;
            this.cheese = builder.cheese;
            this.toppings = builder.toppings;

            this.crustPrice = builder.getCrustPrice();
            this.saucePrice = builder.getSaucePrice();
            this.cheesePrice = builder.getCheesePrice();
            this.toppingsPrice = builder.getToppingPrice();
        }

        public decimal crustPrice { get; }

        public decimal saucePrice { get; }

        public decimal cheesePrice { get; }

        public decimal toppingsPrice { get; }

        public decimal getPrice()
        {
            return crustPrice + saucePrice + cheesePrice + toppingsPrice;
        }

        public string getDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----" + this.name + "-----")
                .AppendLine(size.ToString() + " pizza")
                .AppendLine("with a " + crust.ToString() + " crust")
                .AppendLine("with " + sauce.ToString() + " sauce")
                .AppendLine("with " + cheese.ToString() + " cheese")
                .Append("and toppings as ")
                .AppendLine(String.Join(", ", toppings))
                .Append("for " + getPrice() + " LKR!");

            return sb.ToString();
        }

        public class PizzaBuilder
        {
            public PizzaSize size;
            public PizzaCrust crust;
            public PizzaSauce sauce;
            public PizzaCheese cheese;
            public List<PizzaTopping> toppings = new List<PizzaTopping>();

            private Dictionary<PizzaSize, int> maxTopping = new Dictionary<PizzaSize, int>
            {
                { PizzaSize.mini, 2 },
                { PizzaSize.large, 5 },
                { PizzaSize.extraLarge, 6 }
            };

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
                if (toppings.Count < maxTopping[this.size])
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

            public decimal getCrustPrice()
            {
                if (this.crust == PizzaCrust.none) return 0;

                Dictionary<PizzaSize, Dictionary<PizzaCrust, decimal>> prices = new Dictionary<PizzaSize, Dictionary<PizzaCrust, decimal>>()
                {
                    { PizzaSize.mini, new Dictionary<PizzaCrust, decimal> {
                        { PizzaCrust.thin, 500 },
                        { PizzaCrust.thick, 550 },
                        { PizzaCrust.cauliflower, 650 },
                        { PizzaCrust.sicilian, 600 }
                    }},
                    { PizzaSize.large, new Dictionary<PizzaCrust, decimal> {
                        { PizzaCrust.thin, 1600 },
                        { PizzaCrust.thick, 1700 },
                        { PizzaCrust.cauliflower, 1900 },
                        { PizzaCrust.sicilian, 1800 }
                    }},
                    { PizzaSize.extraLarge, new Dictionary<PizzaCrust, decimal> {
                        { PizzaCrust.thin, 2000 },
                        { PizzaCrust.thick, 2200 },
                        { PizzaCrust.cauliflower, 2500 },
                        { PizzaCrust.sicilian, 2400 }
                    }}
                };

                return prices[this.size][this.crust];
            }

            public decimal getSaucePrice()
            {
                if (this.sauce == PizzaSauce.none) return 0;

                Dictionary<PizzaSize, Dictionary<PizzaSauce, decimal>> prices = new Dictionary<PizzaSize, Dictionary<PizzaSauce, decimal>>()
                {
                    { PizzaSize.mini, new Dictionary<PizzaSauce, decimal> {
                        { PizzaSauce.tomato, 50 },
                        { PizzaSauce.marinara, 70 }
                    }},
                    { PizzaSize.large, new Dictionary<PizzaSauce, decimal> {
                        { PizzaSauce.tomato, 100 },
                        { PizzaSauce.marinara, 120 }
                    }},
                    { PizzaSize.extraLarge, new Dictionary<PizzaSauce, decimal> {
                        { PizzaSauce.tomato, 150 },
                        { PizzaSauce.marinara, 180 }
                    }}
                };

                return prices[this.size][this.sauce];
            }

            public decimal getCheesePrice()
            {
                if (this.cheese == PizzaCheese.none) return 0;

                Dictionary<PizzaSize, Dictionary<PizzaCheese, decimal>> prices = new Dictionary<PizzaSize, Dictionary<PizzaCheese, decimal>>()
                {
                    { PizzaSize.mini, new Dictionary<PizzaCheese, decimal> {
                        { PizzaCheese.mozarella, 100 },
                        { PizzaCheese.parmessa, 120 },
                        { PizzaCheese.provolone, 130 },
                        { PizzaCheese.cheddar, 110 },
                        { PizzaCheese.ricotto, 140 },
                        { PizzaCheese.feta, 150 }
                    }},
                    { PizzaSize.large, new Dictionary<PizzaCheese, decimal> {
                        { PizzaCheese.mozarella, 200 },
                        { PizzaCheese.parmessa, 220 },
                        { PizzaCheese.provolone, 230 },
                        { PizzaCheese.cheddar, 210 },
                        { PizzaCheese.ricotto, 240 },
                        { PizzaCheese.feta, 250 }
                    }},
                    { PizzaSize.extraLarge, new Dictionary<PizzaCheese, decimal> {
                        { PizzaCheese.mozarella, 300 },
                        { PizzaCheese.parmessa, 320 },
                        { PizzaCheese.provolone, 330 },
                        { PizzaCheese.cheddar, 310 },
                        { PizzaCheese.ricotto, 340 },
                        { PizzaCheese.feta, 350 }
                    }}
                };

                return prices[this.size][this.cheese];
            }

            public decimal getToppingPrice()
            {
                if (toppings.Count == 0) return 0;

                Dictionary<PizzaSize, Dictionary<PizzaTopping, decimal>> prices = new Dictionary<PizzaSize, Dictionary<PizzaTopping, decimal>>()
                {
                    { PizzaSize.mini, new Dictionary<PizzaTopping, decimal> {
                        { PizzaTopping.pepperoni, 50 },
                        { PizzaTopping.mushrooms, 40 },
                        { PizzaTopping.sausage, 60 },
                        { PizzaTopping.spinach, 30 },
                        { PizzaTopping.bacon, 70 },
                        { PizzaTopping.blackOlive, 35 }
                    }},
                    { PizzaSize.large, new Dictionary<PizzaTopping, decimal> {
                        { PizzaTopping.pepperoni, 100 },
                        { PizzaTopping.mushrooms, 80 },
                        { PizzaTopping.sausage, 120 },
                        { PizzaTopping.spinach, 60 },
                        { PizzaTopping.bacon, 140 },
                        { PizzaTopping.blackOlive, 70 }
                    }},
                    { PizzaSize.extraLarge, new Dictionary<PizzaTopping, decimal> {
                        { PizzaTopping.pepperoni, 150 },
                        { PizzaTopping.mushrooms, 120 },
                        { PizzaTopping.sausage, 180 },
                        { PizzaTopping.spinach, 90 },
                        { PizzaTopping.bacon, 210 },
                        { PizzaTopping.blackOlive, 100 }
                    }}
                };

                decimal price = 0;

                foreach (PizzaTopping topping in toppings)
                    price += prices[this.size][topping];

                return price;
            }
        }
    }
}
