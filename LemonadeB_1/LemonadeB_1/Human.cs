using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LemonadeB_1
{
    public abstract class Human
    {
        public Point Position { get; set; }
        public Bitmap Picture { get; set; }
        public bool Buyer { get; set; }
        public int type { get; set; }
        public Point EndP { get; set; }
        public Point changeDir { get; set; }
        public bool Alive { get; set; }
        public readonly int moveSpeed=1;

        public Human(Point _Position, Bitmap _Picture, bool _Buyer, Point _EndP, int _type)
        {
            Position = _Position;
            Picture = _Picture;
            Buyer = _Buyer;
            EndP = _EndP;
            type = _type;
            Alive = true;
        }

        public abstract void Draw(Graphics g);
        public abstract void Move();
    }
}
