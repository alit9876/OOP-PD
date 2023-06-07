using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using BMS_22.BL;

namespace BMS_22
{
    class Program
    {

        static void Main(string[] args)
        {
            int currentindex = 0;
            int bankbalance = 1200;
            List<data> s = new List<data>();

            loaddata(s);
            Console.Clear();
            string option1 = "0";
            bool running = true;
            while (running)
            {
                header();
                submenu("login");
                option1 = loginmenu();

                if (option1 == "1")
                {
                    string role;
                    string option;
                    Console.Clear();
                    header();
                    Console.WriteLine(s.Count);
                    submenu("Sign In");
                    string name;
                    string password;
                    Console.Write(" Enter name: ");
                    name = Console.ReadLine();
                    Console.Write(" Enter password: ");
                    password = Console.ReadLine();
                    if (s.Count != 0)
                    {
                        role = signin(s, name, password, ref currentindex);
                        if (role == "Admin")
                        {
                            string n = "1";
                            while (n != "0")
                            {
                                Console.Clear();
                                header();
                                submenu("Admin");
                                option = admin();
                                n = adminfunctionality(option, s, ref currentindex, ref bankbalance);
                                if (n != "0")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" Press any Key to Continue");
                                    Console.ReadKey();
                                }
                            }
                        }

                        if (role == "User")
                        {
                            string n = "1";
                            while (n != "0")
                            {
                                Console.Clear();
                                header();
                                submenu("User");
                                option = user();
                                n = userfunctionality(option, s, ref currentindex, ref bankbalance);
                                if (n != "0")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" Press any Key to Continue");
                                    Console.ReadKey();
                                }
                            }
                        }

                        if (role == "Freeze")
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Your account has been Freezed! ");
                            clear();
                        }

