using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LemonadeB_1
{
    public class Scene
    {
        private List<NonBuyer> nonbuyers;
        public List<NonBuyer> nonbuyersNow{get;set;}
        private List<Buyer> buyers;
        public List<Buyer> buyersNow { get; set; }
        private int counter;
        private int counter2;
        private Random random;

        public Scene() {

            nonbuyers = new List<NonBuyer>();
            nonbuyersNow = new List<NonBuyer>();
            buyers = new List<Buyer>();
            buyersNow = new List<Buyer>();
            random = new Random();
        }

        public void addNonByers(int n) {
            RandomNonBuyers randomNB = new RandomNonBuyers(n);
            nonbuyers = randomNB.nonbuyersList;
            counter = nonbuyers.Count;
        }

        public void addNewNonByer() {
            if (counter-->0)
            nonbuyersNow.Add(nonbuyers[counter]);
        }

        public void addByers(int n)
        {
            RandomBuyer randomB = new RandomBuyer(n);
            buyers = randomB.buyersList;
            counter2 = buyers.Count;
        }

        public void addNewByer()
        {
            if (counter2-- > 0)
                buyersNow.Add(buyers[counter2]);
        }

        public void DrawNonByers(Graphics g) {
            foreach (NonBuyer nb in nonbuyersNow)
            {
                nb.Draw(g);
            }
        }

        public void DrawByers(Graphics g)
        {
            foreach (Buyer nb in buyersNow)
            {
                nb.Draw(g);
            }
        }

    }
}
