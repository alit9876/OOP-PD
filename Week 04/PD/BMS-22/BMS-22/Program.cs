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
            int bankbalance = 12000;
            List<data> s = new List<data>();
            data run = new data();
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
                    string option;
                    Console.Clear();
                    header();
                    submenu("Sign In");
                    string name;
                    string password;
                    Console.Write(" Enter name: ");
                    name = Console.ReadLine();
                    Console.Write(" Enter password: ");
                    password = Console.ReadLine();
                    if (s.Count != 0)
                    {
                        data signin = new data(name, password);
                        signin = signIn(signin, s, ref currentindex);
                      //  role = signin(s, name, password, ref currentindex);
                        if(signin == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Account has not found! Try again");
                            clear();
                        }
                        else if (signin != null)
                        {
                            string value = s[currentindex].freezestatus();
                            if (value == "UnFreeze")
                            {
                                if (s[currentindex].role == "admin")
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
                                if (s[currentindex].role == "User")
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
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine(" Your account has been Freezed! ");
                                clear();
                            }
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
                    data up = new data();
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
                    isName = up.name_check(name);
                    if (isName)
                    {
                        passwordvalidity = up.passwordvalid(password);
                        //passwordvalidity = true;
                        if (passwordvalidity)
                        {
                            Isvalid = signup(name, password, s);
                            if (Isvalid == "false")
                            {
                                data info = new data(name,password,type,balance);
                                if(s.Count != 0)
                                {
                                    info.accountnumbers = s[s.Count - 1].accountnumbers + 1;
                                    info.role = "User";
                                }
                                if(s.Count == 0)
                                {
                                    info.accountnumbers = 0;
                                    info.role = "admin";
                                }
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
                        }else
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

        static data signIn(data signin, List<data> s, ref int currentindex)
        {
            int count = 0;
            foreach (data storedUser in s)
            {
                if(signin.names == storedUser.names && signin.passwords == storedUser.passwords)
                {
                    currentindex = count;
                    return storedUser;
                }
                count++;
            }
            return null;
        }
        static bool signinf(List<data> s, ref int currentindex)
        {
            bool ischeck = false;
            string value = s[currentindex].freezestatus();
            if (value == "Freeze")
            {
                ischeck = true;
            }
            return ischeck;
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
        static void innermenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" Main Menu  > " + menu);
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine();
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
        static void submenu(string menu)
        {
            Console.WriteLine();
            Console.WriteLine(" {0}  Menu", menu);
            Console.WriteLine(" --------------------");
            Console.WriteLine();
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
        static void clear()
        {

            Console.WriteLine();
            Console.Write(" Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }
        //          user functionality sub function

        static void printheading(string argumnet)
        {
            
            Console.Clear();
            header();
            innermenu(argumnet);
        }
        static string optiontochanheuser()
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
        static string complianmenu()
        {
            string option;
            Console.WriteLine(" 1. Submit a Complian");
            Console.WriteLine(" 2. Remove the Complain");
            Console.WriteLine();
            Console.Write(" Enter your choice:");
            option = (Console.ReadLine());
            return option;
        }
        static void balanceinquiry(List<data>s, int currentindex)
        {
            Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Account holder name: " + s[currentindex].names);
            Console.WriteLine(" Account Type: " + s[currentindex].types);
            Console.WriteLine();
            Console.Write(" Current Balance: " + s[currentindex].balances);
        }
        static void accountinquiry(List<data> s, int currentindex)
        {
            Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Account holder name: " + s[currentindex].names);
            Console.WriteLine(" Account Type: " + s[currentindex].types);
            Console.Write(" Current Balance: " + s[currentindex].balances);
            Console.WriteLine();
        }
        static void accountholderdetail(List<data> s, int currentindex)
        {
            int loan = 0;
            string limitloan = "";
            string issuelaons = "";
            s[currentindex].returnloan(ref loan, ref issuelaons, ref limitloan);
            Console.WriteLine("    Acount holder's Details");
            Console.WriteLine();
            Console.WriteLine(" Account Number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Account holder Name: " + s[currentindex].names);
            Console.WriteLine(" Account holder's Password: " + s[currentindex].passwords);
            Console.WriteLine(" Account holder Type: " + s[currentindex].types);
            Console.WriteLine(" Current Balance: " + s[currentindex].balances);
            Console.WriteLine(" Account holder Pending loan: " + loan);
        }
        static void accountdetailsloans(List<data> s, int currentindex)
        {
            int loan=0;
            string limitloan="";
            string issuelaons = "";
            Console.WriteLine(" Account number: " + s[currentindex].accountnumbers);
            Console.WriteLine(" Balance: " + s[currentindex].balances);
            s[currentindex].returnloan(ref loan, ref issuelaons, ref limitloan);
            Console.WriteLine(" Balance loan: " + loan);
            Console.WriteLine(" Date of Issue loan: " + issuelaons);
            Console.WriteLine(" Date of returning loan: " + limitloan);
            Console.WriteLine();
        }
        
        //                user functionality main

        static string userfunctionality(string option, List<data> s, ref int currentindex, ref int bankbalance)
        {
            if (option == "1")
            {
                data pass = new data();
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
                isName = pass.name_check(name);
                if (isName)
                {
                    passwordvalidity = pass.passwordvalid(password);
                    //passwordvalidity = true;
                    if (passwordvalidity)
                    {
                        Isvalid = signup(name, password, s);
                        if (Isvalid == "false")
                        {
                            data info = new data(name, password, type, balance);
                            if (s.Count != 0)
                            {
                                info.accountnumbers = s[s.Count - 1].accountnumbers + 1;
                                info.role = "User";
                            }
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
                    s[currentindex].depositmoney(deposit);
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
                data run = new data();
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
                    availability = s[currentindex].checkamountavailability(withdrew);
                    if (availability)
                    {
                        s[currentindex].withdraw(withdrew);
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
                data run = new data();
                Console.Clear();
                header();
                innermenu(" Balance Inquiry ");
                balanceinquiry(s,currentindex);
            }

            else if (option == "5")
            {
                printheading(" Edit/Change my account");
                data s2 = new data();
                string name;
                string password;
                string type;
                string userpassword;
                Console.Write(" Enter your account password: ");
                userpassword = Console.ReadLine();
                if (userpassword == s[currentindex].passwords)
                {
                    Console.WriteLine();
                    accountinquiry(s, currentindex);
                    Console.Write(" Press any key to move to edit menu");
                    Console.ReadKey();
                    printheading(" Edit/Change my account");
                    string option2 = optiontochanheuser();
                    if (option2 == "1")
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account name: ");
                        name = Console.ReadLine();
                        s[currentindex].usereditname(name);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == "2")
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account Password: ");
                        password = Console.ReadLine();
                        s[currentindex].usereditpassword(password);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == "3")
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter Account Type( S/C ): ");
                        type = Console.ReadLine();
                        s[currentindex].useredittype(type);
                        Console.WriteLine();
                        Console.WriteLine(" Account Updated. . .");
                    }
                    if (option2 == "4")
                    {
                        printheading(" Edit/Change my account");
                        Console.Write(" Enter New Account name: ");
                        name = Console.ReadLine();
                        Console.Write(" Enter New Account Password: ");
                        password = Console.ReadLine();
                        Console.Write(" Enter Account Type( S/C ): ");
                        type = Console.ReadLine();
                        s[currentindex].usereditaccountmenu(name, password, type);
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
                    accountinquiry(s,currentindex);
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
                    checkcredit = s[currentindex].checkamountavailability(balance);
                    if (checkcredit)
                    {
                        data transfer = new data();
                        bool Isfound;
                        Isfound = transfer.tranfermoney(name, accountnumber,s);
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
                valid = s[currentindex].applyforloan(name, password, accountnumber);
                if (valid == "true")
                {
                    printheading(" Apply for Loan");
                    Console.Write(" Amount of loan: ");
                    loan = int.Parse(Console.ReadLine());
                    Console.Write(" Date of Issue: ");
                    issue = Console.ReadLine();
                    Console.Write(" Date of returning loan: ");
                    limit = Console.ReadLine();
                    s[currentindex].saveloandetails(issue,limit, loan, ref bankbalance);
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
                        s[currentindex].applyforinsurance(insurance, duration, installment);
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
                    ischeck = s[currentindex].checkamountavailability(amount);
                    if (ischeck)
                    {
                        s[currentindex].payable(amount);
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
                data run1 = new data();
                Console.Clear();
                header();
                innermenu(" Account holder Details");
                accountholderdetail(s,currentindex);
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
                    int loan=0;
                    int value = s[currentindex].loanvalu(loan);
                    if (value != 0)
                    {
                        accountdetailsloans(s,currentindex);
                        Console.Write(" Amount to pay: ");
                        returnloanamount = int.Parse(Console.ReadLine());
                        s[currentindex].returnloan(returnloanamount);
                        if ((value < 0))
                        {
                            value = 0;
                        }
                        Console.WriteLine();
                        Console.WriteLine(" Your Balance has been Updated ");
                        int value1 = s[currentindex].rloan();
                        Console.WriteLine(" Remaining balance loan: " + value1);
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
                data com = new data();
                printheading(" Complain");
                Console.Clear();
                header();
                innermenu(" Complains ");
                string option3 = complianmenu();
                if (option3 == "1")
                {
                    printheading(" Submit my Complain");
                    s[currentindex].submitcomplain();
                    Console.WriteLine();
                    Console.WriteLine(" Your Complain has been filed.");
                }
                else if (option3 == "2")
                {
                    string password;
                    printheading(" Remove my Complain");
                    Console.Write(" Enter your account password:");
                    password = Console.ReadLine();
                    if (password == s[currentindex].passwords)
                    {
                        printheading(" Remove my Complain");
                        Console.WriteLine(" Your Complain has been removed.");
                        s[currentindex].resetcomplain();
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
                        s[currentindex].deletemyaccount(s, ref currentindex);
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

        static void bankbalanceavailable(ref int bankbalance)
        {
            Console.WriteLine(" Current amount available in bank: " + bankbalance);
        }
        static void listofloanholder(data s)
        {
            int loan = 0;
            string limitloan = "";
            string issuelaons = "";
            s.returnloan(ref loan, ref issuelaons, ref limitloan);
            Console.WriteLine(" " + s.names + "\t" + loan + "\t" + issuelaons + "\t" + limitloan);
        }
        static void listofinsuranceholder(data s)
        {
            int insu = 0;
            int du = 0;
            string installment = "";
            s.retruninsurance(ref insu, ref du, ref installment);
            if (insu != 0)
            {
                Console.WriteLine(" " + s.names + "\t" + insu + "\t" + du + "\t" + installment);
            }
        }
        static void seeallcomplains(data s,int index)
        {

            if (s.complains != "No Complain")
            {
                Console.WriteLine(" " + "User " + index + ". " + s.complains);
            }

        }
        static void masterlist(data s)
        {
            string status = s.freezestatus();
            Console.WriteLine();
            Console.WriteLine(" " + s.types + "\t" + s.accountnumbers + "\t " + "\t" + s.names + "\t" + s.passwords + "\t" + s.balances + "\t" + status);
        }
        static string changeadminoption()
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


        //     admin functionailty
        static string adminfunctionality(string option, List<data> s, ref int currentindex, ref int bankbalance)
            {

                if (option == "1")
                {
                printheading(" Account holders masterlist");
                Console.WriteLine(" Type" + "\t" + "Account No" + "\t" + " Name" + "\t" + "Password" + "\t" + "  Balance" + "\t" + " Status");
                for (int index = 1; index < s.Count; index++)
                {
                    masterlist(s[index]);
                }
                }

                else if (option == "2")
                {
                    data check = new data();
                    printheading(" Search for Specific Account");
                    string name;
                    int position;
                    Console.Write(" Enter User name: ");
                    name = Console.ReadLine();
                    position = check.searchaccountforuuserdata(name, s);
                    if (position != 0)
                    {
                        printheading(" Search for Specific Account");
                        int pos = check.printsearchaccountdata(name,s);
                        accountholderdetail(s, pos);
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
                    data search = new data();
                    position = search.searchaccount(name, password, s);
                    if (position != 0)
                    {
                        printheading(" Freeze User's Account");
                        Console.Write(" Enter duration of freeze account (in days): ");
                        duration = int.Parse(Console.ReadLine());
                        s[position].freezeueraccount(duration);
                        Console.WriteLine();
                        int value = s[position].freezeduration();
                        Console.WriteLine(" The user account has been freezed for " + value + " days");
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
                data chang = new data();
                    printheading(" Edit/Change my account");
                    string password;
                    Console.Write(" Enter your Account password: ");
                    password = Console.ReadLine();
                    string newname;
                    string newpassword;
                    if (s[0].passwords == password)
                    {
                        string option1;
                        printheading(" Edit/Change my account");
                        option1 = changeadminoption();
                        if (option1 == "1")
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Name: ");
                            newname = Console.ReadLine();
                            s[0].names = newname;
                            Console.WriteLine();
                            Console.WriteLine(" Account has been Updated. .  .");
                        }
                        if (option1 == "2")
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Password: ");
                            newpassword = Console.ReadLine();
                            s[0].passwords = newpassword;
                            Console.WriteLine();
                            Console.WriteLine(" Account has been Updated. .  .");
                        }
                        if (option1 == "3")
                        {
                            printheading(" Edit/Change my account");
                            Console.Write(" Enter New Name: ");
                            newname = Console.ReadLine();
                            Console.Write(" Enter New Password: ");
                            newpassword = Console.ReadLine();
                            s[0].editmanagerboth(newname, newpassword);
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
                    data check = new data();
                    printheading(" Give loan to User");
                    string name;
                    int amount;
                    string reason;
                    string issue;
                    string limit;
                    int position = 0;
                    Console.Write(" Enter User's name whom you want to give loan: ");
                    name = Console.ReadLine();
                    position = check.searchaccountforuuserdata(name, s);
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
                        s[position].providingloan(amount, issue, limit,ref bankbalance);
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
                data ln = new data();
                    int number;
                    printheading(" Loan Holder's Details");
                    Console.WriteLine(" List of all loan holder's account");
                    Console.WriteLine();
                    number = ln.numberofloanpayyed(s);
                    if (number != 0)
                    {
                    Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "IssueDate" + "\t" + "ReturningDate");
                    Console.WriteLine();
                    for (int index = 1; index < s.Count; index++)
                    {
                        int loan = 0;
                        int value = s[index].loanvalu(loan);
                        if (value != 0)
                        {
                            listofloanholder(s[index]);
                        }
                    }
                    
                    }
                    else
                    {
                        Console.WriteLine(" No loan has been payyed!!! ");
                    }
                }

                else if (option == "8")
                {
                data ins = new data();
                    int number;
                    printheading(" Insurance holder's Details");
                    Console.WriteLine(" List of all Insurance holder's account");
                    Console.WriteLine();
                    number = ins.numberofinsurancepayyed(s);
                    if (number != 0)
                    {
                    Console.WriteLine(" Name" + "\t" + "Amount" + "\t" + "Duration (In Year)" + "\t" + "Installments ");
                    Console.WriteLine();
                    for (int index = 1; index < s.Count; index++)
                    {
                        listofinsuranceholder(s[index]);
                    }
                    
                    }
                    else
                    {
                        Console.WriteLine(" No Insurance has been provided!!! ");
                    }
                }

                else if (option == "9")
                {
                    data fund = new data();
                    bool ischeck;
                    int amount;
                    string inistitution;
                    printheading(" Provide Funding");
                    Console.Write(" Enter insitution name: ");
                    inistitution = Console.ReadLine();
                    Console.Write(" Enter amount for fund: ");
                    amount = int.Parse(Console.ReadLine());
                    ischeck = fund.providesfunds(amount, ref bankbalance);
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
                        data freeze = new data();
                        ischeck = freeze.unfreezeaccount(name, accountnumber, s);
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
                    bool found = false;
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
                    for (int index = 1; index < s.Count; index++)
                    {
                        found = s[index].checkinput(name, userpassword);
                    }
                    if (found)
                    {
                        data del = new data();
                        position = del.deleteuseraccount(name, userpassword, s);
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
                    data compl = new data();
                    int complain;
                    printheading(" See all Complains");
                    complain = compl.numberofcomplains(s);
                if (complain > 0)
                {
                    Console.WriteLine(" Here the list of all complains");
                    Console.WriteLine();
                    for (int index = 1; index < s.Count; index++)
                    {
                        seeallcomplains(s[index],index);
                    }
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
                    int loans = int.Parse(getfield(record, 6));
                    string issueloans = getfield(record, 7);
                    string limitloans = getfield(record, 8);
                    int insu = int.Parse(getfield(record, 9));
                    int du = int.Parse(getfield(record, 10));
                    string installment = getfield(record, 11);
                    string status = getfield(record, 12);
                    int fdurations = int.Parse(getfield(record, 13));
                    s1.complains = getfield(record, 14);
                    s1.role = getfield(record, 15);
                    s1.insertloandata(loans, limitloans, issueloans);
                    s1.insertinsurancedata(insu, du, installment);
                    s1.insertfreezedata( status, fdurations);
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
                    int insu = 0;
                    int du = 0;
                    string installment = "";
                    string role = "";
                    int fd = 0;
                    s[index].returnfreeze(ref role, ref fd);
                    s[index].retruninsurance(ref insu, ref du, ref installment);
                    int loan = 0;
                    string limitloan = "";
                    string issuelaons = "";
                    s[index].returnloan(ref loan, ref issuelaons, ref limitloan);
                    file.Write(s[index].names + ",");
                    file.Write(s[index].passwords + ",");
                    file.Write(s[index].types + ",");
                    file.Write(s[index].balances + ",");
                    file.Write(s[index].accountnumbers + ",");
                    file.Write(loan + ",");
                    file.Write(issuelaons + ",");
                    file.Write(limitloan + ",");
                    file.Write(insu + ",");
                    file.Write(du + ",");
                    file.Write(installment + ",");
                    file.Write(role + ",");
                    file.Write(fd + ",");
                    file.Write(s[index].complains + ",");
                    file.WriteLine(s[index].role);
                }
                file.Close();
            }

        }
    
    }
 
