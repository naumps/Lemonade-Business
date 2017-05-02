using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LemonadeB_1
{
    public class NonBuyer : Human
    {
        public NonBuyer(Point _Position, Bitmap _Picture, Point _EndP, int _type)
            : base(_Position, _Picture, false, _EndP,_type)
        {
            type = _type;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (Alive)
                g.DrawImage(Picture, Position);  
        }

        public override void Move()
        {
            if (Alive)
            {
                switch (type)
                {
                    case 0:
                        Position = new Point(Position.X + moveSpeed, Position.Y);
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