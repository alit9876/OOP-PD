using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppchallegge02_w5.BL
{
    class MyLine
    {
        public Mypoint begin = new Mypoint();
        public Mypoint end = new Mypoint();
        public MyLine(Mypoint Begin, Mypoint End)
        {
            this.begin = Begin;
            this.end = End;
        }
        public Mypoint getbegin()
        {
            return begin;
        }
        public Mypoint getend()
        {
            return end;
        }
        public   void sentbegin(Mypoint begin1)
        {
            begin = begin1;
        }
        public void sentend(Mypoint end)
        {
            this.end = end;
        }
        public double getlength()
        {
            double length = 0;
            length = Math.Pow((end.x - begin.x), 2) + Math.Pow((end.y - begin.y), 2);
            length = Math.Sqrt(length);
            return length;
        }
        public double getgradient()
        {
            double grad = 0;
            double ugrad = (end.y - begin.y) ;
            double dgrad = (end.x - begin.x);
            grad = ugrad / dgrad;
            return grad;
        }
        public double getlengthforstartfromorigin()
        {
            double length = 0;
            length = Math.Pow((begin.x - 0), 2) + Math.Pow((begin.y -0), 2);
            length = Math.Sqrt(length);
            return length;
        }
        public double getlengthforendfromorign()
        {
            double length = 0;
            length = Math.Pow((end.x- 0), 2) + Math.Pow((end.y-0), 2);
            length = Math.Sqrt(length);
            return length;
        }
    }
    class Mypoint
    {
        public int x;
        public int y;
        public Mypoint()
        {

        }
        public Mypoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
