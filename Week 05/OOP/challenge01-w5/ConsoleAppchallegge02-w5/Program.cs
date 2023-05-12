using ConsoleAppchallegge02_w5.BL;
using ConsoleAppchallegge02_w5.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppchallegge02_w5
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            MyLine line = null;
            while(option !=10)
            {
                option = MyLineCRUD.menu();
                if(option ==1)
                {
                    Console.Clear();
                    Mypoint Begin = MyLineCRUD.makealine();
                    Mypoint End = MyLineCRUD.Makealine2();
                    line = new MyLine(Begin, End);
                    
                }
                if (option == 2)
                {
                    Console.Clear();
                    line.sentbegin(MyLineCRUD.updateend());
                }
                if (option == 3)
                {
                    Console.Clear();
                    line.sentend(MyLineCRUD.updateend());   
                }
                if (option == 4)
                {
                    Console.Clear();
                    MyLineCRUD.displaystartpoint(line);
                }
                if (option == 5)
                {
                    Console.Clear();
                    MyLineCRUD.displayendpoint(line);
                }
                if (option == 6)
                {
                    Console.Clear();
                    MyLineCRUD.displaylenghth(line.getlength());
                }
                if (option == 7)
                {
                    Console.Clear();
                    MyLineCRUD.displaygradient(line.getgradient());
                }
                if (option == 8)
                {
                    Console.Clear();
                    MyLineCRUD.displaydistanceofbeginfromstart(line.getlengthforstartfromorigin());
                }
                if (option == 9)
                {
                    Console.Clear();
                    MyLineCRUD.displaydistanceofendfromstart(line.getlengthforendfromorign());
                }
                MyLineCRUD.clear();
            }
        }
    }
}
