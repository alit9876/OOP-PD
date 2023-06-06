using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_08.Bl;
using Week_08.UI;



namespace Week_08.Dl
{
    class persondl
    {
        static List<person> pss = new List<person>();
          public static void adddataintolist(person b)
        {
            pss.Add(b);
        }
        public static void displaydata()
        {
            foreach (person p in pss)
            {
                string n = p.tostring();
                Console.WriteLine(n);
            }
        }
    }
}
