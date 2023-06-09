using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BMS_22final.DL;

namespace BMS_22final.UI
{
    class menuCRUD
    {
        public static string loginmenu()
        {
            string option;
            Console.WriteLine(" 1. Sign In");
            Console.WriteLine(" 2. Sign Up");
            Console.WriteLine(" 3. Exist ");
            Console.WriteLine();
            Console.WriteLine(" Enter any option (1-3): ");
            option = Console.ReadLine();
            return option;
        }
        public static void header()
        {
            Console.WriteLine(List1.listcount());
            Console.WriteLine();
            Console.WriteLine(" .---.              .-.     .-..-.                                                      .-.    .--.             .-.              ");
            Console.WriteLine(" : .; :             : :.-.  : `' :                                                     .' `.  : .--'           .' `.              ");
            Console.WriteLine(" :   .' .--.  ,-.,-.: `'.'  : .. : .--.  ,-.,-. .--.   .--.  .--. ,-.,-.,-. .--. ,-.,-.`. .'  `. `. .-..-. .--.`. .'.--. ,-.,-.,-");
            Console.WriteLine(" : .; :' .; ; : ,. :: . `.  : :; :' .; ; : ,. :' .; ; ' .; :' '_.': ,. ,. :' '_.': ,. : : :    _`, :: :; :`._-.': :' '_.': ,. ,. :");
            Console.WriteLine(" :___.'`.__,_;:_;:_;:_;:_;  :_;:_;`.__,_;:_;:_;`.__,_;`._. ;`.__.':_;:_;:_;`.__.':_;:_; :_;   `.__.'`._. ;`.__.':_;`.__.':_;:_;:_;");
            Console.WriteLine("                                                       .-. :                                         .-. :                        ");
            Console.WriteLine("                                                       `._.'                                         `._.'                        ");
        }
        public static void innermenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" Main Menu  > " + menu);
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine();
        }
        public static void loading()
        {
            Console.WriteLine();
            Console.Write(" Your ID Is Creating, Please Wait ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("-");
                Thread.Sleep(150);
            }
            Console.WriteLine();
        }
        public static void submenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" {0}  Menu", menu);
            Console.WriteLine(" --------------------");
            Console.WriteLine();
        }
        public static string admin()
        {
            string option;
            Console.WriteLine(" 1.  Account holder masterlist ");
            Console.WriteLine(" 2.  Search for specific account ");
            Console.WriteLine(" 3.  Freeze user account ");
            Console.WriteLine(" 4.  Edit/Change my account ");
            Console.WriteLine(" 5.  Check Bank's Available Balance ");
            Console.WriteLine(" 6.  Give loan to user");
            Console.WriteLine(" 7.  loan holder's details ");
            Console.WriteLine(" 8.  Insurance holder's Details");
            Console.WriteLine(" 9.  Provide funding ");
            Console.WriteLine(" 10. UnFreeze user's account ");
            Console.WriteLine(" 11. Delete user account ");
            Console.WriteLine(" 12. See all complains ");
            Console.WriteLine(" 0.  Exist");
            Console.WriteLine();
            Console.Write("  Select option (0-12): ");
            option = (Console.ReadLine());
            return option;
        }
        public static string user()
        {
            string option;
            Console.WriteLine("  1.  Create an account ");
            Console.WriteLine("  2.  Deposit Money ");
            Console.WriteLine("  3.  With Draw Money");
            Console.WriteLine("  4.  Balance Inquiry");
            Console.WriteLine("  5.  Edit/ Change my account: ");
            Console.WriteLine("  6.  Transfer Money to other account");
            Console.WriteLine("  7.  Apply for loan         ");
            Console.WriteLine("  8.  Apply for Insurance ");
            Console.WriteLine("  9.  Payable ");
            Console.WriteLine("  10. Account holder details");
            Console.WriteLine("  11. Return loan");
            Console.WriteLine("  12. Complain");
            Console.WriteLine("  13. Delete my account ");
            Console.WriteLine("  0.  Exist ");
            Console.WriteLine();
            Console.Write(" Select option (0-13):");
            option = (Console.ReadLine());
            return option;
        }
        public static void clear()
        {

            Console.WriteLine();
            Console.Write(" Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }
        public static void printheading(string argumnet)
        {

            Console.Clear();
            header();
            innermenu(argumnet);
        }
        public static string changeadminoption()
        {
            string option;
            Console.WriteLine("  1. Change Name");
            Console.WriteLine("  2. Change password ");
            Console.WriteLine("  3. Change both ");
            Console.WriteLine();
            Console.WriteLine(" Enter your choice: ");
            option = (Console.ReadLine());
            return option;
        }
        public static string optiontochanheuser()
        {
            string option;
            Console.WriteLine(" 1. Change Name");
            Console.WriteLine(" 2. Change password ");
            Console.WriteLine(" 3. Change account type  ");
            Console.WriteLine(" 4. Change all");
            Console.WriteLine();
            Console.Write(" Enter your choice(1-4): ");
            option = (Console.ReadLine());
            return option;
        }
        public static string complianmenu()
        {
            string option;
            Console.WriteLine(" 1. Submit a Complian");
            Console.WriteLine(" 2. Remove the Complain");
            Console.WriteLine();
            Console.Write(" Enter your choice:");
            option = (Console.ReadLine());
            return option;
        }
    }
}
