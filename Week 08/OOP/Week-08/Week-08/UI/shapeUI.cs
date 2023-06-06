using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_08.Bl;

namespace Week_08.UI
{
    class shapeUI
    {
       public static void displaydatafromlist(shape p, int count)
        {
            Console.WriteLine(count + "." + p.tostring());
        }
    }
    class rectangleUI
    {
        public static rectangleBL getinput()
        {
            Console.Write(" Enter length: ");
            double leng = double.Parse(Console.ReadLine());
            Console.Write(" Enter width: ");
            double w = double.Parse(Console.ReadLine());
            rectangleBL b = new rectangleBL(leng, w);
            return b;
        }


    }
    class squareUI
    {
        public static squareBL getinput()
        {
            Console.Write(" ENter side: ");
            int side = int.Parse(Console.ReadLine());
            squareBL b = new squareBL(side);
            return b;
        }
    }
    class circleUI
    {
        public static circleBL getinput()
        {
            Console.Write(" Enter circle radius: ");
            int r = int.Parse(Console.ReadLine());
            circleBL b = new circleBL(r);
            return b;
        }
    }

}
