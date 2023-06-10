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
        public static void listofloanholder(user s)
        {
            int loan = s.getterloans();
            string limitloan = s.getterlimitloans();
            string issuelaons = s.getterissueloans();
            Console.WriteLine(" " + s.gettername() + "\t" + loan + "\t" + issuelaons + "\t" + limitloan);
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
        public static void listofinsuranceholder(user s)
        {
            int insu = s.getterinsurances();
            int du = s.getterdurations();
            string installment = s.getterinstallments();
            if (insu != 0)
            {
                Console.WriteLine(" " + s.gettername() + "\t" + insu + "\t" + du + "\t" + installment);
            }
        }
        public static void elseins()
        {
            Console.WriteLine(" No Insurance has been provided!!! ");
        }
    }
}
