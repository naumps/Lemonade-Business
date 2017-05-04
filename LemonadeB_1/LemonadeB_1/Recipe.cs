using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    [Serializable]
    public class Recipe
    {
        public int Leemons { get; set; }
        public int Ice { get; set; }
        public int Sugar { get; set; }
        public int Cups { get; set; }
        public decimal Price { get; set; }
        public bool Sunny { get; set; }

        public Recipe(int Leemons, int Ice, int Sugar, decimal Price, bool Sunny) {
            this.Leemons = Leemons;
            this.Ice = Ice;
            this.Sugar = Sugar;
            this.Cups = Cups;
            this.Price = Price;
            this.Sunny = Sunny;
        }

        public Recipe() {
            this.Leemons = 0;
            this.Ice = 0;
            this.Sugar = 0;
            this.Price = 0;
            this.Sunny = true;
        }

        public int calculateRecipe()
        {
            int x = 10;

            if (Leemons != 4)
            {
                x -= Math.Abs(Leemons - 4) * 2;
            }
            if (Sugar != 2)
            {
                x -= Math.Abs(Sugar - 2);
            }
            if (Sunny == true && Ice != 2)
            {
                x -= Math.Abs(Ice - 2);
            }
            if (Sunny == false && Ice != 0)
            {
                x -= Math.Abs(Ice - 2) * 3;
            }

            if (Sugar > 0)
            {
                if (Leemons / Sugar != 2)
                {
                    x -= (Leemons % Sugar);
                }
            }
            else
            {
                x -= (Leemons / 2);
            }

            if (x < 0) x = 0;
            return x;
        }

        public int calculatePriceSatisfaction() {
            decimal x = 0;

            if (Price > 2) {
                x += Math.Abs(Price - 2)*3;
            }


            if (x > 10) x = 10;
            return (int)x;
        }

    }
}
