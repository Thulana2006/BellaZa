using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public class PizzaPackage
    {
        public PizzaPackage(Pizza pizza)
        {

        }
    }

    public enum PizzaComponentSize
    {
        normal,
        small,
        large
    }

    public interface IPizzaComponent
    {
        string Name { get; }

        string Description { get; }
    
        PizzaComponentSize Size { get; }
    }
}