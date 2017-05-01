using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LemonadeB_1.Properties;

namespace LemonadeB_1
{
    public class RandomBuyer
    {
        private Random random;
        public List<Buyer> buyersList {get; set;}
        public Point[] startingP;
        public Point[] endingP;
        public Point storeP;
        public Bitmap pic;

        public RandomBuyer(int N)
        {
            buyersList = new List<Buyer>(N);
            random = new Random();
            storeP = new Point(610, 220);
            createStarts();
            createEnds();
            pic = new Bitmap(Resources.face,30,30);
            generateList(N);
        }

        private void createStarts() {
            startingP = new Point[2];
            startingP[0] = new Point(350, 320);
            startingP[1] = new Point(740, 320);
        }

        private void createEnds()
        {
            endingP = new Point[2];
            endingP[0] = startingP[1];
            endingP[1] = startingP[0];
        }

        private void generateList(int n) {
            Buyer nb;
            int x;
            for (int i = 0; i < n; i++) {
               // x = random.Next(2);
                x=0;
                nb = new Buyer(startingP[x],pic,endingP[x],x,storeP,2);
                buyersList.Add(nb);
            } 

        }
    }
}
