﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisioningEngineLib.Models
{
    public class Person : IAnimal
    {
        public string BirthYear { get; set; }

        public void GiveGift()
        {

        }

        public void Eat()
        {
            Console.WriteLine("I use utensils to eat");
        }
    }
}
