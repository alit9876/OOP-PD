using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_08.Bl;
using Week_08.UI;
using Week_08.Dl;

namespace Week_08
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // t1();
            //t2();
            //t3();
            //t4();
        }
        static void t1()
        {
            cylinder c1 = new cylinder();
            cylinder c2 = new cylinder(3,5,"blue");
            cylinder c3 = new cylinder(2);
            c3.setheight(7);
            double vol = c3.getvolume();
            Console.WriteLine(vol);
            Console.ReadKey();
        }
        static void t2()
        {
            Student s1 = new Student("Ali", "XX", "BSC", 4, 2000);
            Student s2 = new Student("Ahmed", "ABC", "BSCE", 4, 2000);
            Staff st1 = new Staff("Ali" , "XX", "QGS", 24500);
            Staff st2 = new Staff("Ali2", "ABC", "QGS", 24590);
            persondl.adddataintolist(s1);
            persondl.adddataintolist(s2);
            persondl.adddataintolist(st1);
            persondl.adddataintolist(st2);
            persondl.displaydata();
            Console.ReadKey();
        }
        static void t3()
        {
            cat c1 = new cat("cat", "lion", "cato");
            cat c2 = new cat("cat", "lion", "liza");
            dog d1 = new dog("dog", "lion", "Tommy");
            dog d2 = new dog("dog", "lion", "Rocky");
            animaldl.adddataintolist(c1);
            animaldl.adddataintolist(c2);
            animaldl.adddataintolist(d1);
            animaldl.adddataintolist(d2);
            animaldl.displayall();
            d1.greets(d2);
            Console.ReadKey();
        }
        static void t4()
        {
            rectangleBL rect = rectangleUI.getinput();
            circleBL circle = circleUI.getinput();
            squareBL sq = squareUI.getinput();
            rectangleBL r2 = rectangleUI.getinput();
            circleBL circle2 = circleUI.getinput();
            shapeDL.adddataintolist(rect);
            shapeDL.adddataintolist(circle);
            shapeDL.adddataintolist(sq);
            shapeDL.adddataintolist(r2);
            shapeDL.adddataintolist(circle2);
            shapeDL.displayall();
            Console.ReadKey();
        }
    }
}
