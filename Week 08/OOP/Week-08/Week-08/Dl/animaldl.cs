using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_08.Bl;
using Week_08.UI;


namespace Week_08.Dl
{
    class animaldl
    {
        static List<animal> sanimal = new List<animal>();
        public static void adddataintolist(animal p)
        {
            sanimal.Add(p);
        }
        public static void displayall()
        {
            foreach (animal p in sanimal )
            {
                string n = p.tostring();
                Console.WriteLine(n);
                p.greets();
                Console.WriteLine();
            }
           
        }
    }

}
