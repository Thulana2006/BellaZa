using System.Collections.Generic;

namespace BellaZa
{
    public class UserProfile
    {
        private List<Pizza> pizzacollection;

        public string Name { get; set; }

        private string password;

        public List<Pizza> pizzaCollection
        {
            get
            {
                return pizzacollection;
            }

            set
            {
                pizzacollection = value;
            }
        }

        private double loyaltyPercentage;

        public double LoyaltyPercentage
        {
            get
            {
                return loyaltyPercentage;
            }
            private set
            {
                if (value <= 50.0)
                    loyaltyPercentage = value;
            }
        }

        public UserProfile()
        {
            this.Name = "default";
            this.password = "default123";

            pizzaCollection = new List<Pizza>();
        }

        public UserProfile(string name, string password)
        {
            this.Name = name;
            this.password = password;

            pizzaCollection = new List<Pizza>();
        }

        public bool checkPassword(string password)
        {
            return password == this.password;
        }

        public void increaseLoyalty(PizzaSize? size)
        {
            switch (size)
            {
                case PizzaSize.mini:
                    LoyaltyPercentage += 0.05;
                    break;
                case PizzaSize.large:
                    LoyaltyPercentage += 0.06;
                    break;
                case PizzaSize.extraLarge:
                    LoyaltyPercentage += 0.12;
                    break;
                default:
                    LoyaltyPercentage += 0.02;
                    break;
            }
        }
    }
}
