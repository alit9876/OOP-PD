using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_03.BL;
using System.Threading;

namespace Week_03
{
    class Program
    {
        static void Main(string[] args)
        {

            //t1();
            //t2();
            //t3();
            //self1();
            //self2();
            //t4();
            //sel3();
            //sel4();
            //t5();
            //t6();
            //t6b();
            //t7();
            //t8();
            //t9();
        }

        static void t1()
        {
            Stident s1 = new Stident();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmark);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void t2()
        {
            Student s1 = new Student();
            Console.ReadLine();
        }
        static void t3()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.sname);
            Console.Read();
        }
        static void self1()
        {
            Student1 s1 = new Student1();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmark);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void self2()
        {
            Student1 s1 = new Student1();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmark);
            Console.WriteLine(s1.aggregate);

            Student1 s2 = new Student1();
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricmarks);
            Console.WriteLine(s2.fscmarks);
            Console.WriteLine(s2.ecatmark);
            Console.WriteLine(s2.aggregate);
            Console.ReadKey();
        }
        static void t4()
        {
            Student2 s1 = new Student2("John");
            Console.WriteLine(s1.sname);

            Student2 s2 = new Student2("Jill");
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
        static void sel3()
        {
            Student3 s1 = new Student3("John", 90F,1100F,315F,3.77F);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmark);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void sel4()
        {
            Student3 s1 = new Student3("John", 90F, 1100F, 315F, 3.77F);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmark);
            Console.WriteLine(s1.aggregate);


            Student3 s2 = new Student3("John", 90F, 1100F, 315F, 3.77F);
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricmarks);
            Console.WriteLine(s2.fscmarks);
            Console.WriteLine(s2.ecatmark);
            Console.WriteLine(s2.aggregate);
            Console.ReadKey();
        }
        static void t5()
        {
            student9 s1 = new student9();
            Console.WriteLine();
            s1.sname = "Ali";
            student9 s2 = new student9(s1);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
        static void t6()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for(int i=0; i <numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.ReadKey();
        }
        static void t6b()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(int i in numbers)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.ReadKey();
        }
        static void t7()
        {

            //              Default Constructor

            clockType emptyTime = new clockType();
            Console.Write("Empty Time");
            emptyTime.printTime();

            //              Parametric Constructor (Hour)

            clockType hour = new clockType(8);
            Console.Write("Hour TIme: ");
            hour.printTime();

            //              Parametric Constructor (Hour, Minute)

            clockType min = new clockType(8, 10);
            Console.Write("Minute TIme: ");
            min.printTime();

            //              Parametric Constructor (Hour, Minute, Second)

            clockType fullTime = new clockType(8, 10, 10);
            Console.Write("Full TIme: ");
            fullTime.printTime();

            //             Icrement Hours

            fullTime.incrementHour();
            Console.Write("Full Time (Increment Hours): ");
            fullTime.printTime();

            //             Icrement Seconds

            fullTime.incrementSecond();
            Console.Write("Full Time (Increment Seconds): ");
            fullTime.printTime();

            //             Icrement Seconds

            fullTime.incrementMinute();
            Console.Write("Full Time (Increment Minutes): ");
            fullTime.printTime();

            //             Check if Equal 

            bool flag = fullTime.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            //             Check if Equal 

            clockType cmp = new clockType(10, 12, 1);
            flag = fullTime.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);

            Console.ReadKey();
        }
        static void t9()
        {
            int choice = 8;

            List<Product> s1 = new List<Product>();

            while (choice != 0)
            {

                choice = menu();
                if (choice == 1)
                {
                    Console.Clear();
                    Product s = new Product();
                    Console.Write("ENter name of Product: ");
                    s.name = Console.ReadLine();
                    Console.Write("ENter category: ");
                    s.category = Console.ReadLine();
                    Console.Write("ENter Price: ");
                    s.price = float.Parse(Console.ReadLine());
                    Console.Write("ENter Quantity: ");
                    s.quantity = int.Parse(Console.ReadLine());
                    Console.Write("ENter Minmum: ");
                    s.minimum = int.Parse(Console.ReadLine());
                    s1.Add(s);

                }
                if (choice == 2)
                {
                    Console.Clear();
                    for(int x=0; x < s1.Count; x++)
                    {
                        s1[x].view();
                    }
                    Console.ReadKey();
                }
                if (choice == 3)
                {
                    Console.Clear();
                    Product s = new Product();
                    string highest = s.highestprice(s1);
                    Console.WriteLine("Product with Highest Unit Price: " + highest);
                    Console.ReadKey();
                }
                if (choice == 4)
                {
                    Console.Clear();
                    for (int x = 0; x < s1.Count; x++)
                    {
                        float tax = s1[x].caltaxes();
                        Console.WriteLine("  Product Name:  " + s1[x].name + "  Tax Price is:  " + tax);
                    }

                    Console.ReadKey();
                }
                if (choice == 5)
                {
                    Console.Clear();
                    for (int x = 0; x < s1.Count; x++)
                    {
                        string ordered = s1[x].ordered();
                        if (ordered != "")
                        {
                            Console.WriteLine("The product to be ordered are: " + ordered);
                        }

                    }
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
        static int menu()
        {
            Console.Clear();
            Console.WriteLine(" 1. Add Product ");
            Console.WriteLine(" 2. View All Product ");
            Console.WriteLine(" 3. Find Product with Highest Unit Price");
            Console.WriteLine(" 4. View sales tax of all Product ");
            Console.WriteLine(" 5. Products to be Orderd ");
            Console.WriteLine(" 0. Exit");
            int choice;
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void t8()
        {

            Console.Clear();
            clock s1 = new clock(22, 10, 10);
            s1.dif(22, 8, 8);
            s1.printTime();
            s1.printRTime();
            s1.printdClock(22, 8, 8);
            s1.printdTime();
            Console.ReadKey();
        }

    }
}
