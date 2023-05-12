using ConsoleAppchallegge02_w5.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppchallegge02_w5.UI
{
    class MyLineCRUD
    {
        public static int menu()
        {
            Console.WriteLine();
            Console.WriteLine(" 1. Make a Line");
            Console.WriteLine(" 2. Update the begin point");
            Console.WriteLine(" 3. Update the end point");
            Console.WriteLine(" 4. Show the begin point");
            Console.WriteLine(" 5. Show the end point");
            Console.WriteLine(" 6. Get the length of line");
            Console.WriteLine(" 7. Get gradient of line");
            Console.WriteLine(" 8. Find the distance of begin point from zero");
            Console.WriteLine(" 9. Find the distance of end point from zero");
            Console.WriteLine(" 10. Exit");
            Console.Write(" Enter your choice: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static Mypoint makealine()
        {
            Console.WriteLine();
            Console.WriteLine(" Point for Beginning of Line");
            Console.Write(" Enter x: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y1 = int.Parse(Console.ReadLine());
            Mypoint Begin = new Mypoint(x1, y1);
            return Begin;
        }
        public static Mypoint Makealine2()
        {
            Console.WriteLine();
            Console.WriteLine(" Point for End of Line");
            Console.Write(" Enter x: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y2 = int.Parse(Console.ReadLine());
            Mypoint End = new Mypoint(x2, y2);
            return End;
        }
        
        public static Mypoint updateend()
        {
            Console.WriteLine();
            Console.Write(" Enter new point for x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write(" Enter new point for y: ");
            int y = int.Parse(Console.ReadLine());
            Mypoint obj = new Mypoint(x, y);
            return obj;
        }
        public static void displaystartpoint(MyLine p)
        {
            Console.WriteLine();
            Console.WriteLine("   Start Points   ");
            Console.WriteLine(" x: " + p.begin.x);
            Console.WriteLine(" y: " + p.begin.y);
        }
        public static void clear()
        {
            Console.WriteLine(" Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void displayendpoint(MyLine p)
        {
            Console.WriteLine();
            Console.WriteLine("   End  Points   ");
            Console.WriteLine(" x: " + p.end.x);
            Console.WriteLine(" y: " + p.end.y);
        }
        public static void displaylenghth(double length)
        {
            Console.WriteLine();
            Console.WriteLine(" Length of line: " + length);
        }
        public static void displaygradient(double grad)
        {
            Console.WriteLine();
            Console.WriteLine(" Gradient of line: " + grad);
        }
        public static void displaydistanceofbeginfromstart(double length)
        {
            Console.WriteLine();
            Console.WriteLine(" Distance of beginning line from origin is : " + length);
        }
        public static void displaydistanceofendfromstart(double length)
        {
            Console.WriteLine();
            Console.WriteLine(" Distance of end line from origin is : " + length);
        }
    }
}
