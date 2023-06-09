using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22final.BL;
using BMS_22final.DL;

namespace BMS_22final.UI
{
    class userCRUD
    {
        public static user takeinputforsignin()
        {
            string name;
            string password;
            Console.Write(" Enter name: ");
            name = Console.ReadLine();
            Console.Write(" Enter password: ");
            password = Console.ReadLine();
            user obj = new user(name, password);
            return obj;
        }
        public static datac takeinputforsignup()
        {
            string name;
            string password;
            string type;
            int balance;
            Console.Write(" Enter type of account ('S' for saving & 'C' for current): ");
            type = Console.ReadLine();
            Console.Write(" Enter  account holder name: ");
            name = Console.ReadLine();
            Console.Write(" Enter password (minmum length: 5): ");
            password = Console.ReadLine();
            Console.Write(" Enter initial Amount : ");
            balance = int.Parse(Console.ReadLine());
            datac obj = new datac(name, password, type, balance);
            return obj;
        }
        public static admin takeinputforsigupadmin()
        {
            string name;
            string password;
            Console.Write(" Enter  account holder name: ");
            name = Console.ReadLine();
            Console.Write(" Enter password (minmum length: 5): ");
            password = Console.ReadLine();
            admin obj = new admin(name,password);
            return obj;
        }
        public static void alreadyexit()
        {
            Console.WriteLine();
            Console.WriteLine(" Already Existed! Try again ");
        }
        public static void passwordshot()
        {
            Console.WriteLine();
            Console.WriteLine(" Password is too short!! Try again");
        }
        public static void nameingerror()
        {
            Console.WriteLine();
            Console.WriteLine(" Name consist of aplahabets only");
        }
        public static void invalid()
        {
            Console.WriteLine(" Invalid choice.");
            Console.ReadKey();
        }
        public static void notfound()
        {
            Console.WriteLine();
            Console.WriteLine(" Account has not found! Try again");
            menuCRUD.clear();
        }
        public static void presscontinue()
        {
            Console.WriteLine();
            Console.WriteLine(" Press any Key to Continue");
            Console.ReadKey();
        }
        public static void freezeacount()
        {
            Console.WriteLine();
            Console.WriteLine(" Your account has been Freezed! ");
            menuCRUD.clear();
        }
        public static void noaccountfound()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid User !! SignUp first....");
            menuCRUD.clear();
        }
    }
}
