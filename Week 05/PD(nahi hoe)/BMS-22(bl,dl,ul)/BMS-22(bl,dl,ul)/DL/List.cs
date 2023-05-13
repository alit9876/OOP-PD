using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BMS_22_bl_dl_ul_.BL;
using BMS_22_bl_dl_ul_.UL;

namespace BMS_22_bl_dl_ul_.DL
{
    class List1
    {
        public static List<data> s = new List<data>();
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
        public static string signup(data obj)
        {
            string Isfound = "false";
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == obj.names)
                {
                    Isfound = "true";
                }
            }
            return Isfound;
        }
        public static data setacrole(data obj)
        {
            if (s.Count != 0)
            {
                obj.accountnumbers = s[s.Count - 1].accountnumbers + 1;
                obj.role = "User";
            }
            if (s.Count == 0)
            {
                obj.accountnumbers = 0;
                obj.role = "admin";
            }
            return obj;
        }
        public static void adddataintolist(data obj)
        {
            s.Add(obj);
        }
        public static int listcount()
        {
            int count = s.Count;
            return count;
        }
        public static data signIn(data signin, ref int currentindex)
        {
            int count = 0;
            foreach (data storedUser in s)
            {
                if (signin.names == storedUser.names && signin.passwords == storedUser.passwords)
                {
                    currentindex = count;
                    return storedUser;
                }
                count++;
            }
            return null;
        }
        public static string signinf( int currentindex)
        {
            string value = s[currentindex].fdata.status;
            return value;
        }
        public static string returnrole(int currentindex)
        {
            string role = s[currentindex].role;
            return role;
        }
        public static int searchaccountforuuserdata(string name)
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
        public static int printsearchaccountdata(string name)
        {
            int pos = 0;
            for (int position = 1; position < s.Count; position++)
            {
                if (s[position].names == name)
                {
                    pos = position;
                }
            }
            return pos;
        }
        public static int searchaccount(data obj)
        {
            int position = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == obj.names && s[index].passwords == obj.passwords)
                {
                    position = index;
                }
            }
            return position;
        }
        public static void freezeueraccount(int duration, int pos)
        {
            s[pos].fdata.status = "Freeze";
            s[pos].fdata.fdurations = duration;
        }
        public static void changebothadmin(data obj)
        {
            s[0].names = obj.names;
            s[0].passwords = obj.passwords;
        }
        public static void providingloan(loan obj,int currentindex, ref int bankbalance)
        {
            s[currentindex].ldata.loans = obj.loans;
            bankbalance = bankbalance - obj.loans;
            s[currentindex].ldata.issueloans = obj.issueloans;
            s[currentindex].ldata.limitloans = obj.limitloans;
        }
        public static int numberofloanpayyed()
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].ldata.loans != 0)
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

                if (s[index].Idata.insurances != 0)
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
        public static bool checkinput(data obj)
        {
            bool found = false;
            for (int x = 0; x < s.Count; x++)
            {
                if (s[x].names == obj.names && s[x].passwords == obj.passwords)
                {
                    found = true;
                }
            }
            return found;
        }
        public static int deleteuseraccount(data obj)
        {
            int position1 = 0;
            for (int index = 1; index < s.Count; index++)
            {

                if (s[index].names == obj.names && s[index].passwords == obj.passwords)
                {
                    s[index].names = "";
                    s[index].passwords = "";
                    s[index].accountnumbers = 0;
                    s[index].types = "";
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
                if (s[x].complains != "No Complain")
                {
                    number++;
                }
            }
            return number;
        }

        //  user
        public static void depositmoney(int deposit, data obj)
        {
            obj.balances = obj.balances + deposit;
        }
        public static void withdraw(int withdrew, data obj)
        {
            obj.balances = obj.balances - withdrew;
        }
        public static bool checkamountavailability(int amount,data obj)
        {
            bool ischeck = false;
            if (obj.balances >= amount)
            {
                ischeck = true;
            }
            return ischeck;
        }
        public static void usereditname(string name,data obj)
        {
            obj.names = name;
        }
        public static void usereditaccountmenu(data s, data obj)
        {
            s.names = obj.names;
            s.passwords = obj.passwords;
            s.types = obj.types;
        }
        public static void usereditpassword(string password, data obj)
        {
            obj.passwords = password;
        }
        public static void useredittype(string type, data obj)
        {
            obj.types = type;
        }
        public static bool tranfermoney(data cred)
        {
            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].names == cred.names && s[index].accountnumbers == cred.accountnumbers)
                {
                    return true;
                }
            }
            return false;
        }
        public static void payable(data obj,int amount)
        {
            obj.balances = obj.balances - amount;
        }
        public static void deletemyaccount( ref int currentindex)
        {
            s.RemoveAt(currentindex);
        }
        //   admin funtionality
        public static string adminfunctionality(string option, ref int currentindex, ref int bankbalance)
        {

            if (option == "1")
            {
                menuCRUD.printheading(" Account holders masterlist");
                dataCRUD.headeradminop1();
                for (int index = 1; index < s.Count; index++)
                {
                    dataCRUD.masterlist(s[index]);
                }
            }

            else if (option == "2")
            {
                data check = new data();
                menuCRUD.printheading(" Search for Specific Account");
                string name = dataCRUD.getinputforop2();
                int position = searchaccountforuuserdata(name);
                if (position != 0)
                {
                    menuCRUD.printheading(" Search for Specific Account");
                    int pos = printsearchaccountdata(name);
                    dataCRUD.accountholderdetail(s[pos]);
                }
                else
                {
                    dataCRUD.notfound2();
                }
            }

            else if (option == "3")
            {
                menuCRUD.printheading(" Freeze User's Account");
                data search = FCRUD.inputforop3(); 
                int position = searchaccount(search);
                if (position != 0)
                {
                    menuCRUD.printheading(" Freeze User's Account");
                    int duration = FCRUD.freezedur();
                    freezeueraccount(duration, position);
                    FCRUD.freezedisplay(s[position].fdata.fdurations);
                }
                else
                {
                    dataCRUD.notfound2();
                }
            }

            else if (option == "4")
            {
                menuCRUD.printheading(" Edit/Change my account");
                string password = dataCRUD.passowrd();
                string newname;
                string newpassword;
                if (s[0].passwords == password)
                {
                    string option1;
                    menuCRUD.printheading(" Edit/Change my account");
                    option1 = menuCRUD.changeadminoption();
                    if (option1 == "1")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        newname = dataCRUD.newnameadmin();
                        s[0].names = newname;
                    }
                    if (option1 == "2")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        newpassword = dataCRUD.newpasswordadmin();
                        s[0].passwords = newpassword;
                    }
                    if (option1 == "3")
                    {
                        menuCRUD.printheading(" Edit/Change my account");
                        data obj = dataCRUD.editbothadmin();
                        changebothadmin(obj);
                        dataCRUD.updatedadmin();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "5")
            {
                menuCRUD.printheading("Check Bank's Available Balance ");
                dataCRUD.bankbalanceavailable(ref bankbalance);
            }

            else if (option == "6")
            {
                data check = new data();
                menuCRUD.printheading(" Give loan to User");
                string name =lCRUD.nameforloanadmin();
                int position = searchaccountforuuserdata(name);
                if (position != 0)
                {
                    menuCRUD.printheading(" Give loan to User");
                    loan obj = lCRUD.givingloan();
                    providingloan(obj,position, ref bankbalance);
                    lCRUD.givingloanadmin(s[position].balances);
                }
                else
                {
                    dataCRUD.notfound2();
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
                        int value = s[index].ldata.loans;
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
                int amount = dataCRUD.inputforfunds();
                bool ischeck = providesfunds(amount, ref bankbalance);
                if (ischeck)
                {
                    dataCRUD.successfullyfunds();
                }
                else
                {
                    dataCRUD.notprovidefund();
                }
            }

            else if (option == "10")
            {
                menuCRUD.printheading(" UnFreeze User's Account");
                string password;
                Console.Write(" Enter your account password: ");
                password = Console.ReadLine();
                if (s[0].passwords == password)
                {
                    menuCRUD.printheading(" UnFreeze User's Account");
                    data obj3 = FCRUD.unfreezeinput();
                    bool ischeck = freeze.unfreezeaccount(obj3, s);
                    if (ischeck)
                    {
                        FCRUD.succesfulunfreeze();
                    }
                    else
                    {
                        dataCRUD.notfound2();
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
                string password = dataCRUD.inputpassword();
                if (s[0].passwords == password)
                {
                    menuCRUD.printheading(" Delete Account");
                    data obj = dataCRUD.inputpasswordfordelete();
                    bool found = checkinput(obj); 
                    if (found)
                    {
                        data del = new data();
                        int position = deleteuseraccount(obj);
                        dataCRUD.successfullydelete(s[position].balances);
                        s.RemoveAt(position);
                    }
                    else
                    {
                        dataCRUD.deleteincorect();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "12")
            {
                menuCRUD.printheading(" See all Complains");
                int complain = numberofcomplains();
                if (complain > 0)
                {
                    dataCRUD.headercomplains();
                    for (int index = 1; index < s.Count; index++)
                    {
                        dataCRUD.seeallcomplains(s[index], index);
                    }
                }
                else if (complain == 0)
                {
                    dataCRUD.notcomplainreg();
                }
            }

            else if (option == "0")
            {
                string n = "0";
                return n;
            }

            else
            {
                dataCRUD.invalidchoice();
            }

           savedata();
            return "1";
        }

        //   user fuctionality 
        public static string userfunctionality(string option, ref int currentindex, ref int bankbalance)
        {
            if (option == "1")
            {
                Console.Clear();
                menuCRUD.header();
                menuCRUD.printheading(" Create a new account");
                data obj = dataCRUD.takeinputforsignup();
                string Isvalid;
                bool isName;
                isName = namecheck(obj.names);
                if (isName)
                {
                    bool passwordvalidity = passwordvalid(obj.passwords);
                    if (passwordvalidity)
                    {
                        Isvalid = signup(obj);
                        if (Isvalid == "false")
                        {
                            adddataintolist(setacrole(obj));
                            menuCRUD.loading();
                        }

                        if (Isvalid == "true")
                        {
                            dataCRUD.alreadyexit();
                        }
                    }
                    else
                    {
                        dataCRUD.passwordshot();
                    }
                }
                else
                {
                    dataCRUD.nameingerror();
                }

                menuCRUD.clear();
            }

            else if (option == "2")
            {
                menuCRUD.printheading(" Deposit money");
                int accountnumber = userCRUD.accountnumberinput();
                if (s[currentindex].accountnumbers == accountnumber)
                {
                    menuCRUD.printheading(" Deposit money");
                    int deposit = userCRUD.depositinputamount(s[currentindex].balances);
                    depositmoney(deposit, s[currentindex]);
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "3")
            {
                menuCRUD.printheading(" With draw money");
                int accountnumber = userCRUD.accountnumberinput();
                menuCRUD.printheading(" Withdraw Money");
                if (s[currentindex].accountnumbers == accountnumber)
                {
                    int withdrew = userCRUD.inputforwithdranw(s[currentindex].balances);
                    bool availability = checkamountavailability(withdrew, s[currentindex]);
                    if (availability)
                    {
                        withdraw(withdrew, s[currentindex]);
                        userCRUD.successfullywithdrew();
                    }
                    else
                    {
                        userCRUD.insufficientbal();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "4")
            {
                menuCRUD.printheading(" Balance Inquiry ");
                userCRUD.balanceinquiry(s[currentindex]);
            }

            else if (option == "5")
            {
                menuCRUD.printheading(" Edit/Change my account");
                string userpassword = userCRUD.getpassowrd();
                if (userpassword == s[currentindex].passwords)
                {
                    userCRUD.accountinquiry(s[currentindex]);
                    userCRUD.preesanykey();
                    menuCRUD.printheading(" Edit/Change my account");
                    string option2 = menuCRUD.optiontochanheuser();
                    menuCRUD.printheading(" Edit/Change my account");
                    if (option2 == "1")
                    {
                        string name = userCRUD.addnametogetedit();
                        usereditname(name,s[currentindex]);
                    }
                    if (option2 == "2")
                    {                     
                        string password = userCRUD.getpasswordforedit();
                        usereditpassword(password, s[currentindex]);
                    }
                    if (option2 == "3")
                    {
                        string type = userCRUD.inputtypeforedit();
                        useredittype(type, s[currentindex]);
                    }
                    if (option2 == "4")
                    {
                        data obj5 = userCRUD.editall();
                        usereditaccountmenu(s[currentindex], obj5);
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "6")
            {
                menuCRUD.printheading(" Transfer Money to other Account");
                string password = userCRUD.getpassowrd();
                if (password == s[currentindex].passwords)
                {
                    menuCRUD.printheading(" Transfer Money to other Account");
                    userCRUD.accountinquiry(s[currentindex]);
                    userCRUD.keytocnotinuetransfer();
                    menuCRUD.printheading(" Transfer Money to other Account");
                    data cred = userCRUD.getcredientialfortransfer();
                    bool checkcredit = checkamountavailability(cred.balances, s[currentindex]);
                    if (checkcredit)
                    {
                        bool Isfound;
                        Isfound = tranfermoney(cred);
                        if (Isfound == true)
                        {
                            s[currentindex].balances = s[currentindex].balances - cred.balances;
                            userCRUD.transfermoneytoother(s, cred);
                        }
                        if (Isfound == false)
                        {
                            userCRUD.notfound();
                        }
                    }
                    else
                    {
                        userCRUD.insufficientbal();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "7")
            {
                menuCRUD.printheading(" Apply for Loan");
                data linput = userCRUD.inputforloan();
                string valid;
                valid = loan.applyforloan(linput,s[currentindex]);
                if (valid == "true")
                {
                    menuCRUD.printheading(" Apply for Loan");
                    loan obj = userCRUD.inputforloanamount();
                    loan.saveloandetails(obj,s[currentindex], ref bankbalance);
                    userCRUD.successfuloan();
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "8")
            {
                menuCRUD.printheading(" Apply for Insurance");
                data obj = userCRUD.inputfoeinsurance();
                if (s[currentindex].names == obj.names && s[currentindex].passwords == obj.passwords && s[currentindex].accountnumbers == obj.accountnumbers)
                {
                    menuCRUD.printheading(" Apply for Insurance");
                    insurance data = userCRUD.getinputforinsurance();
                    if (data.installments == "Monthly" || data.installments == "monthly" || data.installments == "Quarterly" || data.installments == "quarterly" || data.installments == "Half yearly" || data.installments == "Half Yearly" || data.installments == "half yearly" || data.installments == "yearly" || data.installments == "Yearly")
                    {
                        insurance.applyforinsurance(data,s[currentindex]);
                        userCRUD.successfulinsurance();
                    }
                    else
                    {
                        userCRUD.incorrectdetails();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "9")
            {
                menuCRUD.printheading(" Payable");
                data input = userCRUD.inputforpayable();
                if (s[currentindex].names == input.names && s[currentindex].passwords == input.passwords)
                {
                    menuCRUD.printheading(" Payable");
                    int amount = userCRUD.inputamountforpayable();
                    bool ischeck = checkamountavailability(amount, s[currentindex]);
                    if (ischeck)
                    {
                        payable(s[currentindex],amount);
                        userCRUD.successfullybillpayyed();
                    }
                    else
                    {
                        userCRUD.insufficientbal();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "10")
            {
                menuCRUD.printheading(" Account Holder's Details");
                userCRUD.accountholderdetail(s[currentindex]);
            }

            else if (option == "11")
            {
                menuCRUD.printheading(" Return loan");
                string password = userCRUD.getpasswordforuser();
                if (s[currentindex].passwords == password)
                {
                    menuCRUD.printheading(" Return loan");
                    int value = s[currentindex].ldata.loans;
                    if (value != 0)
                    {
                        userCRUD.accountdetailsloans(s[currentindex]);
                        int returnloanamount = userCRUD.amounttoreturn();
                        loan.returnloan(returnloanamount, s[currentindex]);
                        if ((value < 0))
                        {
                            value = 0;
                        }
                        userCRUD.remainingloan(s[currentindex].ldata.loans);
                    }
                    else
                    {
                        userCRUD.nohistory();
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
            }

            else if (option == "12")
            {
                menuCRUD.printheading(" Complain");
                menuCRUD.printheading(" Complains");
                string option3 = menuCRUD.complianmenu();
                if (option3 == "1")
                {
                    menuCRUD.printheading(" Submit my Complain");
                    userCRUD.submitcomplain(s[currentindex]);
                    userCRUD.successfullucomplain();
                }
                else if (option3 == "2")
                {
                    menuCRUD.printheading(" Remove my Complain");
                    string password = userCRUD.getpasswordforuser();
                    if (password == s[currentindex].passwords)
                    {
                        userCRUD.removecomplains();
                        userCRUD.resetcomplain(s[currentindex]);
                    }
                    else
                    {
                        dataCRUD.incorrentcredi();
                    }
                }
            }

            else if (option == "13")
            {
                menuCRUD.printheading(" Delete my account");
                data input = userCRUD.inputfoeinsurance();
                if (s[currentindex].names == input.names && s[currentindex].passwords == input.passwords && s[currentindex].accountnumbers == input.accountnumbers)
                {
                    menuCRUD.printheading(" Delete my account");
                    char option4 = userCRUD.confirmation();
                    if (option4 == 'Y')
                    {
                        deletemyaccount(ref currentindex);
                        userCRUD.suucessfullydelte();
                        string n = "0";
                        return n;
                    }
                }
                else
                {
                    dataCRUD.incorrentcredi();
                }
                savedata();
            }

            else if (option == "0")
            {
                string n = "0";
                return n;
            }
            else
            {
                dataCRUD.invalidchoice();
            }

            savedata();
            return "1";
        }

        //   file handling
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
                    loan l = new loan(int.Parse(temp[5]),temp[6],temp[7]);
                    freeze f = new freeze(temp[11],int.Parse(temp[12]));
                    insurance i = new insurance(int.Parse(temp[8]),int.Parse(temp[9]),temp[10]);
                    data obj = new data(temp[0],temp[1],temp[2],int.Parse(temp[3]),int.Parse(temp[4]),temp[13],temp[14],f,i,l);
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
            for (int index = 0; index < s.Count; index++)
            {
                file.Write(s[index].names + ",");
                file.Write(s[index].passwords + ",");
                file.Write(s[index].types + ",");
                file.Write(s[index].balances + ",");
                file.Write(s[index].accountnumbers + ",");
                file.Write(s[index].ldata.loans + ",");
                file.Write(s[index].ldata.issueloans + ",");
                file.Write(s[index].ldata.limitloans + ",");
                file.Write(s[index].Idata.insurances + ",");
                file.Write(s[index].Idata.durations + ",");
                file.Write(s[index].Idata.installments + ",");
                file.Write(s[index].fdata.status + ",");
                file.Write(s[index].fdata.fdurations + ",");
                file.Write(s[index].complains + ",");
                file.WriteLine(s[index].role);
            }
            file.Close();
        }
    }
}
