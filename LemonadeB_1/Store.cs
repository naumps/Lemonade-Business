using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeB_1
{
    public class Store
    {
        //Konstantite pretstavuvaat cena na produktite, moze da bidat fiksni ili da se
        //mestat na pocetokot na igrata
        public readonly int LEEMON_PRICE = 3;
        public readonly int SUGAR_PRICE = 1;
        public readonly double ICE_PRICE = 0.5;

        public double Money { get; set; }

        public double LemonadePrice { get; set; }
        public String NameOfStore { get; set; }
        public List<Leemon> Leemons { get; set; }
        public List<Ice> Ice { get; set; }
        public List<Sugar> Sugar { get; set; }


        public Store(String name)
        {
            NameOfStore = name;
            Leemons = new List<Leemon>();
            Ice = new List<Ice>();
            Sugar = new List<Sugar>();
            Money = 20.5;

        }

        public void addLeemon()
        {
            if (Money >= LEEMON_PRICE)
            {
                Leemons.Add(new Leemon("Yellow Leemon", LEEMON_PRICE));
                Money -= LEEMON_PRICE;

            }
        }
        public void removeLeemon()
        {
            if (Leemons.Count != 0)
            {
                Leemons.RemoveAt(Leemons.Count - 1);
                Money += LEEMON_PRICE;
            }
        }

        public void addSugar()
        {
            if (Money >= SUGAR_PRICE)
            {
                Sugar.Add(new Sugar("Sugar", SUGAR_PRICE));
                Money -= SUGAR_PRICE;

            }
        }
        public void removeSugar()
        {
            if (Sugar.Count != 0)
            {
                Sugar.RemoveAt(Sugar.Count - 1);
                Money += SUGAR_PRICE;
            }
        }
        public void addIce()
        {
            if (Money >= ICE_PRICE)
            {
                Ice.Add(new Ice("Ice", ICE_PRICE));
                Money -= ICE_PRICE;

            }
        }
        public void removeIce()
        {
            if (Ice.Count != 0)
            {
                Ice.RemoveAt(Ice.Count - 1);
                Money += ICE_PRICE;
            }
        }


        

        public int calculatePercentOfHappyPeople(int idealNumber,int cups)
        {
            int difference = Math.Abs(idealNumber - cups);

            if (difference == 0)
            {
                return 95;
            }
            else if (difference <= 2)
            {
                return 75;
            }
            else if (difference <= 3)
            {
                return 50;
            }
            else
            {
                return 15;
            }
        }




    }
}
