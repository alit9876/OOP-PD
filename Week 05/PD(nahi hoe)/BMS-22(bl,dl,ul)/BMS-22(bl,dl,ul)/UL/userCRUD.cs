using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_bl_dl_ul_.BL;

namespace BMS_22_bl_dl_ul_.UL
{
    class userCRUD
    {
        public static int accountnumberinput()
        {
            int accountnumber;
            Console.Write(" Enter your account number: ");
            accountnumber = int.Parse(Console.ReadLine());
            return accountnumber;
        }
        public static int depositinputamount(int balances)
        {
            int deposit;
            Console.WriteLine(" Currnet Balance " + balances);
            Console.Write(" Enter amount to deposit: ");
            deposit = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Balance Updated. . .");
            return deposit;
        }
        public static int inputforwithdranw(int balances)
        {
            Console.Write(" Current Balance: " + balances);
            int withdrew;
            Console.WriteLine();
            Console.Write(" Enter amount to with draw : ");
            withdrew = int.Parse(Console.ReadLine());
            return withdrew;
        }
        public static void successfullywithdrew()
        {
            Console.WriteLine();
            Console.WriteLine(" Balances Updated. . .");
        }
        public static void insufficientbal()
        {
            Console.WriteLine();
            Console.WriteLine(" Insufficient balance!!!");

        }
        public static void balanceinquiry(data s)
        {
            Console.WriteLine(" Account number: " + s.accountnumbers);
            Console.WriteLine(" Account holder name: " + s.names);
            Console.WriteLine(" Account Type: " + s.types);
            Console.WriteLine();
            Console.Write(" Current Balance: " + s.balances);
        }
        public static string getpassowrd()
        {
            Console.Write(" Enter your account password: ");
            string userpassword = Console.ReadLine();
            return userpassword;
        }
        public static void accountinquiry(data s)
        {
            Console.WriteLine();
            Console.WriteLine(" Account number: " + s.accountnumbers);
            Console.WriteLine(" Account holder name: " + s.names);
            Console.WriteLine(" Account Type: " + s.types);
            Console.Write(" Current Balance: " + s.balances);
            Console.WriteLine();
        }
        public static void preesanykey()
        {
            Console.Write(" Press any key to move to edit menu");
            Console.ReadKey();
        }
        public static string addnametogetedit()
        {
            Console.Write(" Enter New Account name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Account Updated. . .");
            return name;
        }
        public static string getpasswordforedit()
        {
            Console.Write(" Enter New Account Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Account Updated. . .");
            return password;
        }
        public static string inputtypeforedit()
        {
            Console.Write(" Enter Account Type( S/C ): ");
            string type = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Account Updated. . .");
            return type;
        }
        public static data editall()
        {
            Console.Write(" Enter New Account name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter New Account Password: ");
            string password = Console.ReadLine();
            Console.Write(" Enter Account Type( S/C ): ");
            string type = Console.ReadLine();
            data obj = new data(name, password, type);
            Console.WriteLine();
            Console.Write(" Account Updated. . .");
            return obj;
        }
        public static void keytocnotinuetransfer()
        {
            Console.Write(" Press any key to move to transfer amount page:");
            Console.ReadKey();
            Console.Clear();
        }
        public static data getcredientialfortransfer()
        {
            Console.Write(" Account Name of receiver: ");
            string name = Console.ReadLine();
            Console.Write(" Account Number of receiver: ");
            int accountnumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Amount to Transfer: ");
            int balance = int.Parse(Console.ReadLine());
            data obj = new data(name, accountnumber, balance);
            return obj;
        }
        public static void transfermoneytoother(List<data> s, data cred)
        {
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].names == cred.names && s[index].accountnumbers == cred.accountnumbers)
                {
                    s[index].balances = s[index].balances + cred.balances;
                    Console.WriteLine();
                    Console.WriteLine(" Balance Updated. . .");
                    break;
                }
            }
        }
        public static void notfound()
        {
            Console.WriteLine();
            Console.WriteLine(" Account not found!!! Try again");
        }
        public static data inputforloan()
        {
            Console.Write(" Account Number: ");
            int accountnumber = int.Parse(Console.ReadLine());
            Console.Write(" Account Name: ");
            string name = Console.ReadLine();
            Console.Write(" Account Password: ");
            string password = Console.ReadLine();
            data obj = new data(name, password, accountnumber);
            return obj;
        }
        public static loan inputforloanamount()
        {
            Console.Write(" Amount of loan: ");
            int loan = int.Parse(Console.ReadLine());
            Console.Write(" Date of Issue: ");
            string issue = Console.ReadLine();
            Console.Write(" Date of returning loan: ");
            string limit = Console.ReadLine();
            loan obj = new loan(loan, issue, limit);
            return obj;
        }
        public static void successfuloan()
        {
            Console.WriteLine();
            Console.WriteLine(" Your Application for loan has been received and loan has been permitted ");
        }
        public static data inputfoeinsurance()
        {
            Console.Write(" Account Number: ");
            int accountnumber = int.Parse(Console.ReadLine());
            Console.Write(" Account Name: ");
            string name = Console.ReadLine();
            Console.Write(" Account Password: ");
            string password = Console.ReadLine();
            data obj = new data(name, password, accountnumber);
            return obj;
        }
        public static insurance getinputforinsurance()
        {
            Console.Write(" Amount of Insurance: ");
            int insurance = int.Parse(Console.ReadLine());
            Console.Write(" Duration for Insurance(in year): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write(" Installments in(Monthly, Quarterly, Half yearly, Yearly): ");
            string installment = Console.ReadLine();
            insurance obj = new insurance(insurance,duration,installment);
            return obj;
        }
        public static void successfulinsurance()
        {
            Console.WriteLine();
            Console.WriteLine(" Your Application for Insurance has been received!");
            Console.WriteLine();
            Console.WriteLine(" Account Upadated. . .");
        }
        public static void incorrectdetails()
        {
            Console.WriteLine(" Incorrect details!! Try again.");
        }
        public static data inputforpayable()
        {
            Console.Write(" Account Name: ");
            string name = Console.ReadLine();
            Console.Write(" Account Password: ");
            string password = Console.ReadLine();
            data obj = new data(name, password);
            return obj;
        }
        public static int inputamountforpayable()
        {
            Console.Write(" Add Bills(U for utility, C for Challans , L for load): ");
            string bill = Console.ReadLine();
            Console.Write(" Add reference number: ");
            string referencenumber = Console.ReadLine();
            Console.Write(" Enter amount to pay: ");
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }
        public static void successfullybillpayyed()
        {
            Console.WriteLine();
            Console.WriteLine(" Your bill has been Payyed");
            Console.WriteLine();
            Console.WriteLine(" Account Updated. . . ");
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
        public static string getpasswordforuser()
        {
            Console.Write(" Enter your account password: ");
            string password = Console.ReadLine();
            return password;
        }
        public static void accountdetailsloans(data s)
        {
            Console.WriteLine(" Account number: " + s.accountnumbers);
            Console.WriteLine(" Balance: " + s.balances);
            Console.WriteLine(" Balance loan: " + s.ldata.loans);
            Console.WriteLine(" Date of Issue loan: " + s.ldata.issueloans);
            Console.WriteLine(" Date of returning loan: " + s.ldata.limitloans);
            Console.WriteLine();
        }
        public static int amounttoreturn()
        {
            Console.Write(" Amount to pay: ");
            int returnloanamount = int.Parse(Console.ReadLine());
            return returnloanamount;
        }
        public static void remainingloan(int value)
        {
            Console.WriteLine();
            Console.WriteLine(" Your Balance has been Updated ");
            Console.WriteLine(" Remaining balance loan: " + value);
        }
        public static void nohistory()
        {
            Console.WriteLine(" No loan history");
        }
        public static void resetcomplain(data s)
        {
            s.complains = "No Complain";
        }
        public static void submitcomplain(data s)
        {
            string complain;
            Console.Write(" Complain: ");
            complain = Console.ReadLine();
            s.complains = complain;
        }
        public static void successfullucomplain()
        {
            Console.WriteLine();
            Console.WriteLine(" Your Complain has been filed.");
        }
        public static void removecomplains()
        {
            menuCRUD.printheading(" Remove my Complain");
            Console.WriteLine(" Your Complain has been removed.");
        }
        public static char confirmation()
        {
            Console.Write(" Press Y to confirm or N to exit: ");
            char option4 = char.Parse(Console.ReadLine());
            return option4;
        }
        public static void suucessfullydelte()
        {
            Console.WriteLine();
            Console.WriteLine(" Your account has been deleted!!! ");
            Console.WriteLine();
            Console.WriteLine(" Account list Updated. . .");
        }
    }
}
