using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LemonadeB_1.Properties;

namespace LemonadeB_1
{
    public class RandomNonBuyers
    {
        private Random random;
        public List<NonBuyer> nonbuyersList {get; set;}
        public Point[] startingP;
        public Point[] endingP;
        public Bitmap pic;

        public RandomNonBuyers(int N) {
            nonbuyersList = new List<NonBuyer>(N);
            random = new Random();
            createStarts();
            createEnds();
            pic = new Bitmap(Resources.face,30,30);
            generateList(N);
        }

        private void createStarts() {
            startingP = new Point[2];
            startingP[0] = new Point(350,150);
            startingP[1] = new Point(740,320);
        }

        private void createEnds()
        {
            endingP = new Point[2];
            endingP[0] = startingP[1];
            endingP[1] = startingP[0];
        }

        private void generateList(int n) {
            NonBuyer nb;
            int x;
            for (int i = 0; i < n; i++) {
                x = random.Next(2);
                nb = new NonBuyer(startingP[x],pic,endingP[x],x);
                nonbuyersList.Add(nb);
            } 

        }
    }
}
