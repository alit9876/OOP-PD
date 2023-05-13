using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22_bl_dl_ul_.BL
{
    class data
    {
        public string names;
        public string passwords;
        public string types;
        public int balances;
        public int accountnumbers;
        public string complains;
        public string role;
        public insurance Idata = new insurance();
        public loan ldata = new loan();
        public  freeze fdata = new freeze();
        public data()
        {

        }
        public data(string name, string password,string type)
        {
            this.names = name;
            this.passwords = password;
            this.types = type;
        }
        public data(string name, int accountnumber)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
        }
        public data(string name,string password, int accountnumber)
        {
            this.names = name;
            this.passwords = password;
            this.accountnumbers = accountnumber;
        }
        public data(string name, int accountnumber,int balance)
        {
            this.names = name;
            this.accountnumbers = accountnumber;
            this.balances = balance;
        }
        public data(string name,string password,string type,int balance,int accountnumber,string comp,string role,freeze f, insurance i, loan l)
        {
            this.names = name;
            this.types = type;
            this.balances = balance;
            this.passwords = password;
            this.accountnumbers = accountnumber;
            this.complains = comp;
            this.role = role;
            Idata = i;
            fdata = f;
            ldata = l;
        }
        public data(string name, string password)
        {
            this.names = name;
            this.passwords = password;
        }
        public data(string name, string password, string type, int balance)
        {
            this.names = name;
            this.types = type;
            this.balances = balance;
            this.passwords = password;
            this.complains = "No Complain";
            fdata.status = "UnFreeze";

        }
    }
}
