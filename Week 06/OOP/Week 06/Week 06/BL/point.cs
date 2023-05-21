using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06.BL
{
    class point
    {
        public int x;
        public int y;
        public point()
        {

        }
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Boundary
    {
        public point topleft;
        public point topright;
        public point bottomleft;
        public point bottomright;
        public Boundary()
        {
            this.bottomleft.setXY(90, 0);
            this.bottomright.setXY(90, 90);
            this.topleft.setXY(0, 0);
            this.topright.setXY(0, 90);
        }
        public Boundary(point bottomleft, point bottomright, point topleft, point topright)
        {
            this.topleft = topleft;
            this.topright = topright;
            this.bottomleft = bottomleft;
            this.bottomright = bottomright;

        }
    }
}
