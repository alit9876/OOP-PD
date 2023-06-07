using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_02.Bl;
using System.IO;


namespace week_02
{
    class Program
    {
        class student
        {
            public string name;
            public int rollno;
            public float cgpa;
        }

        static void Main(string[] args)
        {
            //t1();
            //t2();
            //t3();
            //t4();
            //t5();
            t6();
        }

        static void t1()
        {
            student s1 = new student();
            s1.name = "ALi";
            s1.rollno = 22;
            s1.cgpa = 3.88F;
            Console.Write("Name " + s1.name + " Roll no. " + s1.rollno + " CGPA: " + s1.cgpa);
            Console.ReadKey();
        }
        static void t2()
        {
            student s1 = new student();
            s1.name = "ALi";
            s1.rollno = 22;
            s1.cgpa = 3.88F;
            Console.WriteLine("Name " + s1.name + " Roll no. " + s1.rollno + " CGPA: " + s1.cgpa);
            student s2 = new student();
            s2.name = "Ahmed";
            s2.rollno = 21;
            s2.cgpa = 3.88F;
            Console.WriteLine("Name " + s2.name + " Roll no. " + s2.rollno + " CGPA: " + s2.cgpa);
            Console.ReadKey();
        }
    
        static void t3()
        {
            student s1 = new student();
            Console.Write(" ENter student name: ");
            s1.name = Console.ReadLine();
            Console.Write(" ENter student ROll number: ");
            s1.rollno = int.Parse(Console.ReadLine());
            Console.Write(" ENter student CGPA: ");           
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Name " + s1.name + " Roll no. " + s1.rollno + " CGPA: " + s1.cgpa);
            Console.ReadKey();
        }



        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine(" Press 1 for Adding a new student");
            Console.WriteLine(" Press 2 for view Student");
            Console.WriteLine(" Press 3 for top three student");
            Console.WriteLine(" Press 4 to Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Students addStudent()
        {
            Console.Clear();
            Students s1 = new Students();
            Console.WriteLine();
            Console.Write("ENter name: " );
            s1.name = Console.ReadLine();
            Console.Write("ENter Roll number: ");
            s1.rollno = int.Parse(Console.ReadLine());
            Console.Write(" ENter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Write(" Enter Department: ");
            s1.department = Console.ReadLine();
            Console.Write(" Is Hostelide ( y || n): ");
            s1.ishostelide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void viewstudent(Students[] s, int count)
        {
            Console.Clear();
            for(int x =0; x < count; x++)
            {
                Console.WriteLine("Name: " + s[x].name + " Roll no: " + s[x].rollno + " CGPA: " + s[x].cgpa + " Department: " + s[x].department + " Hostelide: " + s[x].ishostelide );
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        static void topstudent(Students[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if(count == 1)
            {
                viewstudent(s, 1);
            }
            else if(count == 2)
            {
                for(int x =0; x < count; x++)
                {
                    int index = largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewstudent(s, 2);
            }
            else
            {
                for(int x =0; x<3; x++)
                {
                    int index = largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewstudent(s, 3);
            }
        }
        static int largest(Students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x =start; x< end; x++)
            {
                if(large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void t4()
        {
            Students[] s = new Students[10];
            char option;
            int count = 0;
            do
            {
                Console.Clear();
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewstudent(s, count);
                }
                else if (option == '3')
                {
                    topstudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press any key to Exit....");
            Console.Read();
        }



        static char menu1()
        {
            char choice;
            Console.WriteLine();
            Console.WriteLine(" 1. Add Products");
            Console.WriteLine(" 2. Show Products");
            Console.WriteLine(" 3. Total Store Worth");
            Console.WriteLine(" 4. Exit ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Products addProduct()
        {
            Console.Clear();
            Products s1 = new Products();
            Console.WriteLine();
            Console.Write(" ENter name: ");
            s1.name = Console.ReadLine();
            Console.Write(" ENter Product ID: ");
            s1.ID = int.Parse(Console.ReadLine());
            Console.Write(" ENter Product Price: ");
            s1.price = float.Parse(Console.ReadLine());
            Console.Write(" Enter Categories: ");
            s1.categories = char.Parse(Console.ReadLine());
            Console.Write(" Enter Brand Name:  ");
            s1.brand = (Console.ReadLine());
            Console.Write(" Enter Country Name:  ");
            s1.country = (Console.ReadLine());
            return s1;
        }
        static void viewproduct(Products[] s, int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("ID: " +s[x].ID + " NAme: " + s[x].name + " Price: " + s[x].price + " Category: " + s[x].categories + " Brand Name: " + s[x].brand + " COuntry: " + s[x].country );
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        static void totalprice(Products[] s, int count)
        {
            float total = 0;
            for(int x =0; x < count; x++)
            {
                total = total + s[x].price;
            }
            Console.WriteLine( " Total Price: " + total);
            Console.ReadKey(); 
        }
        static void t5()
        {
            Products[] s = new Products[10];
            char option;
            int count = 0;
            do
            {
                Console.Clear();
                option = menu1();
                if (option == '1')
                {
                    s[count] = addProduct();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewproduct(s, count);
                }
                else if (option == '3')
                {
                    totalprice(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press any key to Exit....");
            Console.Read();
        }




        //   sign in & sign up menu
        //   D:\\record.txt

        public static int menu3()
        {
            int option;
            Console.WriteLine(" 1 Sign In ");
            Console.WriteLine(" 2 Sign Up ");
            Console.WriteLine(" Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void readdata(string path, Signup[] s)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    s[x].username = parseData(record, 1);
                    s[x].password = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                filevariable.Close();
            }
            else
            {
                Console.WriteLine(" Not Exists");
            }
        }
        public static void signin(string n, string p, Signup[] s)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == s[x].username && p == s[x].password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        public static void signup(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        public static void t6()
        {
            string path = "D:\\record.txt";
            Signup[] s = new Signup[5];
           for(int x =0; x < 5; x++)
            {
                s[x] = new Signup();
            }
           
            int option;
            do
            {
                readdata(path,s);
                Console.Clear();
                option = menu3();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine(" Enter name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine(" ENter password: ");
                    string p = Console.ReadLine();
                    signin(n, p,s);
                }
                else if (option == 2)
                {
                    Console.WriteLine(" ENter new names: ");
                    String n = Console.ReadLine();
                    Console.WriteLine("Enter New password: ");
                    string p = Console.ReadLine();
                    signup(path, n, p);
                }
            }
            while (option < 3);
            Console.Read();
        }
    }
}
