using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_08.Bl;
using Week_08.UI;

namespace Week_08
{
    class shapeDL
    {
        static List<shape> slist = new List<shape>();
        public static void adddataintolist(shape b)
        {
            slist.Add(b);
        }
        public static void displayall()
        {
            int count = 1;
            foreach(shape p in slist)
            {
                shapeUI.displaydatafromlist(p, count);
                count++;
            }
        }

    }
}
