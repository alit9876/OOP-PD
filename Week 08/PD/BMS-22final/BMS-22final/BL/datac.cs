using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22final.UI;
namespace BMS_22final.BL
{
    class datac : user
    {
        private string types;
        private int balances;
        private int accountnumbers;
        private string complains;
        private insurance Idata = new insurance();
        private loan ldata = new loan();
        private freeze fdata = new freeze();
        public datac()
        {
            
        }
        public override user takeinputforsignup()
        {
            datac obj = userCRUD.takeinputforsignup();
            return obj;
        }
        public datac(string name, string password, string type): base (name, password)
        {
            this.types = type;
        }
        public datac(string name, int accountnumber)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
        }
        public datac(string name, string password, int accountnumber): base(name, password)
        {
            this.accountnumbers = accountnumber;
        }
        public datac(string name, int accountnumber, int balance)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
            this.balances = balance;
        }
        public datac(string name, string password, string type, int balance, int accountnumber, string comp, string role, freeze f, insurance i, loan l): base (name, password)
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
        public datac(string name, string password) : base(name, password)
        {
            
        }
        public datac(string name, string password, string type, int balance): base(name, password)
        {
            this.balances = balance;
            this.passwords = password;
            this.complains = "No Complain";
            fdata.setstatus("UnFreeze");
        }
        public void settypes(string types)
        {
            this.types = types;
        }
        public string gettertypes()
        {
            return types;
        }
        public void setbalances(int balances)
        {
            this.balances = balances;
        }
        public int getterbalances()
        {
            return balances;
        }
        public void setaccountnumbers(int accountnumber)
        {
            this.accountnumbers = accountnumber;
        }
        public int getteraccountnumbers()
        {
            return accountnumbers;
        }
        public void setcomplains(string complains)
        {
            this.complains = complains;
        }
        public string gettercomplains()
        {
            return complains;
        }
       
    }
}
