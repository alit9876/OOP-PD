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
    class adminCRUD
    {
        public static void headeradminop1()
        {
            Console.WriteLine(" Type" + "\t" + "Account No" + "\t" + " Name" + "\t" + "Password" + "\t" + "  Balance" + "\t" + " Status");
        }
        public static void masterlist(user s)
        {
            Console.WriteLine();
            Console.WriteLine(" " + s.gettertypes() + "\t" + s.getteraccountnumbers() + "\t " + "\t" + s.gettername() + "\t" + s.getterpassword() + "\t" + s.getterbalances() + "\t" + s.getterstattus());
        }
        public static string getinputforop2()
        {
            string name;
            int position;
            Console.Write(" Enter User name: ");
            name = Console.ReadLine();
            return name;
        }
        public static void accountholderdetail(user s)
        {

            Console.WriteLine("    Acount holder's Details");
            Console.WriteLine();
            Console.WriteLine(" Account Number: " + s.getteraccountnumbers());
            Console.WriteLine(" Account holder Name: " + s.gettername());
            Console.WriteLine(" Account holder's Password: " + s.getterpassword());
            Console.WriteLine(" Account holder Type: " + s.gettertypes());
            Console.WriteLine(" Current Balance: " + s.getterbalances());
            Console.WriteLine(" Account holder Pending loan: " + s.getterloans());
        }
        public static void notfound2()
        {
            Console.WriteLine();
            Console.WriteLine(" Account has not found");
        }
        public static string passowrd()
        {
            string password;
            Console.Write(" Enter your Account password: ");
            password = Console.ReadLine();
            return password;
        }
        public static string newnameadmin()
        {
            Console.Write(" Enter New Name: ");
            string newname = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Account has been Updated. .  .");
            return newname;
        }
        public static string newpasswordadmin()
        {
            Console.Write(" Enter New Password: ");
            string newpassword = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Account has been Updated. .  .");
            return newpassword;
        }
        public static user editbothadmin()
        {
            Console.Write(" Enter New Name: ");
            string newname = Console.ReadLine();
            Console.Write(" Enter New Password: ");
            string newpassword = Console.ReadLine();
            user obj = new user(newname, newpassword);
            return obj;
        }
        public static void updatedadmin()
        {
            Console.WriteLine();
            Console.WriteLine(" Account has been Updated. .  .");
        }
        public static void incorrentcredi()
        {
            Console.WriteLine();
            Console.WriteLine(" Incorrect Crediential! Try again. ");
        }
        public static void bankbalanceavailable(ref int bankbalance)
        {
            Console.WriteLine(" Current amount available in bank: " + bankbalance);
        }
        public static int inputforfunds()
        {
            menuCRUD.printheading(" Provide Funding");
            Console.Write(" Enter insitution name: ");
            string inistitution = Console.ReadLine();
            Console.Write(" Enter amount for fund: ");
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }
        public static void successfullyfunds()
        {
            Console.WriteLine();
            Console.WriteLine(" Funds has been successfully transfered.");
            Console.WriteLine(" Updating Account list. . .");
        }
        public static void notprovidefund()
        {
            Console.WriteLine();
            Console.WriteLine("Insufficicent Balance!!!");
        }
        public static string inputpassword()
        {
            Console.Write(" Enter your account password: ");
            string password = Console.ReadLine();
            return password;
        }
        public static user inputpasswordfordelete()
        {
            Console.Write(" Enter account holder's name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter account holder's password: ");
            string userpassword = Console.ReadLine();
            user obj = new user(name, userpassword);
            return obj;
        }
        public static void successfullydelete(int balance)
        {
            Console.WriteLine();
            Console.WriteLine(" The user's account has been deleted and his closing balance is:" + balance);
            Console.WriteLine();
            Console.WriteLine(" Account list has been Updated. . .");
        }
        public static void deleteincorect()
        {
            menuCRUD.printheading(" Delete Account");
            Console.WriteLine();
            Console.WriteLine(" Incorrect Credientials!!");
        }
        public static void headercomplains()
        {
            Console.WriteLine(" Here the list of all complains");
            Console.WriteLine();
        }
        public static void seeallcomplains(user s, int index)
        {
            if (s.gettercomplains() != "No Complain")
            {
                Console.WriteLine(" " + "User " + index + ". " + s.gettercomplains());
            }

        }
        public static void notcomplainreg()
        {
            menuCRUD.printheading(" See all Complains");
            Console.WriteLine();
            Console.WriteLine(" No Complain has been registered.");
        }
        public static void invalidchoice()
        {
            Console.Write(" Invalid Choice");
            Console.WriteLine();
        }
    }
}
