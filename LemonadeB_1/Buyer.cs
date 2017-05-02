using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace LemonadeB_1
{
    public class Buyer : Human
    {
        public bool Wait { get; set; }
        public int waitInterval { get; set; }
        public Point storePoint { get; set; }
        private int lastListIndex { get; set; }
        private int PathY;
        private int walkNextP;
        private bool ready;

        public Buyer(Point _Position, Bitmap _Picture, Point _EndP, int _type, Point _storePoint,int _waitInterval)
            : base(_Position, _Picture, true, _EndP,_type)
        {
            Wait = false;
            storePoint = _storePoint;
            lastListIndex = -1;
            waitInterval = _waitInterval;
            PathY = _Position.Y;
            walkNextP = 30;
            ready = false;
        }


        public override void Draw(System.Drawing.Graphics g)
        {
            if (Alive){ 
                g.DrawImage(Picture, Position);                 
            }
        }

        public void waitingToBuy() {
            if (Wait && lastListIndex == 0)
            {
                if (waitInterval == 0)
                {
                    Wait = false;
                    ready = false;
                    Position = new Point(Position.X , PathY + moveSpeed);
                    BuyersWaitList.buyersList.Remove(this);
                }
                else
                {
                    waitInterval--;
                }
            }
        }

        public override void Move()
        {
            if (Alive)
            {
               
                switch (type)
                {
                    case 0:                      
                        if (!Wait)
                        {
                            Position = new Point(Position.X + moveSpeed, Position.Y);

                            if (Position.X == storePoint.X) {
                                Wait = true;
                                lastListIndex = BuyersWaitList.buyersList.Count;
                                Position = new Point(Position.X, storePoint.Y + lastListIndex * Picture.Height);
                                BuyersWaitList.buyersList.Add(this);
                                
                            }
                        }
                        else {
                            if (ready)
                            {
                                if (walkNextP > 0)
                                {
                                    Position = new Point(Position.X, Position.Y - 1);
                                    walkNextP--;
                                }
                            }
                            int index = BuyersWaitList.buyersList.IndexOf(this);
                            if (index != lastListIndex && index != -1)
                            {
                                Position = new Point(Position.X, Position.Y);
                                lastListIndex = index--;
                                ready = true;
                                walkNextP = 30;
                            }
                            
                        }

                        break;
                    case 1:
                        Position = new Point(Position.X - moveSpeed, Position.Y);
                        break;
                }

                if (Position.X == EndP.X)
                {
                    Alive = false;
                }
            }       
        }
    }
}
