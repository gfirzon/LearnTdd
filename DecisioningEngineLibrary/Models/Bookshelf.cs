using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisioningEngineLib.Models
{
    public class Bookshelf : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("I am aa bookshelf and I eat virtually...");
        }
    }
}
