using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LemonadeB_1
{
    [Serializable]
    public class Store
    {
        //Konstantite pretstavuvaat cena na produktite, moze da bidat fiksni ili da se
        //predefiniraat na pocetokot na igrata
        public readonly decimal LEEMON_PRICE = 3m;
        public readonly decimal SUGAR_PRICE = 1m;
        public readonly decimal ICE_PRICE = 0.5m;
        public readonly decimal CUP_PRICE = 0.5m;

        public readonly int LEEMON_PACKAGE_AMOUNT = 12;
        public readonly int SUGAR_PACKAGE_AMOUNT = 10;
        public readonly int ICE_PACKAGE_AMOUNT = 15;
        public readonly int CUPS_PACKAGE_AMOUNT = 20;

        public String NameOfStore { get; set; }
        public int Leemons { get; set; }
        public int Ice { get; set; }
        public int Sugar { get; set; }
        public int Cups { get; set; }
        public decimal Money { get; set; }

        public int lastRecipeLeamons { get; set; }
        public int lastRecipeSugar { get; set; }
        public int lastRecipeIce { get; set; }
        public int lastRecipeCups { get; set; }

        public List<Upgrade> upgrades { get; set; }

        public Recipe recipe;
        public decimal price;
        public bool sunny;
        public int satisfactionPercent;
        public int PricesatiSfactionPercent;
        public int Popularity;
        public Random random;
        public int people { get; set; }
        public Store(String name)
        {
            NameOfStore =name;
            Leemons = 0;
            Ice = 0;
            Sugar = 0;
            Cups = 0;
            Money = 30m;
            price = 1;
            Popularity = 5;
            satisfactionPercent = 0;
            PricesatiSfactionPercent = 0;
            random = new Random();
            recipe = new Recipe();
            upgrades = new List<Upgrade>();
            sunny = true;
        }

        public void startDay() {        
            recipe = new Recipe(lastRecipeLeamons, lastRecipeIce, lastRecipeSugar,price,sunny);
            satisfactionPercent = recipe.calculateRecipe();
            PricesatiSfactionPercent = recipe.calculatePriceSatisfaction();
        }

        public int Rating() {

            if (random.Next(1, 10) <= PricesatiSfactionPercent) {
                return 0;
            }
            else if (random.Next(1, 10) >= satisfactionPercent)
            {
                return 1;
            }
            else {
                return 2;
            }
        }

       public void Upgrades() {
            foreach (Upgrade up in upgrades) {
                if (up.type == "Ice") {
                    Ice += 20;
                }
                else if (up.type == "Jukebox") {
                    Popularity += 1;
                }
                else if(up.type == "TV"){
                    Popularity += 1;
                    Money += 1.5m;
                }
            }
        }

        public int generatePopularityPeople() {
             people = 1;

            if (Popularity <= 3) Popularity = 3;

            for (int i = 0; i < lastRecipeCups; i++) {
                if (random.Next(10) <= Popularity) {
                    people++;
                }
                if (people > 10) people = 10;
            }

            if (lastRecipeCups < people) people = lastRecipeCups;
            return people;
        }

        public int OrderTotalLemons(int c)
        {
            return LEEMON_PACKAGE_AMOUNT * c;
        }

        public int OrderTotalSugar(int c)
        {
            return SUGAR_PACKAGE_AMOUNT * c;
        }

        public int OrderTotalIce(int c)
        {
            return ICE_PACKAGE_AMOUNT * c;
        }

        public int OrderTotalCups(int c)
        {
            return CUPS_PACKAGE_AMOUNT * c;
        }

        public bool enoughResurses() {
            if (lastRecipeLeamons * lastRecipeCups > Leemons) return false;
            if (lastRecipeSugar * lastRecipeCups > Sugar) return false;
            if (lastRecipeIce * lastRecipeCups > Ice) return false;

            return true;
        }

        public void removeSuplies() {
            Leemons -= lastRecipeLeamons * lastRecipeCups;
            if (Leemons < 0) Leemons = 0;

            Sugar -= lastRecipeSugar * lastRecipeCups;
            if (Sugar < 0) Sugar = 0;

            Ice -= lastRecipeIce * lastRecipeCups;
            if (Ice < 0) Ice = 0;

            Cups -= lastRecipeCups;
            if (Cups < 0) Cups = 0;
        }

        public override string ToString()
        {
            return String.Format("Store: {0} - {1}$", NameOfStore, Money);
        }
    }
}
