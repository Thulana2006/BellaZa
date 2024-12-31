using System.Collections.Generic;

namespace BellaZa.configuration
{
    public static class PizzaMaxToppings
    {
        static Dictionary<PizzaSize, int> maxTopping = new Dictionary<PizzaSize, int>
        {
            { PizzaSize.mini, 2 },
            { PizzaSize.large, 5 },
            { PizzaSize.extraLarge, 6 }
        };

        public static PizzaSize Size { get; set; }

        public static int getMaxToppingsCount(PizzaSize? size = null)
        {
            PizzaSize _size = size ?? Size;
            return maxTopping[_size];
        }
    }
}