                        if (role == "Undefined")
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Account has not found! Try again");
                            clear();
                        }
                    }
                    else if (s.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid User !! SignUp first....");
                        clear();
                    }

                }

                else if (option1 == "2")
                {
                    Console.Clear();
                    header();
                    submenu("Sign Up");
                    string name;
                    string password;
                    string type;
                    int balance;
                    bool passwordvalidity;
                    Console.Write(" Enter type of account ('S' for saving & 'C' for current): ");
                    type = Console.ReadLine();
                    Console.Write(" Enter  account holder name: ");
                    name = Console.ReadLine();
                    Console.Write(" Enter password (minmum length: 5): ");
                    password = Console.ReadLine();
                    Console.Write(" Enter initial Amount : ");
                    balance = int.Parse(Console.ReadLine());
                    string Isvalid;
                    bool isName;
                    isName = name_check(name);
                    if (isName)
                    {
                        passwordvalidity = passwordvalid(password);
                        //passwordvalidity = true;
                        if (passwordvalidity)
                        {
                            Isvalid = signup(name, password, s);
                            if (Isvalid == "false")
                            {
                                data info = new data();
                                info.names = name;
                                info.passwords = password;
                                if(s.Count != 0)
                                {
                                    info.accountnumbers = s[s.Count - 1].accountnumbers + 1;
                                }
                                if(s.Count == 0)
                                {
                                    info.accountnumbers = 0;
                                }
                                info.types = type;
                                info.balances = balance;
                                info.loans = 0;
                                info.status = "UnFreeze";
                                info.complains = "No Complain";
                                info.issueloans = "00-00-00";
                                info.limitloans = "00-00-00";
                                info.insurances = 0;
                                info.durations = 0;
                                info.installments = " ";
                                info.fdurations = 0;
                                info.complains = "No Complain";
                                s.Add(info);
                                Console.WriteLine();
                                loading();
                                Console.WriteLine();
                            }

                            if (Isvalid == "true")
                            {
                                Console.WriteLine();
                                Console.WriteLine(" Already Existed! Try again ");
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Password is too short!! Try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Name consist of aplahabets only");
                    }

                    clear();
                }

                else if (option1 == "3")
                {
                    savedata(s);
                    running = false;
                }

                else
                {
                    Console.WriteLine(" Invalid choice.");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }
        static string loginmenu()
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
        static void clear()
        {

            Console.WriteLine();
            Console.Write(" Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }
        static void header()
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
        static void submenu(string menu)
        {

            Console.WriteLine();
            Console.WriteLine(" {0}  Menu", menu);
            Console.WriteLine(" --------------------");
            Console.WriteLine();
        }
        static string signin(List<data> s, string name, string password, ref int currentindex)
        {
            string role = "Undefined";
            for (int index1 = 1; index1 < s.Count; index1++)
            {
                if (name == s[index1].names && password == s[index1].passwords && s[index1].status != "Freeze")
                {
                    role = "User";
                    currentindex = index1;
                }
            }
            int index = 0;
            if (name == s[index].names && password == s[index].passwords)
            {
                role = "Admin";
                currentindex = index;
            }
            for (int index2 = 0; index2 < s.Count; index2++)
            {
                if (name == s[index2].names && password == s[index2].passwords && s[index2].status == "Freeze")
                {
                    role = "Freeze";
                }
            }
            return role;
        }
        static string admin()
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
        static string user()
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
        static bool name_check(string name)
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
        static bool passwordvalid(string password)
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
        static string signup(string name, string password, List<data> s)
        {
            string Isfound = "false";
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == name)
                {
                    Isfound = "true";
                }
            }
            return Isfound;
        }
        static void loading()
        {
            Console.Write(" Your ID Is Creating, Please Wait ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("-");
                Thread.Sleep(150);
            }
        }


        //          user functionality sub function

        static void printheading(string argumnet)
        {
            Console.Clear();
            header();
            innermenu(argumnet);
        }
        static void innermenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" Main Menu  > " + menu);
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine();
        }
        static void depositmoney(int deposit, List<data> s, ref int currentindex)
        {
            s[currentindex].balances = s[currentindex].balances + deposit;
        }
        static bool checkamountavailability(int amount, List<data> s, ref int currentindex)
        {
            bool ischeck = false;
            if (s[currentindex].balances >= amount)
            {
                ischeck = true;
            }
            return ischeck;
        }
        static void balanceinquiry(List<data> s, ref int currentindex)
        {
            Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Account holder name: " + s[currentindex].names);
            Console.WriteLine(" Account Type: " + s[currentindex].types);
            Console.WriteLine();
            Console.Write(" Current Balance: " + s[currentindex].balances);
        }
        static void withdraw(int withdrew, List<data> s, ref int currentindex)
        {
            s[currentindex].balances = s[currentindex].balances - withdrew;
        }
        static int optiontochanheuser()
        {
            int option;
            Console.WriteLine(" 1. Change Name");
            Console.WriteLine(" 2. Change password ");
            Console.WriteLine(" 3. Change account type  ");
            Console.WriteLine(" 4. Change all");
            Console.WriteLine();
            Console.Write(" Enter your choice(1-4): ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void usereditaccountmenu(string name, string password, string type,List<data> s, ref int currentindex)
        {
            s[currentindex].names = name;
            s[currentindex].passwords = password;
            s[currentindex].types = type;
        }
        static void usereditname(string name, List<data> s, ref int currentindex)
        {
            s[currentindex].names = name;
        }
        static void usereditpassword(string password, List<data> s, ref int currentindex)
        {
            s[currentindex].passwords = password;
        }
        static void useredittype(string type, List<data> s, ref int currentindex)
        {
            s[currentindex].types = type;
        }
        static bool tranfermoney(string name, int accountnumber,List<data> s)
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
        static string applyforloan(string name, string password, int accountnumber,List<data> s, ref int currentindex)
        {
            string valid = "false";
            if (s[currentindex].names == name && s[currentindex].passwords == password && s[currentindex].accountnumbers == accountnumber)
            {
                valid = "true";
            }
            return valid;
        }
        static void applyforinsurance(int insurance, int duration, string installment, List<data> s , ref int currentindex)
        {
            s[currentindex].insurances = insurance;
            s[currentindex].durations = duration;
            s[currentindex].installments = installment;
        }
        static void payable(int amount, List<data> s, ref int currentindex)
        {
            s[currentindex].balances = s[currentindex].balances - amount;
        }
        static void accountholderdetail(List<data> s, ref int currentindex)
        {
            Console.WriteLine("    Acount holder's Details");
            Console.WriteLine();
            Console.WriteLine(" Account Number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Account holder Name: " + s[currentindex].names);
            Console.WriteLine(" Account holder's Password: " + s[currentindex].passwords);
            Console.WriteLine(" Account holder Type: " + s[currentindex].types);
            Console.WriteLine(" Current Balance: " + s[currentindex].balances);
            Console.WriteLine(" Account holder Pending loan: " + s[currentindex].loans);
        }
        static void returnloan(int returnloan, List<data> s, ref int currentindex)
        {
            s[currentindex].balances = s[currentindex].balances - returnloan;
            s[currentindex].loans = s[currentindex].loans - returnloan;
        }
        static int complianmenu()
        {
            Console.Clear();
            header();
            innermenu(" Complains ");
            int option;
            Console.WriteLine(" 1. Submit a Complian");
            Console.WriteLine(" 2. Remove the Complain");
            Console.WriteLine();
            Console.Write(" Enter your choice:");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string submitcomplain()
        {
            string complain;
            Console.Write(" Complain: ");
            complain = Console.ReadLine();
            return complain;
        }
        static void resetcomplain(List<data> s, ref int currentindex)
        {
            s[currentindex].complains = "No Complain";
        }
        static void deletemyaccount(List<data> s, ref int currentindex)
        {
            s.RemoveAt(currentindex);
        }
     

        //                user functionality main

        static string userfunctionality(string option, List<data> s, ref int currentindex, ref int bankbalance)
        {
            if (option == "1")
            {
                printheading("Create an account");
                string name;
                string password;
                string type;
                int balance;
                bool passwordvalidity;
                Console.Write(" Enter type of account ('S' for saving & 'C' for current): ");
                type = Console.ReadLine();
                Console.Write(" Enter  account holder name: ");
                name = Console.ReadLine();
                Console.Write(" Enter password (minmum length: 5): ");
                password = Console.ReadLine();
                Console.Write(" Enter initial Amount : ");
                balance = int.Parse(Console.ReadLine());
                string Isvalid;
                bool isName;
                isName = name_check(name);
                if (isName)
                {
                    passwordvalidity = passwordvalid(password);
                    //passwordvalidity = true;
                    if (isName)
                    {
                        passwordvalidity = passwordvalid(password);
                        //passwordvalidity = true;
                        if (passwordvalidity)
                        {
                            Isvalid = signup(name, password, s);
                            if (Isvalid == "false")
                            {
                                data info = new data();
                                info.names = name;
                                info.passwords = password;
                                info.accountnumbers = s[s.Count - 1].accountnumbers + 1;
                                info.types = type;
                                info.balances = balance;
                                info.loans = 0;
                                info.status = "UnFreeze";
                                info.complains = "No Complain";
                                info.issueloans = "00-00-00";
                                info.limitloans = "00-00-00";
                                info.insurances = 0;
                                info.durations = 0;
                                info.installments = " ";
                                info.fdurations = 0;
                                info.complains = "No Complain";
                                s.Add(info);
                                Console.WriteLine();
                                loading();
                                Console.WriteLine();
                            }

                            if (Isvalid == "true")
                            {
                                Console.WriteLine();
                                Console.WriteLine(" Already Existed! Try again ");
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Password is too short!! Try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Name consist of aplahabets only");
                    }
                }
            }
           
            else if (option == "2")
            {
                printheading(" Deposit money");
                int accountnumber;
                Console.Write(" Enter your account number: ");
                accountnumber = int.Parse(Console.ReadLine());
                if (s[currentindex].accountnumbers == accountnumber)
                {
                    printheading(" Deposit money");
                    int deposit;
                    Console.WriteLine(" Currnet Balance " + s[currentindex].balances);
                    Console.Write(" Enter amount to deposit: ");
                    deposit = int.Parse(Console.ReadLine());
                    depositmoney(deposit, s, ref currentindex);
                    Console.WriteLine();
                    Console.Write(" Balance Updated. . .");
                }
                else
                {
                    Console.WriteLine(" Incorrect Crediential!! Try again");
                }
            }

            else if (option == "3")
            {
                printheading(" With draw money");
                int accountnumber;
                bool availability;
                Console.Write(" Enter your account number: ");
                accountnumber = int.Parse(Console.ReadLine());
                Console.Clear();
                header();
                innermenu(" Withdraw Money");
                if (s[currentindex].accountnumbers == accountnumber)
                {
                    Console.Write(" Current Balance: " + s[currentindex].balances);
                    int withdrew;
                    Console.WriteLine();
                    Console.Write(" Enter amount to with draw : ");
                    withdrew = int.Parse(Console.ReadLine());
                    availability = checkamountavailability(withdrew, s, ref currentindex);
                    if (availability)
                    {
                        withdraw(withdrew, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Balances Updated. . .");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Insufficient balance!!!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect Crediential!! Try again");
                }
            }

            else if (option == "4")
            {
                Console.Clear();
                header();
                innermenu(" Balance Inquiry ");
                balanceinquiry(s, ref currentindex);
            }

            else if (option == "5")
            {
                printheading(" Edit/Change my account");
                string name;
                string password;
                string type;
                string userpassword;
                Console.Write(" Enter your account password: ");
                userpassword = Console.ReadLine();
                if (userpassword == s[currentindex].passwords)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
                    Console.WriteLine(" Account Holder name: " + s[currentindex].names);
                    Console.WriteLine(" Account type: " + s[currentindex].types);
                    Console.WriteLine(" Current Balance: " + s[currentindex].balances);
                    Console.WriteLine();
                    Console.Write(" Press any key to move to edit menu");
                    Console.ReadKey();
                    printheading(" Edit/Change my account");
                    int option2 = optiontochanheuser();
                    if (option2 == 1)
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account name: ");
                        name = Console.ReadLine();
                        usereditname(name, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == 2)
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account Password: ");
                        password = Console.ReadLine();
                        usereditpassword(password, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == 3)
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter Account Type( S/C ): ");
                        type = Console.ReadLine();
                        useredittype(type, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == 4)
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account name: ");
                        name = Console.ReadLine();
                        Console.Write(" Enter New Account Password: ");
                        password = Console.ReadLine();
                        Console.Write(" Enter Account Type( S/C ): ");
                        type = Console.ReadLine();
                        usereditaccountmenu(name, password, type, s, ref currentindex);
                        Console.WriteLine();
                        Console.Write(" Account Updated. . .");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect Credientials !! Try again.");
                }
            }

            else if (option == "6")
            {
                printheading(" Transfer Money to other Account");
                int accountnumber;
                string name;
                bool checkcredit;
                int balance;
                string password;
                Console.Write(" Enter your account password: ");
                password = Console.ReadLine();
                if (password == s[currentindex].passwords)
                {
                    printheading(" Transfer Money to other Account");
                    Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
                    Console.WriteLine(" Account Holder Name: " + s[currentindex].names);
                    Console.WriteLine(" Account Type: " + s[currentindex].types);
                    Console.WriteLine(" Current Balance: " + s[currentindex].balances);
                    Console.WriteLine();
                    Console.Write(" Press any key to move to transfer amount page:");
                    Console.ReadKey();
                    printheading(" Transfer Money to other Account");
                    Console.Write(" Account Name of receiver: ");
                    name = Console.ReadLine();
                    Console.Write(" Account Number of receiver: ");
                    accountnumber = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write(" Amount to Transfer: ");
                    balance = int.Parse(Console.ReadLine());
                    checkcredit = checkamountavailability(balance, s, ref currentindex);
                    if (checkcredit)
                    {
                        bool Isfound;
                        Isfound = tranfermoney(name, accountnumber,s);
                        if (Isfound == true)
                        {
                            s[currentindex].balances = s[currentindex].balances - balance;
                            for (int index = 0; index < s.Count; index++)
                            {
                                if (s[index].names == name && s[index].accountnumbers == accountnumber)
                                {
                                    s[index].balances = s[index].balances + balance;
                                    Console.WriteLine();
                                    Console.WriteLine(" Balance Updated. . .");
                                    break;
                                }
                            }
                        }
                        if (Isfound == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Account not found!!! Try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Insufficient balance!! ");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect Crediential!!!  Try again");
                }
            }

            else if (option == "7")
            {
                printheading(" Apply for Loan");
                string name;
                string issue;
                string limit;
                string password;
                int accountnumber;
                int loan;
                Console.Write(" Account Number: ");
                accountnumber = int.Parse(Console.ReadLine());
                Console.Write(" Account Name: ");
                name = Console.ReadLine();
                Console.Write(" Account Password: ");
                password = Console.ReadLine();
                string valid;
                valid = applyforloan(name, password, accountnumber,s, ref currentindex);
                if (valid == "true")
                {
                    printheading(" Apply for Loan");
                    Console.Write(" Amount of loan: ");
                    loan = int.Parse(Console.ReadLine());
                    Console.Write(" Date of Issue: ");
                    issue = Console.ReadLine();
                    Console.Write(" Date of returning loan: ");
                    limit = Console.ReadLine();
                    s[currentindex].issueloans = issue;
                    s[currentindex].limitloans = limit;
                    s[currentindex].loans = loan;
                    bankbalance = bankbalance - loan;
                    Console.WriteLine();
                    Console.WriteLine(" Your Application for loan has been received and loan has been permitted ");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect credientials");
                }
            }

            else if (option == "8")
            {
                printheading(" Apply for Insurance");
                string name;
                string password;
                string installment;
                int accountnumber;
                int insurance;
                int duration;
                Console.Write(" Account Number: ");
                accountnumber = int.Parse(Console.ReadLine());
                Console.Write(" Account Name: ");
                name = Console.ReadLine();
                Console.Write(" Account Password: ");
                password = Console.ReadLine();

                if (s[currentindex].names == name && s[currentindex].passwords == password && s[currentindex].accountnumbers == accountnumber)
                {
                    printheading(" Apply for Insurance");
                    Console.Write(" Amount of Insurance: ");
                    insurance = int.Parse(Console.ReadLine());
                    Console.Write(" Duration for Insurance(in year): ");
                    duration = int.Parse(Console.ReadLine());
                    Console.Write(" Installments in(Monthly, Quarterly, Half yearly, Yearly): ");
                    installment = Console.ReadLine();
                    if (installment == "Monthly" || installment == "monthly" || installment == "Quarterly" || installment == "quarterly" || installment == "Half yearly" || installment == "Half Yearly" || installment == "half yearly" || installment == "yearly" || installment == "Yearly")
                    {
                        applyforinsurance(insurance, duration, installment, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Your Application for Insurance has been received!");
                        Console.WriteLine();
                        Console.WriteLine(" Account Upadated. . .");
                    }
                    else
                    {
                        Console.WriteLine(" Incorrect details!! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect credientials");
                }
            }

            else if (option == "9")
            {
                printheading(" Payable");
                string name;
                string password;
                string bill;
                string referencenumber;
                int amount;
                bool ischeck;
                Console.Write(" Account Name: ");
                name = Console.ReadLine();
                Console.Write(" Account Password: ");
                password = Console.ReadLine();

                if (s[currentindex].names == name && s[currentindex].passwords == password)
                {
                    printheading(" Payable");
                    Console.Write(" Add Bills(U for utility, C for Challans , L for load): ");
                    bill = Console.ReadLine();
                    Console.Write(" Add reference number: ");
                    referencenumber = Console.ReadLine();
                    Console.Write(" Enter amount to pay: ");
                    amount = int.Parse(Console.ReadLine());
                    ischeck = checkamountavailability(amount, s, ref currentindex);
                    if (ischeck)
                    {
                        payable(amount, s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Your bill has been Payyed");
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . . ");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Insufficient balance!!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect Credentials! Try again ");
                }
            }

            else if (option == "10")
            {
                Console.Clear();
                header();
                innermenu(" Account holder Details");
                accountholderdetail(s, ref currentindex);
            }

            else if (option == "11")
            {
                printheading(" Return loan");
                string password;
                int returnloanamount;
                Console.Write(" Enter your account password: ");
                password = Console.ReadLine();
                if (s[currentindex].passwords == password)
                {
                    printheading(" Return loan");
                    Console.WriteLine();

                    if (s[currentindex].loans != 0)
                    {
                        Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
                        Console.WriteLine(" Balance: " + s[currentindex].balances);
                        Console.WriteLine(" Balance loan: " + s[currentindex].loans);
                        Console.WriteLine(" Date of Issue loan: " + s[currentindex].issueloans);
                        Console.WriteLine(" Date of returning loan: " + s[currentindex].limitloans);
                        Console.WriteLine();
                        Console.Write(" Amount to pay: ");
                        returnloanamount = int.Parse(Console.ReadLine());
                        returnloan(returnloanamount, s, ref currentindex);
                        if (s[currentindex].loans < 0)
                        {
                            s[currentindex].loans = 0;
                        }
                        Console.WriteLine();
                        Console.WriteLine(" Your Balance has been Updated ");
                        Console.WriteLine(" Remaining balance loan: " + s[currentindex].loans);
                    }
                    else
                    {
                        Console.WriteLine(" No loan history");
                    }
                }
                else
                {
                    Console.WriteLine(" Incorrect Password! Try again.");
                }
            }

            else if (option == "12")
            {
                printheading(" Complain");
                string complain;
                int option3 = complianmenu();
                if (option3 == 1)
                {
                    printheading(" Submit my Complain");
                    complain = submitcomplain();
                    Console.WriteLine();
                    Console.WriteLine(" Your Complain has been filed.");
                    s[currentindex].complains = complain;
                }
                else if (option3 == 2)
                {
                    string password;
                    printheading(" Remove my Complain");
                    Console.Write(" Enter your account password:");
                    password = Console.ReadLine();
                    if (password == s[currentindex].passwords)
                    {
                        printheading(" Remove my Complain");
                        Console.WriteLine(" Your Complain has been removed.");
                        resetcomplain(s, ref currentindex);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Incorrect Password!! Try again");
                    }
                }
            }

            else if (option == "13")
            {
                printheading(" Delete my account");
                string name;
                string password;
                char option4;
                int accountnumber;
                Console.Write(" Enter Account number: ");
                accountnumber = int.Parse(Console.ReadLine());
                Console.Write(" Enter Account name: ");
                name = Console.ReadLine();
                Console.Write(" Enter account password: ");
                password = Console.ReadLine();
                if (s[currentindex].names == name && s[currentindex].passwords == password && s[currentindex].accountnumbers == accountnumber)
                {
                    printheading(" Delete my account");
                    Console.Write(" Press Y to confirm or N to exit: ");
                    option4 = char.Parse(Console.ReadLine());
                    if (option4 == 'Y')
                    {
                        deletemyaccount(s, ref currentindex);
                        Console.WriteLine();
                        Console.WriteLine(" Your account has been deleted!!! ");
                        Console.WriteLine();
                        Console.WriteLine(" Account list Updated. . .");
                        string n = "0";
                        return n;

                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Incorrect Credeientials! Try again ");
                }
                savedata(s);
            }

            else if (option == "0")
            {
                string n = "0";
                return n;
            }

            else
            {
                Console.Write(" Invalid Choice");
                Console.WriteLine();
            }

                savedata(s);
                return "1";
            }

            //     admin side sub functions

            static void masterlist(List<data> s)
            {
                Console.WriteLine(" Type" + "\t" + "Account No" + "\t" + " Name" + "\t" + "Password" + "\t" + "  Balance");
                Console.WriteLine();
                for (int index = 1; index < s.Count; index++)
                {
                    Console.WriteLine(" " + s[index].types + "\t" + s[index].accountnumbers + "\t " + "\t" + s[index].names + "\t" + s[index].passwords + "\t" + s[index].balances);
                }
            }
            static int searchaccountforuuserdata(string name, List<data> s)
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
            static void printsearchaccountdata(string name, List<data> s)
            {
                for (int position = 1; position < s.Count; position++)
                {
                    if (s[position].names == name)
                    {
                        Console.WriteLine(" Account number: " + s[position].accountnumbers);
                        Console.WriteLine(" Account holder name: " + s[position].names);
                        Console.WriteLine(" Account holder Password: " + s[position].passwords);
                        Console.WriteLine(" Account Type: " + s[position].types);
                        Console.WriteLine(" Account holder Current Balance: " + s[position].balances);
                        Console.WriteLine();
                    }
                }
            }
            static int searchaccount(string name, string password, List<data> s)
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
            static int changeadminoption()
            {
                int option;
                Console.WriteLine("  1. Change Name");
                Console.WriteLine("  2. Change password ");
                Console.WriteLine("  3. Change both ");
                Console.WriteLine();
                Console.WriteLine(" Enter your choice: ");
                option = int.Parse(Console.ReadLine());
                return option;
            }
            static void editmanagerboth(string newname, string newpassword, List<data> s) 
            {
                s[0].names = newname;
                s[0].passwords = newpassword;
            }
            static void freezeueraccount(int duration, int position, List<data> s)
            {
                s[position].status = "Freeze";
                s[position].fdurations = duration;
            }
            static void bankbalanceavailable(ref int bankbalance)
            {
                Console.WriteLine(" Current amount available in bank: " + bankbalance);
            }
            static void providingloan(int amount, string issue, string limit, int position, int bankbalance,List<data> s)
            {
                s[position].loans = amount;
                bankbalance = bankbalance - amount;
                s[position].issueloans = issue;
                s[position].limitloans = limit;
            }
            static int numberofloanpayyed(List<data> s)
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
            static int numberofinsurancepayyed(List<data> s)
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
            static void listofinsuranceholder(List<data> s)
            {
                Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "Duration (In Year)" + "\t" + "Installments ");
                Console.WriteLine();
                for (int index = 1; index < s.Count; index++)
                {
                    if (s[index].insurances != 0)
                    {
                        Console.WriteLine(" " + s[index].names + "\t" + s[index].insurances + "\t" + s[index].durations + "\t" + s[index].installments);
                    }
                }
            }
            static void listofloanholder(List<data> s) 
            {
                Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "IssueDate" + "\t" + "ReturningDate");
                Console.WriteLine();
                for (int index = 1; index < s.Count; index++)
                {
                    if (s[index].loans != 0)
                    {
                        Console.WriteLine(" " + s[index].names + "\t" + s[index].loans + "\t" + s[index].issueloans + "\t" + s[index].limitloans);
                    }
                }
            }
            static bool providesfunds(int amount, ref int bankbalance)
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
            static bool unfreezeaccount(string name, int accountnumber, List<data> s)
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
            static bool checkinput(string name, string userpassword, List<data> s)
            {
                bool found = false;
                for (int index = 1; index < s.Count; index++)
                {
                    if (s[index].names == name && s[index].passwords == userpassword)
                    {
                        found = true;
                        break;
                    }
                }
                return found;
            }
            static int deleteuseraccount(string name, string password, List <data> s)
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
            static int numberofcomplains(List<data> s)
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
            static void seeallcomplains(List<data> s)
            {
                Console.WriteLine(" Here the list of all complains");
                Console.WriteLine();
                for (int index = 1; index < s.Count; index++)
                {
                    if (s[index].complains != "No Complain")
                    {
                        Console.WriteLine(" " + "User " + index + ". " + s[index].complains);
                    }
                }
            }
          
        //     admin functionailty
            static string adminfunctionality(string option, List<data> s, ref int currentindex, ref int bankbalance)
            {

                if (option == "1")
                {
                    printheading(" Account holders masterlist");
                    masterlist(s);
                }

                else if (option == "2")
                {
                    printheading(" Search for Specific Account");
                    string name;
                    int position;
                    Console.Write(" Enter User name: ");
                    name = Console.ReadLine();
                    position = searchaccountforuuserdata(name, s);
                    if (position != 0)
                    {
                        printheading(" Search for Specific Account");
                        printsearchaccountdata(name,s);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Account has not found");
                    }
                }

                else if (option == "3")
                {
                    printheading(" Freeze User's Account");
                    string name;
                    int position = 0;
                    string password;
                    int duration;
                    Console.Write(" Enter Account holder's name to be freeze: ");
                    name = Console.ReadLine();
                    Console.Write(" Enter Account holder's password: ");
                    password = Console.ReadLine();

                    position = searchaccount(name, password, s);
                    if (position != 0)
                    {
                        printheading(" Freeze User's Account");
                        Console.Write(" Enter duration of freeze account (in days): ");
                        duration = int.Parse(Console.ReadLine());
                        freezeueraccount(duration, position, s);
                        Console.WriteLine();
                        Console.WriteLine(" The user account has been freezed for " + s[position].fdurations + " days");
                        Console.WriteLine();
                        Console.WriteLine(" Account list Updated. . .");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Account has not found! ");
                    }
                }

                else if (option == "4")
                {
                    printheading(" Edit/Change my account");
                    string password;
                    Console.Write(" Enter your Account password: ");
                    password = Console.ReadLine();
                    string newname;
                    string newpassword;
                    if (s[0].passwords == password)
                    {
                        int option1;
                        printheading(" Edit/Change my account");
                        option1 = changeadminoption();
                        if (option1 == 1)
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Name: ");
                            newname = Console.ReadLine();
                            s[0].names = newname;
                            Console.WriteLine();
                            Console.WriteLine(" Account has been Updated. .  .");
                        }
                        if (option1 == 2)
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Password: ");
                            newpassword = Console.ReadLine();
                            s[0].passwords = newpassword;
                            Console.WriteLine();
                            Console.WriteLine(" Account has been Updated. .  .");
                        }
                        if (option1 == 3)
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Name: ");
                            newname = Console.ReadLine();
                            Console.Write(" Enter New Password: ");
                            newpassword = Console.ReadLine();
                            editmanagerboth(newname, newpassword,s);
                            Console.WriteLine();
                            Console.WriteLine(" Account has been Updated. .  .");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Incorrect Crediential! Try again ");
                    }
                }

                else if (option == "5")
                {
                    printheading("Check Bank's Available Balance ");
                    bankbalanceavailable(ref bankbalance);
                }

                else if (option == "6")
                {
                    printheading(" Give loan to User");
                    string name;
                    int amount;
                    string reason;
                    string issue;
                    string limit;
                    int position = 0;
                    Console.Write(" Enter User's name whom you want to give loan: ");
                    name = Console.ReadLine();
                    position = searchaccountforuuserdata(name, s);
                    if (position != 0)
                    {
                        printheading(" Give loan to User");
                        Console.Write(" Reason for loan: ");
                        reason = Console.ReadLine();
                        Console.Write(" Enter amount of loan: ");
                        amount = int.Parse(Console.ReadLine());
                        Console.Write(" Enter date of Giving loan: ");
                        issue = Console.ReadLine();
                        Console.Write(" Enter date of returning loan: ");
                        limit = Console.ReadLine();
                        providingloan(amount, issue, limit, position, bankbalance,s);
                        Console.WriteLine();
                        Console.WriteLine("The user is given loan and his account current balance is " + s[position].balances);
                        Console.WriteLine();
                        Console.WriteLine(" Account list Updated. . .");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Account not found! ");
                    }
                }

                else if (option == "7")
                {
                    int number;
                    printheading(" Loan Holder's Details");
                    Console.WriteLine(" List of all loan holder's account");
                    Console.WriteLine();
                    number = numberofloanpayyed(s);
                    if (number != 0)
                    {
                        listofloanholder(s);
                    }
                    else
                    {
                        Console.WriteLine(" No loan has been payyed!!! ");
                    }
                }

                else if (option == "8")
                {
                    int number;
                    printheading(" Insurance holder's Details");
                    Console.WriteLine(" List of all Insurance holder's account");
                    Console.WriteLine();
                    number = numberofinsurancepayyed(s);
                    if (number != 0)
                    {
                        listofinsuranceholder(s);
                    }
                    else
                    {
                        Console.WriteLine(" No Insurance has been provided!!! ");
                    }
                }

                else if (option == "9")
                {
                    bool ischeck;
                    int amount;
                    string inistitution;
                    printheading(" Provide Funding");
                    Console.Write(" Enter insitution name: ");
                    inistitution = Console.ReadLine();
                    Console.Write(" Enter amount for fund: ");
                    amount = int.Parse(Console.ReadLine());
                    ischeck = providesfunds(amount, ref bankbalance);
                    if (ischeck)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Funds has been successfully transfered.");
                        Console.WriteLine(" Updating Account list. . .");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Insufficicent Balance!!!");
                    }
                }

                else if (option == "10")
                {
                    bool ischeck;
                    printheading(" UnFreeze User's Account");
                    string password;
                    Console.Write(" Enter your account password: ");
                    password = Console.ReadLine();
                    if (s[0].passwords == password)
                    {
                        printheading(" UnFreeze User's Account");
                        string name;
                        int accountnumber;
                        Console.Write(" Enter account number of the account you want to UnFreeze:");
                        accountnumber = int.Parse(Console.ReadLine());
                        Console.Write(" Enter account name you want to UnFreeze: ");
                        name = Console.ReadLine();
                        ischeck = unfreezeaccount(name, accountnumber, s);
                        if (ischeck)
                        {
                            Console.WriteLine();
                            Console.WriteLine(" The given account has been unfreezed successfully!");
                            Console.WriteLine(" Account list Updated. . .");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Account not found!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Incorrect password! Try again");
                    }
                }

                else if (option == "11")
                {
                    printheading(" Delete Account");
                    string password;
                    string name;
                    bool found;
                    int position;
                    string userpassword;
                    Console.Write(" Enter your account password: ");
                    password = Console.ReadLine();
                    if (s[0].passwords == password)
                    {
                        printheading(" Delete Account");
                        Console.Write(" Enter account holder's name: ");
                        name = Console.ReadLine();
                        Console.Write(" Enter account holder's password: ");
                        userpassword = Console.ReadLine();
                        found = checkinput(name, userpassword, s);
                    if (found)
                    {
                        position = deleteuseraccount(name, userpassword, s);
                        Console.WriteLine();
                        Console.WriteLine(" The user's account has been deleted and his closing balance is:" + s[position].balances);
                        Console.WriteLine();
                        Console.WriteLine(" Account list has been Updated. . .");
                        s.RemoveAt(position);
                        }
                        else
                        {
                            printheading(" Delete Account");
                            Console.WriteLine(" Incorrect Credientials!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Incorrect crediential! Try again");
                    }
                }

                else if (option == "12")
                {
                    int complain;
                    printheading(" See all Complains");
                    complain = numberofcomplains(s);
                    if (complain > 0)
                    {
                        seeallcomplains(s);
                    }
                    else if (complain == 0)
                    {
                        printheading(" See all Complains");
                        Console.WriteLine(" No Complain has been registered.");
                    }
                }

                else if (option == "0")
                {
                    string n = "0";
                    return n;
                }

                else
                {
                    Console.Write(" Invalid Choice");
                    Console.WriteLine();
                }

                savedata(s);
                return "1";
            }

            //     file handling

            static void loaddata(List<data> s)
            {
                string record;
                string path = "record.txt";
                StreamReader myfile = new StreamReader(path);

                while ((record = myfile.ReadLine()) != null)
                {
                    data s1 = new data();
                    s1.names = getfield(record, 1);
                    s1.passwords = getfield(record, 2);
                    s1.types = getfield(record, 3);
                    s1.balances = int.Parse(getfield(record, 4));
                    s1.accountnumbers = int.Parse(getfield(record, 5));
                    s1.loans = int.Parse(getfield(record, 6));
                    s1.issueloans = getfield(record, 7);
                    s1.limitloans = getfield(record, 8);
                    s1.insurances = int.Parse(getfield(record, 9));
                    s1.durations = int.Parse(getfield(record, 10));
                    s1.installments = getfield(record, 11);
                    s1.status = getfield(record, 12);
                    s1.fdurations = int.Parse(getfield(record, 13));
                    s1.complains = getfield(record, 14);
                    s.Add(s1);
                }
                myfile.Close();
            }
            public static string getfield(string record, int field)
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
            static void savedata(List<data> s)
            {
                string path = "record.txt";
                StreamWriter file = new StreamWriter(path, false);
                for (int index = 0; index < s.Count; index++)
                {
                    file.Write(s[index].names + ",");
                    file.Write(s[index].passwords + ",");
                    file.Write(s[index].types + ",");
                    file.Write(s[index].balances + ",");
                    file.Write(s[index].accountnumbers + ",");
                    file.Write(s[index].loans + ",");
                    file.Write(s[index].issueloans + ",");
                    file.Write(s[index].limitloans + ",");
                    file.Write(s[index].insurances + ",");
                    file.Write(s[index].durations + ",");
                    file.Write(s[index].installments + ",");
                    file.Write(s[index].status + ",");
                    file.Write(s[index].fdurations + ",");
                    file.WriteLine(s[index].complains);
                }
                file.Close();
            }

        }
    
    }
 
