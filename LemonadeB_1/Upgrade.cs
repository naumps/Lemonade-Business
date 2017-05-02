using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    public class Upgrade
    {
        public String name { get; set; }
        public decimal price { get; set; }
        public String info { get; set; }
        public int upgradeValue { get; set; }

        public Upgrade(String _name, decimal _price, int _upgradeValue, String _info) {
            name = _name;
            price = _price;
            info = _info;
            upgradeValue = _upgradeValue;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
