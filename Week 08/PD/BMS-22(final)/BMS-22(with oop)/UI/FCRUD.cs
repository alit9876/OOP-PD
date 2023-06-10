using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;
using BMS_22_with_oop_.BL;

namespace BMS_22_with_oop_.UI
{
    class FCRUD
    {
        public static user inputforop3()
        {
            Console.Write(" Enter Account holder's name to be freeze: ");
            string name = Console.ReadLine();
            Console.Write(" Enter Account holder's password: ");
            string password = Console.ReadLine();
            user obj = new user(name, password);
            return obj;
        }
        public static int freezedur()
        {
            int duration;
            Console.Write(" Enter duration of freeze account (in days): ");
            duration = int.Parse(Console.ReadLine());
            return duration;
        }
        public static void freezedisplay(int value)
        {
            Console.WriteLine();
            Console.WriteLine(" The user account has been freezed for " + value + " days");
            Console.WriteLine();
            Console.WriteLine(" Account list Updated. . .");
        }
        public static customer unfreezeinput()
        {
            string name;
            int accountnumber;
            Console.Write(" Enter account number of the account you want to UnFreeze:");
            accountnumber = int.Parse(Console.ReadLine());
            Console.Write(" Enter account name you want to UnFreeze: ");
            name = Console.ReadLine();
            customer obj = new customer(name, accountnumber);
            return obj;
        }
        public static void succesfulunfreeze()
        {
            Console.WriteLine();
            Console.WriteLine(" The given account has been unfreezed successfully!");
            Console.WriteLine(" Account list Updated. . .");
        }
        public static void incorrect()
        {
            Console.WriteLine();
            Console.WriteLine(" Incorrect password! Try again");
        }
    }
}
