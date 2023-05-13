using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS_22_bl_dl_ul_.BL;
using System.Threading.Tasks;

namespace BMS_22_bl_dl_ul_.UL
{
    class lCRUD
    {
        public static string nameforloanadmin()
        {
            Console.Write(" Enter User's name whom you want to give loan: ");
            string name = Console.ReadLine();
            return name;
        }
        public static loan givingloan()
        {
            Console.Write(" Reason for loan: ");
            string reason = Console.ReadLine();
            Console.Write(" Enter amount of loan: ");
            int amount = int.Parse(Console.ReadLine());
            Console.Write(" Enter date of Giving loan: ");
            string issue = Console.ReadLine();
            Console.Write(" Enter date of returning loan: ");
            string limit = Console.ReadLine();
            loan obj = new loan(amount, issue, limit);
            return obj;
        }
        public static void givingloanadmin(int amount)
        {
            Console.WriteLine();
            Console.WriteLine("The user is given loan and his account current balance is " + amount);
            Console.WriteLine();
            Console.WriteLine(" Account list Updated. . .");
        }
        public static void hesderforloandetails()
        {
            menuCRUD.printheading(" Loan Holder's Details");
            Console.WriteLine();
            Console.WriteLine(" List of all loan holder's account");
            Console.WriteLine();
            Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "IssueDate" + "\t" + "ReturningDate");
            Console.WriteLine();
        }
        public static void listofloanholder(data s)
        {
            int loan = s.ldata.loans;
            string limitloan = s.ldata.limitloans;
            string issuelaons = s.ldata.issueloans;
            Console.WriteLine(" " + s.names + "\t" + loan + "\t" + issuelaons + "\t" + limitloan);
        }
        public static void notpayyed()
        {
            Console.WriteLine(" No loan has been payyed!!! ");
        }
        public static void headerinsurance()
        {
            menuCRUD.printheading(" Insurance holder's Details");
            Console.WriteLine(" List of all Insurance holder's account");
            Console.WriteLine();
            
        }
        public static void insurancedisplay()
        {
            Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "Duration (In Year)" + "\t" + "Installments ");
            Console.WriteLine();
        }
        public static void listofinsuranceholder(data s)
        {
            int insu = s.Idata.insurances;
            int du = s.Idata.durations;
            string installment = s.Idata.installments;
            if (insu != 0)
            {
                Console.WriteLine(" " + s.names + "\t" + insu + "\t" + du + "\t" + installment);
            }
        }
        public static void elseins()
        {
            Console.WriteLine(" No Insurance has been provided!!! ");
        }
    }
}
