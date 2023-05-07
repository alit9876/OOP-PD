using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMS_22.BL
{
    class insurance
    {
        public int insurances;
        public int durations;
        public string installments;
    }
    class loan
    {
        public int loans;
        public string issueloans;
        public string limitloans;
    }
     class freeze
    {
        public string status;
        public int fdurations;
    }

    class data
    {
         freeze fdata = new freeze();
        insurance idata = new insurance();
         loan ldata = new loan();
        public string names;
        public string passwords;
        public string types;
        public int balances;
        public int accountnumbers;
        public string complains;
        public string role;
        public data()
        {

        }
        public int rloan()
        {
            int loan = 0;
            loan = ldata.loans;
            return loan;
        }
        public void insertloandata(int loan, string limit, string issue)
        {
            ldata.loans = loan;
            ldata.limitloans = limit;
            ldata.issueloans = issue;
        }
        public int loanvalu(int loan)
        {
            loan = ldata.loans;
            return loan;
        }
        public void returnloan(ref int loan, ref string issuelaons, ref string limitloan)
        {
            loan = ldata.loans;
            issuelaons = ldata.issueloans;
            limitloan = ldata.limitloans;
        }
        public void insertinsurancedata(int insu, int du, string installment)
        {
            idata.insurances = insu;
            idata.durations = du;
            idata.installments = installment;
        }
        public void retruninsurance(ref int insu, ref int du, ref string installment)
        {
            insu = idata.insurances;
            du = idata.durations;
            installment = idata.installments;
        }
        public data(string name, string password, string type, int balance)
        {
            this.names = name;
            this.passwords = password;
            this.types = type;
            this.balances = balance;
            this.complains = "No Complain";
            fdata.status = "UnFreeze";
        }
        public string freezestatus()
        {
            string sat;
            sat = fdata.status;
            return sat;
        }
        public int freezeduration()
        {
            int sat;
            sat = fdata.fdurations;
            return sat;
        }
        public void insertfreezedata(string role, int fd)
        {
            fdata.status = role;
            fdata.fdurations = fd;
        }
        public void returnfreeze(ref string role, ref int fd) 
            {
             role = fdata.status;
             fd = fdata.fdurations;
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
        
        //           user functionailty
        public void saveloandetails (string issueloan, string limitloan, int loan, ref int bankbalance)
        {
            ldata.loans = loan;
            ldata.issueloans = issueloan;
            ldata.limitloans = limitloan;
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
            idata.insurances = insurance;
            idata.durations = duration;
            idata.installments = installment;
        }
        public void payable(int amount)
        {
            balances = balances - amount;
        } 
        public void returnloan(int returnloan)
        {
            balances = balances - returnloan;
            ldata.loans = ldata.loans - returnloan;
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
        
        //       admin functionailty

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
        public int printsearchaccountdata(string name, List<data> s)
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
        public void freezeueraccount(int duration)
        {
            fdata.status = "Freeze";
            fdata.fdurations = duration;
        }
        public void editmanagerboth(string newname, string newpassword)
        {
            names = newname;
            passwords = newpassword;
        }
        public void providingloan(int amount, string issue, string limit, ref int bankbalance)
        {
            ldata.loans = amount;
            bankbalance = bankbalance - amount;
            ldata.issueloans = issue;
            ldata.limitloans = limit;
        }
        public int numberofloanpayyed(List<data> s)
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
        public int numberofinsurancepayyed(List<data> s)
        {
            int number = 0;
            for (int index = 1; index < s.Count; index++)
            {
                
                if (s[index].idata.insurances != 0)
                {
                    number++;
                }
            }
            return number;
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
                    s[index].fdata.status = "UnFreeze";
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
                    s[index].types = "";
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
