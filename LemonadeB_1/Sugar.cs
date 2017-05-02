using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    public class Sugar : Item
    {

        public Sugar(String name, double price) : base(name, price) { }

        public override string getType()
        {
            return "Sugar";
        }
    }
}
