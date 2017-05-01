using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    public class Leemon : Item
    {
        public Leemon(String name, double price) : base(name, price) { }


        public override string getType()
        {
            return "Leemon";
        }
    }
}
