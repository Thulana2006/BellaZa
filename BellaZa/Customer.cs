using System.Collections.Generic;

namespace BellaZa
{
    public class Customer
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
            set
            {
                if (value <= 50.0)
                    loyaltyPercentage = value;
            }
        }

        public Customer()
        {
            this.Name = "default";
            this.password = "default123";

            pizzaCollection = new List<Pizza>();
        }

        public Customer(string name, string password)
        {
            this.Name = name;
            this.password = password;
        }

        public bool checkPassword(string password)
        {
            return password == this.password;
        }
    }
}
