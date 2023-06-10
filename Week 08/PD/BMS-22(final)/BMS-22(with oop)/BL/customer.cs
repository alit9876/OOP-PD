using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;

namespace BMS_22_with_oop_.BL
{
    class customer: user
    {
        private string types;
        private int balances;
        private int accountnumbers;
        private string complains;
        private insurance Idata = new insurance();
        private loan ldata = new loan();
        private freeze fdata = new freeze();
        public customer()
        {

        }
        public customer(string name, string password, string type) : base(name, password)
        {
            this.types = type;
        }
        public customer(string name, int accountnumber)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
        }
        public customer(string name, string password, int accountnumber) : base(name, password)
        {
            this.accountnumbers = accountnumber;
        }
        public customer(string name, int accountnumber, int balance)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
            this.balances = balance;
        }
        public customer(string name, string password, string type, int balance, int accountnumber, string comp, string role, freeze f, insurance i, loan l) : base(name, password)
        {
            this.types = type;
            this.balances = balance;
            this.accountnumbers = accountnumber;
            this.complains = comp;
            this.roles = role;
            Idata = i;
            fdata = f;
            ldata = l;
        }
        public customer(string name, string password) : base(name, password)
        {

        }
        public override user takeinputforsignup()
        {
            customer obj = userCRUD.takeinputforsignup();
            return obj;
        }
        public customer(string name, string password, string type, int balance) : base(name, password)
        {
            this.balances = balance;
            this.passwords = password;
            this.complains = "No Complain";
            fdata.setstatus("UnFreeze");
        }
        public override void settypes(string types)
        {
            this.types = types;
        }
        public override string gettertypes()
        {
            return types;
        }
        public override void setbalances(int balances)
        {
            this.balances = balances;
        }
        public override int getterbalances()
        {
            return balances;
        }
        public override void setaccountnumbers(int accountnumber)
        {
            this.accountnumbers = accountnumber;
        }
        public override int getteraccountnumbers()
        {
            return accountnumbers;
        }
        public override void setcomplains(string complains)
        {
            this.complains = complains;
        }
        public override string gettercomplains()
        {
            return complains;
        }
        //     freeze
        public override string getterstattus()
        {
            return fdata.getstatus();
        }
        public override void setstatus(string status)
        {
            fdata.setstatus(status);
        }
        
        public override void setfdurations(int fdurations)
        {
            fdata.setfdurations(fdurations);
        }
        public override int getterfdurations()
        {
            return fdata.getterfdurations();
        }
        //    loan
        public override void setloans(int loans)
        {
            ldata.setloans(loans);
        }
        public override int getterloans()
        {
            return ldata.getterloans();
        }
        public override  void setissueloans(string issueloans)
        {
            ldata.setissueloans(issueloans);
        }
        public override string getterissueloans()
        {
            return ldata.getterissueloans();
        }
        public override void setlimitloans(string limitloans)
        {
            ldata.setlimitloans(limitloans);
        }
        public override string getterlimitloans()
        {
            return ldata.getterlimitloans();
        }

        // insurance
        public override void setinsurances(int insurance)
        {
            Idata.setinsurances(insurance);
        }
        public override int getterinsurances()
        {
            return Idata.getterinsurances();
        }
        public override void setdurations(int durations)
        {
            Idata.setdurations(durations);
        }
        public override int getterdurations()
        {
            return Idata.getterinsurances();
        }
        public override void setinstallments(string installment)
        {
            Idata.setinstallments(installment);
        }
        public override string getterinstallments()
        {
            return Idata.getterinstallments();
        }

        public override void freezeueraccount(int duration)
        {
            fdata.setstatus("Freeze");
            fdata.setfdurations(duration);
        }
        public override void providingloan(loan obj, ref int bankbalance)
        {
            ldata.setloans(obj.getterloans());
            bankbalance = bankbalance - obj.getterloans();
            ldata.setissueloans(obj.getterissueloans());
            ldata.setlimitloans(obj.getterlimitloans());
        }
        public override void depositmoney(int deposit)
        {
            setbalances(getterbalances() + deposit);
        }
        public override void withdraw(int withdrew)
        {
            setbalances(getterbalances() - withdrew);
        }
        public override bool checkamountavailability(int amount)
        {
            bool ischeck = false;
            if (getterbalances() >= amount)
            {
                ischeck = true;
            }
            return ischeck;
        }
        public override void usereditname(string name)
        {
            setname(name);
        }
        public override void usereditaccountmenu(user obj)
        {
            setname(obj.gettername());
            setpassword(obj.getterpassword());
            settypes(obj.gettertypes());
        }
        public override void usereditpassword(string password)
        {
            setpassword(password);
        }
        public override void useredittype(string type)
        {
            settypes(type);
        }
        public override string applyforloan(customer linput)
        {
            string valid = "false";
            if (linput.names == names && linput.passwords == passwords && linput.accountnumbers == accountnumbers)
            {
                valid = "true";
            }
            return valid;
        }
        public override void saveloandetails(loan obj, user s, ref int bankbalance)
        {
            s.setloans(obj.getterloans());
            s.setissueloans(obj.getterissueloans());
            s.setlimitloans(obj.getterlimitloans());
            bankbalance = bankbalance - obj.getterloans();
        }
        public override void applyforinsurance(insurance obj)
        {
            Idata.setinsurances(obj.getterinsurances());
            Idata.setdurations(obj.getterdurations());
            Idata.setinstallments(obj.getterinstallments());
        }
        public override void payable( int amount)
        {
            setbalances(getterbalances() - amount);
        }
        public override void returnloan(int returnloan)
        {
            balances = balances - returnloan;
            ldata.setloans( ldata.getterloans() - returnloan);
        }
    }
}
