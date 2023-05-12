using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_05_08_05_23_
{
    class data
    {
        public string name;
        public int rollno;
        public int ecatnumber;
        public data(string name, int rollo, int ecat)
        {
            this.name = name;
            this.rollno = rollo;
            this.ecatnumber = ecat;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //t1();
           // selfass1();
            //selfass02();
        }
        static void t1()
        {
            data s1 = new data("Ahmed", 15, 120);
            data s2 = new data("Ali", 11, 115);
            data s3 = new data("Bilal", 13, 125);
            List<data> studentdata = new List<data>() { s1, s2, s3 };
            List<data> sortedlist = studentdata.OrderBy(o => o.rollno).ToList();
            Console.WriteLine("Name \t Roll no \t EcatMarks");
            foreach (data u in sortedlist)
            {
                Console.WriteLine("{0} \t {1} \t {2}", u.name, u.rollno, u.ecatnumber);
            }
            Console.ReadKey();
        }
        static void selfass1()
        {
            List<float> fl = new List<float>() {2.25F, 4.5F, 8.90F, 1.5F};
            fl.Sort();
            foreach(float i in fl)
            {
                Console.WriteLine(i + "  " );
            }
            Console.ReadKey();

            List<string> li = new List<string>() { "Raamiz","Mubeen","Ali","Noman" };
            li.Sort();
            foreach (string i in li)
            {
                Console.Write(i + "  ");
            }
            Console.ReadKey();
        }
        static void selfass02()
        {
            data s1 = new data("Ahmed", 15, 120);
            data s2 = new data("Ali", 11, 115);
            data s3 = new data("Bilal", 13, 125);
            List<data> studentdata = new List<data>() { s1, s2, s3 };
            List<data> sortedlist = studentdata.OrderByDescending(o => o.rollno).ToList();
            Console.WriteLine("Name \t Roll no \t EcatMarks");
            foreach (data u in sortedlist)
            {
                Console.WriteLine("{0} \t {1} \t {2}", u.name, u.rollno, u.ecatnumber);
            }
            Console.ReadKey();
        }
        
    }
    
    
}
