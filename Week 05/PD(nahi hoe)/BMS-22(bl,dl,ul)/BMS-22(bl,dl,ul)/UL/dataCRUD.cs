using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_bl_dl_ul_.BL;

namespace BMS_22_bl_dl_ul_.UL
{
    class dataCRUD
    {
        public static data takeinputforsignin()
        {
            string name;
            string password;
            Console.Write(" Enter name: ");
            name = Console.ReadLine();
            Console.Write(" Enter password: ");
            password = Console.ReadLine();
            data obj = new data(name, password);
            return obj;
        }
        public static data takeinputforsignup()
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
            data obj = new data(name, password, type, balance);
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
        public static void headeradminop1()
        {
            Console.WriteLine(" Type" + "\t" + "Account No" + "\t" + " Name" + "\t" + "Password" + "\t" + "  Balance" + "\t" + " Status");
        }
        public static void masterlist(data s)
        {
            Console.WriteLine();
            Console.WriteLine(" " + s.types + "\t" + s.accountnumbers + "\t " + "\t" + s.names + "\t" + s.passwords + "\t" + s.balances + "\t" + s.fdata.status);
        }
        public static string getinputforop2()
        {
            string name;
            int position;
            Console.Write(" Enter User name: ");
            name = Console.ReadLine();
            return name;
        }
        public static void accountholderdetail(data s)
        {
            
            Console.WriteLine("    Acount holder's Details");
            Console.WriteLine();
            Console.WriteLine(" Account Number: " + s.accountnumbers);
            Console.WriteLine(" Account holder Name: " + s.names);
            Console.WriteLine(" Account holder's Password: " + s.passwords);
            Console.WriteLine(" Account holder Type: " + s.types);
            Console.WriteLine(" Current Balance: " + s.balances);
            Console.WriteLine(" Account holder Pending loan: " + s.ldata.loans);
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
        public static data editbothadmin()
        {
            Console.Write(" Enter New Name: ");
            string newname = Console.ReadLine();
            Console.Write(" Enter New Password: ");
            string newpassword = Console.ReadLine();
            data obj = new data(newname, newpassword);
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
        public static data inputpasswordfordelete()
        {
            Console.Write(" Enter account holder's name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter account holder's password: ");
            string userpassword = Console.ReadLine();
            data obj = new data(name, userpassword);
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
        public static void seeallcomplains(data s, int index)
        {
            if (s.complains != "No Complain")
            {
                Console.WriteLine(" " + "User " + index + ". " + s.complains);
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
