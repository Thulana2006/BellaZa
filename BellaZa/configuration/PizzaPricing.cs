using System.Collections.Generic;

namespace BellaZa.configuration
{
    public static class PizzaPricing
    {
        static Dictionary<PizzaSize, Dictionary<PizzaCrust, decimal>> CrustPrices = new Dictionary<PizzaSize, Dictionary<PizzaCrust, decimal>>()
        {
            { PizzaSize.mini, new Dictionary<PizzaCrust, decimal> {
                { PizzaCrust.none, 0 },
                { PizzaCrust.thin, 500 },
                { PizzaCrust.thick, 550 },
                { PizzaCrust.cauliflower, 650 },
                { PizzaCrust.sicilian, 600 }
            }},
            { PizzaSize.large, new Dictionary<PizzaCrust, decimal> {
                { PizzaCrust.none, 0 },
                { PizzaCrust.thin, 1600 },
                { PizzaCrust.thick, 1700 },
                { PizzaCrust.cauliflower, 1900 },
                { PizzaCrust.sicilian, 1800 }
            }},
            { PizzaSize.extraLarge, new Dictionary<PizzaCrust, decimal> {
                { PizzaCrust.none, 0 },
                { PizzaCrust.thin, 2000 },
                { PizzaCrust.thick, 2200 },
                { PizzaCrust.cauliflower, 2500 },
                { PizzaCrust.sicilian, 2400 }
            }}
        };

        static Dictionary<PizzaSize, Dictionary<PizzaSauce, decimal>> SaucePrices = new Dictionary<PizzaSize, Dictionary<PizzaSauce, decimal>>()
        {
            { PizzaSize.mini, new Dictionary<PizzaSauce, decimal> {
                { PizzaSauce.none, 0 },
                { PizzaSauce.tomato, 50 },
                { PizzaSauce.marinara, 70 }
            }},
            { PizzaSize.large, new Dictionary<PizzaSauce, decimal> {
                { PizzaSauce.none, 0 },
                { PizzaSauce.tomato, 100 },
                { PizzaSauce.marinara, 120 }
            }},
            { PizzaSize.extraLarge, new Dictionary<PizzaSauce, decimal> {
                { PizzaSauce.none, 0 },
                { PizzaSauce.tomato, 150 },
                { PizzaSauce.marinara, 180 }
            }}
        };

        static Dictionary<PizzaSize, Dictionary<PizzaCheese, decimal>> CheesePrices = new Dictionary<PizzaSize, Dictionary<PizzaCheese, decimal>>()
        {
            { PizzaSize.mini, new Dictionary<PizzaCheese, decimal> {
                { PizzaCheese.none, 0 },
                { PizzaCheese.mozarella, 100 },
                { PizzaCheese.parmessa, 120 },
                { PizzaCheese.provolone, 130 },
                { PizzaCheese.cheddar, 110 },
                { PizzaCheese.ricotto, 140 },
                { PizzaCheese.feta, 150 }
            }},
            { PizzaSize.large, new Dictionary<PizzaCheese, decimal> {
                { PizzaCheese.none, 0 },
                { PizzaCheese.mozarella, 200 },
                { PizzaCheese.parmessa, 220 },
                { PizzaCheese.provolone, 230 },
                { PizzaCheese.cheddar, 210 },
                { PizzaCheese.ricotto, 240 },
                { PizzaCheese.feta, 250 }
            }},
            { PizzaSize.extraLarge, new Dictionary<PizzaCheese, decimal> {
                { PizzaCheese.none, 0 },
                { PizzaCheese.mozarella, 300 },
                { PizzaCheese.parmessa, 320 },
                { PizzaCheese.provolone, 330 },
                { PizzaCheese.cheddar, 310 },
                { PizzaCheese.ricotto, 340 },
                { PizzaCheese.feta, 350 }
            }}
        };

        static Dictionary<PizzaSize, Dictionary<PizzaTopping, decimal>> ToppingPrices = new Dictionary<PizzaSize, Dictionary<PizzaTopping, decimal>>()
        {
            { PizzaSize.mini, new Dictionary<PizzaTopping, decimal> {
                { PizzaTopping.none, 0 },
                { PizzaTopping.pepperoni, 50 },
                { PizzaTopping.mushrooms, 40 },
                { PizzaTopping.sausage, 60 },
                { PizzaTopping.spinach, 30 },
                { PizzaTopping.bacon, 70 },
                { PizzaTopping.blackOlive, 35 }
            }},
            { PizzaSize.large, new Dictionary<PizzaTopping, decimal> {
                { PizzaTopping.none, 0 },
                { PizzaTopping.pepperoni, 100 },
                { PizzaTopping.mushrooms, 80 },
                { PizzaTopping.sausage, 120 },
                { PizzaTopping.spinach, 60 },
                { PizzaTopping.bacon, 140 },
                { PizzaTopping.blackOlive, 70 }
            }},
            { PizzaSize.extraLarge, new Dictionary<PizzaTopping, decimal> {
                { PizzaTopping.none, 0 },
                { PizzaTopping.pepperoni, 150 },
                { PizzaTopping.mushrooms, 120 },
                { PizzaTopping.sausage, 180 },
                { PizzaTopping.spinach, 90 },
                { PizzaTopping.bacon, 210 },
                { PizzaTopping.blackOlive, 100 }
            }}
        };

        public static PizzaSize Size { get; set; }

        public static decimal getCrustPrice(PizzaCrust crust, PizzaSize? size = null)
        {
            PizzaSize _size = size ?? Size;
            
            if (_size == PizzaSize.none) return 0;
            return CrustPrices[_size][crust];
        }

        public static decimal getSaucePrice(PizzaSauce sauce, PizzaSize? size = null)
        {
            PizzaSize _size = size ?? Size;

            if (_size == PizzaSize.none) return 0;
            return SaucePrices[_size][sauce];
        }

        public static decimal getCheesePrice(PizzaCheese cheese, PizzaSize? size = null)
        {
            PizzaSize _size = size ?? Size;

            if (_size == PizzaSize.none) return 0;

            return CheesePrices[_size][cheese];
        }

        public static decimal getToppingPrice(List<PizzaTopping> toppings, PizzaSize? size = null)
        {
            PizzaSize _size = size ?? Size;

            if (_size == PizzaSize.none) return 0;

            decimal price = 0;

            foreach (PizzaTopping topping in toppings)
                price += ToppingPrices[_size][topping];

            return price;
        }
    }
}
