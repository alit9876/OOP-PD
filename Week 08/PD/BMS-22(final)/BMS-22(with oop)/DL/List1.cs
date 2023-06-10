using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BMS_22_with_oop_.BL;
using BMS_22_with_oop_.UI;

namespace BMS_22_with_oop_.DL
{
    class List1
    {
        static List<user> s = new List<user>();
        public static void adddataintolist(user obj)
        {
            s.Add(obj);
        }
        public static int listcount()
        {
            return s.Count();
        }
        public static bool passwordvalid(string password)
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
        public static bool namecheck(string name)
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
        public static string signup(user obj)
        {
            string Isfound = "false";
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].gettername() == obj.gettername())
                {
                    Isfound = "true";
                }
            }
            return Isfound;
        }
        public static user setacrole(user obj)
        {
            if (s.Count != 0)
            {
                obj.setaccountnumbers(s[s.Count - 1].getteraccountnumbers() + 1);
                obj.setrole("User");
            }
            if (s.Count == 0)
            {
                obj.setaccountnumbers(0);
                obj.setrole("admin");
            }
            return obj;
        }
        public static user signIn(user signin, ref int currentindex)
        {
            int count = 0;
            foreach (user storedUser in s)
            {
                if (signin.gettername() == storedUser.gettername() && signin.getterpassword() == storedUser.getterpassword())
                {
                    currentindex = count;
                    return storedUser;
                }
                count++;
            }
            return null;
        }
        public static string signinf(int currentindex)
        {
            string value = s[currentindex].getterstattus();
            return value;
        }
        public static string returnrole(int currentindex)
        {
            string role = s[currentindex].getterrole();
            return role;
        }

        //   admin sub functionality
        public static int searchaccountforuuserdata(string name)
        {
            int position = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].gettername() == name)
                {
                    position = index;
                }
            }
            return position;
        }
        public static int printsearchaccountdata(string name)
        {
            int pos = 0;
            for (int position = 1; position < s.Count; position++)
            {
                if (s[position].gettername() == name)
                {
                    pos = position;
                }
            }
            return pos;
        }
        public static int searchaccount(user obj)
        {
            int position = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].gettername() == obj.gettername() && s[index].getterpassword() == obj.getterpassword())
                {
                    position = index;
                }
            }
            return position;
        }
        public static int numberofloanpayyed()
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].getterloans() != 0)
                {
                    number++;
                }
            }
            return number;
        }
        public static int numberofinsurancepayyed()
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {

                if (s[index].getterinsurances() != 0)
                {
                    number++;
                }
            }
            return number;
        }
        public static bool providesfunds(int amount, ref int bankbalance)
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
        public static bool checkinput(user obj)
        {
            bool found = false;
            for (int x = 0; x < s.Count; x++)
            {
                if (s[x].gettername() == obj.gettername() && s[x].getterpassword() == obj.getterpassword())
                {
                    found = true;
                }
            }
            return found;
        }
        public static int deleteuseraccount(user obj)
        {
            int position1 = 0;
            for (int index = 1; index < s.Count; index++)
            {

                if (s[index].gettername() == obj.gettername() && s[index].getterpassword() == obj.getterpassword())
                {
                    s[index].setname(" ");
                    s[index].setpassword(" ");
                    s[index].setaccountnumbers(0);
                    s[index].settypes("");
                    position1 = index;
                }
            }
            return position1;
        }
        public static int numberofcomplains()
        {
            int number = 0;
            for (int x = 1; x < s.Count; x++)
        
            {
                if (s[x].gettercomplains() != "No Complain")
                {
                    number++;
                }
            }
            return number;
        }
        
        //   admin funtionality
        public static string adminfunctionality(string option, ref int currentindex, ref int bankbalance)
        {

            if (option == "1")
            {
                menuCRUD.printheading(" Account holders masterlist");
                adminCRUD.headeradminop1();
                for (int index = 1; index < s.Count; index++)
                {
                    adminCRUD.masterlist(s[index]);
                }
            }

            else if (option == "2")
            {
                menuCRUD.printheading(" Search for Specific Account");
                string name = adminCRUD.getinputforop2();
                int position = searchaccountforuuserdata(name);
                if (position != 0)
                {
                    menuCRUD.printheading(" Search for Specific Account");
                    int pos = printsearchaccountdata(name);
                    adminCRUD.accountholderdetail(s[pos]);
                }
                else
                {
                    adminCRUD.notfound2();
                }
            }

            else if (option == "3")
            {
                menuCRUD.printheading(" Freeze User's Account");
                user search = FCRUD.inputforop3();
                int position = searchaccount(search);
                if (position != 0)
                {
                    menuCRUD.printheading(" Freeze User's Account");
                    int duration = FCRUD.freezedur();
                    s[position].freezeueraccount(duration);
                    FCRUD.freezedisplay(s[position].getterfdurations());
                }
                else
                {
                    adminCRUD.notfound2();
                }
            }

            else if (option == "4")
            {
                menuCRUD.printheading(" Edit/Change my account");
                string password = adminCRUD.passowrd();
                string newname;
                string newpassword;
                if (s[0].getterpassword() == password)
                {
                    string option1;
                    menuCRUD.printheading(" Edit/Change my account");
                    option1 = menuCRUD.changeadminoption();
                    if (option1 == "1")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        newname = adminCRUD.newnameadmin();
                        s[0].setname(newname);
                    }
                    if (option1 == "2")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        newpassword = adminCRUD.newpasswordadmin();
                        s[0].setpassword(newpassword);
                    }
                    if (option1 == "3")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        user obj = adminCRUD.editbothadmin();
                        s[0].changebothadmin(obj);
                        adminCRUD.updatedadmin();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "5")
            {
                menuCRUD.printheading("Check Bank's Available Balance ");
                adminCRUD.bankbalanceavailable(ref bankbalance);
            }

            else if (option == "6")
            {
                menuCRUD.printheading(" Give loan to User");
                string name = lCRUD.nameforloanadmin();
                int position = searchaccountforuuserdata(name);
                if (position != 0)
                {
                    menuCRUD.printheading(" Give loan to User");
                    loan obj = lCRUD.givingloan();
                    s[position].providingloan(obj,ref bankbalance);
                    lCRUD.givingloanadmin(s[position].getterbalances());
                }
                else
                {
                    adminCRUD.notfound2();
                }
            }

            else if (option == "7")
            {
                int number = numberofloanpayyed();
                if (number != 0)
                {
                    lCRUD.hesderforloandetails();
                    for (int index = 1; index < s.Count; index++)
                    {
                        int loan = 0;
                        int value = s[index].getterloans();
                        if (value != 0)
                        {
                            lCRUD.listofloanholder(s[index]);
                        }
                    }
                }
                else
                {
                    lCRUD.notpayyed();
                }
            }

            else if (option == "8")
            {
                lCRUD.headerinsurance();
                int number = numberofinsurancepayyed();
                if (number != 0)
                {
                    lCRUD.insurancedisplay();
                    for (int index = 1; index < s.Count; index++)
                    {
                        lCRUD.listofinsuranceholder(s[index]);
                    }
                }
                else
                {
                    lCRUD.elseins();
                }
            }

            else if (option == "9")
            {
                int amount = adminCRUD.inputforfunds();
                bool ischeck = providesfunds(amount, ref bankbalance);
                if (ischeck)
                {
                    adminCRUD.successfullyfunds();
                }
                else
                {
                    adminCRUD.notprovidefund();
                }
            }

            else if (option == "10")
            {
                menuCRUD.printheading(" UnFreeze User's Account");
                string password;
                Console.Write(" Enter your account password: ");
                password = Console.ReadLine();
                if (s[0].getterpassword() == password)
                {
                    menuCRUD.printheading(" UnFreeze User's Account");
                    customer obj3 = FCRUD.unfreezeinput();
                    bool ischeck = freeze.unfreezeaccount(obj3, s);
                    if (ischeck)
                    {
                        FCRUD.succesfulunfreeze();
                    }
                    else
                    {
                        adminCRUD.notfound2();
                    }
                }
                else
                {
                    FCRUD.incorrect();
                }
            }

            else if (option == "11")
            {
                menuCRUD.printheading(" Delete Account");
                string password = adminCRUD.inputpassword();
                if (s[0].getterpassword() == password)
                {
                    menuCRUD.printheading(" Delete Account");
                    user obj = adminCRUD.inputpasswordfordelete();
                    bool found = checkinput(obj);
                    if (found)
                    {
                        int position = deleteuseraccount(obj);
                        adminCRUD.successfullydelete(s[position].getterbalances());
                        s.RemoveAt(position);
                    }
                    else
                    {
                        adminCRUD.deleteincorect();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "12")
            {
                menuCRUD.printheading(" See all Complains");
                int complain = numberofcomplains();
                if (complain > 0)
                {
                    adminCRUD.headercomplains();
                    for (int index = 1; index < s.Count; index++)
                    {
                        adminCRUD.seeallcomplains(s[index], index);
                    }
                }
                else if (complain == 0)
                {
                    adminCRUD.notcomplainreg();
                }
            }

            else if (option == "0")
            {
                string n = "0";
                return n;
            }

            else
            {
                adminCRUD.invalidchoice();
            }
            savedataforadmin();
            savedata();
            return "1";
        }

        //       user sub functionality
        public static bool tranfermoney(customer cred)
        {
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].gettername() == cred.gettername() && s[index].getteraccountnumbers() == cred.getteraccountnumbers())
                {
                    return true;
                }
            }
            return false;
        }
        public static void transfermoneytoother(List<user> s, customer cred)
        {
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].gettername() == cred.gettername() && s[index].getteraccountnumbers() == cred.getteraccountnumbers())
                {
                    s[index].setbalances(s[index].getterbalances() + cred.getterbalances());
                    customerCRUD.transfetsuces();
                    break;
                }
            }
        }
        public static void deletemyaccount(ref int currentindex)
        {
            s.RemoveAt(currentindex);
        }
        //   user fuctionality 
        public static string userfunctionality(string option, ref int currentindex, ref int bankbalance)
        {
            if (option == "1")
            {
                Console.Clear();
                menuCRUD.header();
                menuCRUD.printheading(" Create a new account");
                user obj;
                if (s.Count == 0)
                {
                    obj = userCRUD.takeinputforsigupadmin();
                }
                else
                {
                    obj = userCRUD.takeinputforsignup();
                }
                string Isvalid;
                bool isName;
                isName = List1.namecheck(obj.gettername());
                if (isName)
                {
                    bool passwordvalidity = List1.passwordvalid(obj.getterpassword());
                    if (passwordvalidity)
                    {
                        Isvalid = List1.signup(obj);
                        if (Isvalid == "false")
                        {
                            List1.adddataintolist(List1.setacrole(obj));
                            menuCRUD.loading();
                        }

                        if (Isvalid == "true")
                        {
                            userCRUD.alreadyexit();
                        }
                    }
                    else
                    {
                        userCRUD.passwordshot();
                    }
                }
                else
                {
                    userCRUD.nameingerror();
                }

                menuCRUD.clear();
            }

            else if (option == "2")
            {
                menuCRUD.printheading(" Deposit money");
                int accountnumber = customerCRUD.accountnumberinput();
                if (s[currentindex].getteraccountnumbers() == accountnumber)
                {
                    menuCRUD.printheading(" Deposit money");
                    int deposit = customerCRUD.depositinputamount(s[currentindex].getterbalances());
                    s[currentindex].depositmoney(deposit);
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "3")
            {
                menuCRUD.printheading(" With draw money");
                int accountnumber = customerCRUD.accountnumberinput();
                menuCRUD.printheading(" Withdraw Money");
                if (s[currentindex].getteraccountnumbers() == accountnumber)
                {
                    int withdrew = customerCRUD.inputforwithdranw(s[currentindex].getterbalances());
                    bool availability = s[currentindex].checkamountavailability(withdrew);
                    if (availability)
                    {
                        s[currentindex].withdraw(withdrew);
                        customerCRUD.successfullywithdrew();
                    }
                    else
                    {
                        customerCRUD.insufficientbal();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "4")
            {
                menuCRUD.printheading(" Balance Inquiry ");
                customerCRUD.balanceinquiry(s[currentindex]);
            }

            else if (option == "5")
            {
                menuCRUD.printheading(" Edit/Change my account");
                string userpassword = customerCRUD.getpassowrd();
                if (userpassword == s[currentindex].getterpassword())
                {
                    customerCRUD.accountinquiry(s[currentindex]);
                    customerCRUD.preesanykey();
                    menuCRUD.printheading(" Edit/Change my account");
                    string option2 = menuCRUD.optiontochanheuser();
                    menuCRUD.printheading(" Edit/Change my account");
                    if (option2 == "1")
                    {
                        string name = customerCRUD.addnametogetedit();
                        s[currentindex].usereditname(name);
                    }
                    if (option2 == "2")
                    {
                        string password = customerCRUD.getpasswordforedit();
                        s[currentindex].usereditpassword(password);
                    }
                    if (option2 == "3")
                    {
                        string type = customerCRUD.inputtypeforedit();
                        s[currentindex].useredittype(type);
                    }
                    if (option2 == "4")
                    {
                        user obj5 = customerCRUD.editall();
                        s[currentindex].usereditaccountmenu( obj5);
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "6")
            {
                menuCRUD.printheading(" Transfer Money to other Account");
                string password = customerCRUD.getpassowrd();
                if (password == s[currentindex].getterpassword())
                {
                    menuCRUD.printheading(" Transfer Money to other Account");
                    customerCRUD.accountinquiry(s[currentindex]);
                    customerCRUD.keytocnotinuetransfer();
                    menuCRUD.printheading(" Transfer Money to other Account");
                    customer cred = customerCRUD.getcredientialfortransfer();
                    bool checkcredit = s[currentindex].checkamountavailability(cred.getterbalances() );
                    if (checkcredit)
                    {
                        bool Isfound;
                        Isfound = tranfermoney(cred);
                        if (Isfound == true)
                        {
                            s[currentindex].setbalances(s[currentindex].getterbalances() - cred.getterbalances());
                            transfermoneytoother(s, cred);
                        }
                        if (Isfound == false)
                        {
                            customerCRUD.notfound();
                        }
                    }
                    else
                    {
                        customerCRUD.insufficientbal();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "7")
            {
                menuCRUD.printheading(" Apply for Loan");
                customer linput = customerCRUD.inputforloan();
                string valid;
                valid = s[currentindex].applyforloan(linput );
                if (valid == "true")
                {
                    menuCRUD.printheading(" Apply for Loan");
                    loan obj = customerCRUD.inputforloanamount();
                    s[currentindex].saveloandetails(obj, s[currentindex], ref bankbalance);
                    customerCRUD.successfuloan();
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "8")
            {
                menuCRUD.printheading(" Apply for Insurance");
                customer obj = customerCRUD.inputfoeinsurance();
                if (s[currentindex].gettername() == obj.gettername() && s[currentindex].getterpassword() == obj.getterpassword() && s[currentindex].getteraccountnumbers() == obj.getteraccountnumbers())
                {
                    menuCRUD.printheading(" Apply for Insurance");
                    insurance data = customerCRUD.getinputforinsurance();
                    if (data.getterinstallments() == "Monthly" || data.getterinstallments() == "monthly" || data.getterinstallments() == "Quarterly" || data.getterinstallments() == "quarterly" || data.getterinstallments() == "Half yearly" || data.getterinstallments() == "Half Yearly" || data.getterinstallments() == "half yearly" || data.getterinstallments() == "yearly" || data.getterinstallments() == "Yearly")
                    {
                        s[currentindex].applyforinsurance(data);
                        customerCRUD.successfulinsurance();
                    }
                    else
                    {
                        customerCRUD.incorrectdetails();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "9")
            {
                menuCRUD.printheading(" Payable");
                user input = customerCRUD.inputforpayable();
                if (s[currentindex].gettername() == input.gettername() && s[currentindex].getterpassword() == input.getterpassword())
                {
                    menuCRUD.printheading(" Payable");
                    int amount = customerCRUD.inputamountforpayable();
                    bool ischeck = s[currentindex].checkamountavailability(amount);
                    if (ischeck)
                    {
                        s[currentindex].payable(amount);
                        customerCRUD.successfullybillpayyed();
                    }
                    else
                    {
                        customerCRUD.insufficientbal();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "10")
            {
                menuCRUD.printheading(" Account Holder's Details");
                customerCRUD.accountholderdetail(s[currentindex]);
            }

            else if (option == "11")
            {
                menuCRUD.printheading(" Return loan");
                string password = customerCRUD.getpasswordforuser();
                if (s[currentindex].getterpassword() == password)
                {
                    menuCRUD.printheading(" Return loan");
                    int value = s[currentindex].getterloans();
                    if (value != 0)
                    {
                        customerCRUD.accountdetailsloans(s[currentindex]);
                        int returnloanamount = customerCRUD.amounttoreturn();
                        s[currentindex].returnloan(returnloanamount);
                        if ((value < 0))
                        {
                            value = 0;
                        }
                        customerCRUD.remainingloan(s[currentindex].getterloans());
                    }
                    else
                    {
                        customerCRUD.nohistory();
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
            }

            else if (option == "12")
            {
                menuCRUD.printheading(" Complains");
                string option3 = menuCRUD.complianmenu();
                if (option3 == "1")
                {
                    menuCRUD.printheading(" Submit my Complain");
                    customerCRUD.submitcomplain(s[currentindex]);
                    customerCRUD.successfullucomplain();
                }
                else if (option3 == "2")
                {
                    menuCRUD.printheading(" Remove my Complain");
                    string password = customerCRUD.getpasswordforuser();
                    if (password == s[currentindex].getterpassword())
                    {
                        customerCRUD.removecomplains();
                        customerCRUD.resetcomplain(s[currentindex]);
                    }
                    else
                    {
                        adminCRUD.incorrentcredi();
                    }
                }
            }

            else if (option == "13")
            {
                menuCRUD.printheading(" Delete my account");
                customer input = customerCRUD.inputfoeinsurance();
                if (s[currentindex].gettername() == input.gettername() && s[currentindex].getterpassword() == input.getterpassword() && s[currentindex].getteraccountnumbers() == input.getteraccountnumbers())
                {
                    menuCRUD.printheading(" Delete my account");
                    char option4 = customerCRUD.confirmation();
                    if (option4 == 'Y')
                    {
                        deletemyaccount(ref currentindex);
                        customerCRUD.suucessfullydelte();
                        string n = "0";
                        return n;
                    }
                }
                else
                {
                    adminCRUD.incorrentcredi();
                }
                savedata();
                savedataforadmin();
            }

            else if (option == "0")
            {
                string n = "0";
                return n;
            }
            else
            {
                adminCRUD.invalidchoice();
            }

            savedata();
            savedataforadmin();
            return "1";
        }

        //   file handling
        public static bool loaddataforadmin()
        {
            string path = "recorda.txt";
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record = filevariable.ReadLine();
                if (record != null)
                {
                    string[] temp = record.Split(',');
                      admin obj = new admin(temp[0], temp[1],temp[2],temp[3]);
                      adddataintolist(obj);
                    filevariable.Close();
                    return true;
                }
                filevariable.Close();
            }

            return false;
        }
        public static void savedataforadmin()
        {
            string path = "recorda.txt";
            StreamWriter file = new StreamWriter(path, false);
            if (s.Count != 0)
            {
                file.Write(s[0].gettername() + ",");
                file.Write(s[0].getterpassword()+ ",");
                file.Write(s[0].getterstattus() + ",");
                file.Write(s[0].getterrole());
            }

            file.Close();
        }
        public static bool loaddata()
        {
            string path = "record.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] temp = record.Split(',');
                    loan l = new loan(int.Parse(temp[5]), temp[6], temp[7]);
                    freeze f = new freeze(temp[11], int.Parse(temp[12]));
                    insurance i = new insurance(int.Parse(temp[8]), int.Parse(temp[9]), temp[10]);
                    customer obj = new customer(temp[0], temp[1], temp[2], int.Parse(temp[3]), int.Parse(temp[4]), temp[13], temp[14], f, i, l);
                    adddataintolist(obj);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        public static void savedata()
        {
            string path = "record.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int index = 1; index < s.Count; index++)
            {
                file.Write(s[index].gettername() + ",");
                file.Write(s[index].getterpassword() + ",");
                file.Write(s[index].gettertypes() + ",");
                file.Write(s[index].getterbalances() + ",");
                file.Write(s[index].getteraccountnumbers() + ",");
                file.Write(s[index].getterloans() + ",");
                file.Write(s[index].getterissueloans() + ",");
                file.Write(s[index].getterlimitloans() + ",");
                file.Write(s[index].getterinsurances() + ",");
                file.Write(s[index].getterdurations() + ",");
                file.Write(s[index].getterinstallments() + ",");
                file.Write(s[index].getterstattus() + ",");
                file.Write(s[index].getterfdurations() + ",");
                file.Write(s[index].gettercomplains() + ",");
                file.WriteLine(s[index].getterrole());
            }
            file.Close();
        }
    }

}
