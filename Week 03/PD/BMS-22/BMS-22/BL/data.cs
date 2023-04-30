using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMS_22.BL
{
    class data
    {
        public string names;
        public string passwords;
        public string types;
        public int balances;
        public int accountnumbers;
        public int loans;
        public string issueloans;
        public string limitloans;
        public int insurances;
        public int durations;
        public string installments;
        public string status;
        public int fdurations;
        public string complains;
        public string role;
        public data()
        {
            
        }
        public data(string name, string password,string type, int balance)
        {
            this.names = name;
            this.passwords = password;
            this.types = type;
            this.balances = balance;
            this.complains = "No Complain";
            this.status = "UnFreeze";
        }
        public data(string name, string password)
        {
            names = name;
            passwords = password;
        }
        public bool passwordvalid(string password)
        {
            bool isvalid = false;
            int count = 0;
            for (int x = 0; password.Length > x; x++)
            {
                count++;
            }
            if (count >= 5)
            {
                isvalid = true;
            }
            return isvalid;
        }
        public bool name_check(string name)
        {
            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    i++;
                    if (i >= 5)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public string loginmenu()
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
        public void header()
        {
            Console.WriteLine();
            Console.WriteLine(" .---.              .-.     .-..-.                                                      .-.    .--.             .-.              ");
            Console.WriteLine(" : .; :             : :.-.  : `' :                                                     .' `.  : .--'           .' `.              ");
            Console.WriteLine(" :   .' .--.  ,-.,-.: `'.'  : .. : .--.  ,-.,-. .--.   .--.  .--. ,-.,-.,-. .--. ,-.,-.`. .'  `. `. .-..-. .--.`. .'.--. ,-.,-.,-");
            Console.WriteLine(" : .; :' .; ; : ,. :: . `.  : :; :' .; ; : ,. :' .; ; ' .; :' '_.': ,. ,. :' '_.': ,. : : :    _`, :: :; :`._-.': :' '_.': ,. ,. :");
            Console.WriteLine(" :___.'`.__,_;:_;:_;:_;:_;  :_;:_;`.__,_;:_;:_;`.__,_;`._. ;`.__.':_;:_;:_;`.__.':_;:_; :_;   `.__.'`._. ;`.__.':_;`.__.':_;:_;:_;");
            Console.WriteLine("                                                       .-. :                                         .-. :                        ");
            Console.WriteLine("                                                       `._.'                                         `._.'                        ");
        }
        public void innermenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" Main Menu  > " + menu);
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine();
        }
        public void loading()
        {
            Console.Write(" Your ID Is Creating, Please Wait ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("-");
                Thread.Sleep(150);
            }
        }
        public void submenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" {0}  Menu", menu);
            Console.WriteLine(" --------------------");
            Console.WriteLine();
        }
        public string admin()
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
        public string user()
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
        //           user functionailty
        public void saveloandetails (string issueloan, string limitloan, int loan, ref int bankbalance)
        {
            loans = loan;
            issueloans = issueloan;
            limitloans = limitloan;
            bankbalance = bankbalance - loan;
        }
        public void depositmoney(int deposit)
        {
            balances = balances + deposit;
        }
        public void withdraw(int withdrew)
        {
            balances = balances - withdrew;
        }
        public void clear()
        {

            Console.WriteLine();
            Console.Write(" Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }

        public void balanceinquiry()
        {
            Console.WriteLine(" Account number: " + accountnumbers);
            Console.WriteLine(" Account holder name: " + names);
            Console.WriteLine(" Account Type: " + types);
            Console.WriteLine();
            Console.Write(" Current Balance: " + balances);
        }
        public void accountinquiry()
        {
            Console.WriteLine(" Account number: " + accountnumbers);
            Console.WriteLine(" Account holder name: " + names);
            Console.WriteLine(" Account Type: " + types);
            Console.Write(" Current Balance: " + balances);
            Console.WriteLine();
        }
        public void usereditname(string name)
        {
            names = name;
        }
        public void usereditaccountmenu(string name, string password, string type)
        {
            names = name;
            passwords = password;
            types = type;
        }
        public void usereditpassword(string password)
        {
            passwords = password;
        }
        public void useredittype(string type)
        {
            types = type;
        }
        public bool tranfermoney(string name, int accountnumber, List<data> s)
        {
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].names == name && s[index].accountnumbers == accountnumber)
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkamountavailability(int amount)
        {
            bool ischeck = false;
            if (balances >= amount)
            {
                ischeck = true;
            }
            return ischeck;
        }
        public string applyforloan(string name, string password, int accountnumber)
        {
            string valid = "false";
            if (names == name && passwords == password && accountnumbers == accountnumber)
            {
                valid = "true";
            }
            return valid;
        }
        public void applyforinsurance(int insurance, int duration, string installment)
        {
            insurances = insurance;
            durations = duration;
            installments = installment;
        }
        public void payable(int amount)
        {
            balances = balances - amount;
        }
        public void accountholderdetail()
        {
            Console.WriteLine("    Acount holder's Details");
            Console.WriteLine();
            Console.WriteLine(" Account Number: " + accountnumbers);
            Console.WriteLine(" Account holder Name: " + names);
            Console.WriteLine(" Account holder's Password: " +passwords);
            Console.WriteLine(" Account holder Type: " +types);
            Console.WriteLine(" Current Balance: " + balances);
            Console.WriteLine(" Account holder Pending loan: " + loans);
        }
        public void accountdetailsloans()
        {
            Console.WriteLine(" Account number: " + accountnumbers);
            Console.WriteLine(" Balance: " + balances);
            Console.WriteLine(" Balance loan: " +loans);
            Console.WriteLine(" Date of Issue loan: " + issueloans);
            Console.WriteLine(" Date of returning loan: " +limitloans);
            Console.WriteLine();
        }
        public void returnloan(int returnloan)
        {
            balances = balances - returnloan;
            loans = loans - returnloan;
        }
        public void resetcomplain()
        {
            complains = "No Complain";
        }
        public void submitcomplain()
        {
            string complain;
            Console.Write(" Complain: ");
            complain = Console.ReadLine();
            complains = complain;
        }
        public void deletemyaccount(List<data> s, ref int currentindex)
        {
            s.RemoveAt(currentindex);
        }
        public string optiontochanheuser()
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
        public string complianmenu()
        {
            string option;
            Console.WriteLine(" 1. Submit a Complian");
            Console.WriteLine(" 2. Remove the Complain");
            Console.WriteLine();
            Console.Write(" Enter your choice:");
            option = (Console.ReadLine());
            return option;
        }
        //       admin functionailty

        public void masterlist()
        {
            Console.WriteLine();
            Console.WriteLine(" " + types + "\t" + accountnumbers + "\t " + "\t" + names + "\t" + passwords + "\t" + balances + "\t" + status);
        }
        public int searchaccountforuuserdata(string name, List<data> s)
        {
            int position = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == name)
                {
                    position = index;
                }
            }
            return position;
        }
        public void printsearchaccountdata(string name, List<data> s)
        {
            for (int position = 1; position < s.Count; position++)
            {
                if (s[position].names == name)
                {
                    s[position].accountholderdetail();
                }
            }
        }
        public void freezeueraccount(int duration)
        {
            status = "Freeze";
            fdurations = duration;
        }
        public void editmanagerboth(string newname, string newpassword)
        {
            names = newname;
            passwords = newpassword;
        }
        public void bankbalanceavailable(ref int bankbalance)
        {
            Console.WriteLine(" Current amount available in bank: " + bankbalance);
        }
        public void providingloan(int amount, string issue, string limit, ref int bankbalance)
        {
            loans = amount;
            bankbalance = bankbalance - amount;
            issueloans = issue;
            limitloans = limit;
        }
        public int numberofloanpayyed(List<data> s)
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].loans != 0)
                {
                    number++;
                }
            }
            return number;
        }
        public void listofloanholder()
        {
            Console.WriteLine(" " + names + "\t" + loans + "\t" + issueloans + "\t" + limitloans);
        }
        public int numberofinsurancepayyed(List<data> s)
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].insurances != 0)
                {
                    number++;
                }
            }
            return number;
        }
        public void listofinsuranceholder()
        {
            if (insurances != 0)
            {
                Console.WriteLine(" " + names + "\t" + insurances + "\t" +durations + "\t" + installments);
            }
        }
        public bool providesfunds(int amount, ref int bankbalance)
        {
            bool ischeck = true;
            if (bankbalance > amount)
            {
                bankbalance = bankbalance - amount;
                ischeck = true;
            }
            else if (bankbalance < amount)
            {
                ischeck = false;
            }
            return ischeck;
        }
        public bool unfreezeaccount(string name, int accountnumber, List<data> s)
        {
            bool ischeck = false;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == name && s[index].accountnumbers == accountnumber)
                {
                    s[index].status = "UnFreeze";
                    ischeck = true;
                    break;
                }
            }
            return ischeck;
        }
        public bool checkinput(string name, string userpassword)
        {
            bool found = false;
                if (names == name && passwords == userpassword)
                {
                    found = true;
                }
            return found;
        }
        public int deleteuseraccount(string name, string password, List<data> s)
        {
            int position1 = 0;
            for (int index = 1; index < s.Count; index++)
            {

                if (s[index].names == name && s[index].passwords == password)
                {
                    s[index].names = "";
                    s[index].passwords = "";
                    s[index].accountnumbers = 0;
                    s[index].loans = 0;
                    s[index].types = "";
                    s[index].insurances = 0;
                    s[index].durations = 0;
                    s[index].installments = "";
                    position1 = index;
                }
            }
            return position1;
        }
        public int numberofcomplains(List<data> s)
        {
            int number = 0;
            for (int x = 1; x < s.Count; x++)
            {
                if (s[x].complains != "No Complain")
                {
                    number++;
                }
            }
            return number;
        }
        public void seeallcomplains(int index)
        {

                if (complains != "No Complain")
                {
                    Console.WriteLine(" " + "User " + index + ". " + complains);
                }
            
        }
        public string changeadminoption()
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
        public int searchaccount(string name, string password, List<data> s)
        {
            int position = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == name && s[index].passwords == password)
                {
                    position = index;
                }
            }
            return position;
        }

    }
}
