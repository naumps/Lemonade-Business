using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
   public abstract class Item
    {
        public String Name { get; set; }
        public double Price { get; set; }

        public Item(String name, double price)
        {
            Name = name;
            Price = price;
        }
        public abstract String getType();
    }
}
