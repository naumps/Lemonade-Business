using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    public class Ice : Item
    {

        public Ice(String name, double price) : base(name, price)
        {

        }

        public override string getType()
        {
            return "Ice";
        }
    }
}
