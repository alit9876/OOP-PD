using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22final.BL
{
    class user
    {
        protected string names;
        protected string passwords;
        protected string roles;
        public user()
        {

        }
        public user(string name, string password)
        {
            this.names = name;
            this.passwords = password;
        }
        public void setname(string name)
        {
            this.names = name;
        }
        public string gettername()
        {
            return names;
        }
        public void setpassword(string password)
        {
            this.passwords = password;
        }
        public string getterpassword()
        {
            return passwords;
        }
        public string getterrole()
        {
            return roles;
        }
        public void setroles(string role)
        {
            this.roles = role;
        }
        public virtual void settypes(string types)
        {
        
        }
        public virtual string gettertypes()
        {
            return " ";
        }
        public virtual void setbalances(int balances)
        {
           
        }
        public virtual int getterbalances()
        {
            return 0;
        }
        public virtual void setaccountnumbers(int accountnumber)
        {
           
        }
        public virtual int getteraccountnumbers()
        {
            return 0;
        }
        public virtual void setcomplains(string complains)
        {
            
        }
        public virtual string gettercomplains()
        {
            return " ";
        }
        public virtual user takeinputforsignup()
        {
            return new user();
        }

        //    getter and setter for freeze class
        public virtual void setstatus(string status)
        {

        }
        public virtual string getterstatus()
        {
            return " " ;
        }
        public virtual void setfdurations(int fdurations)
        {

        }
        public virtual int getterfdurations()
        {
            return 0;
        }

        //     getter and setter for loan
        public virtual void setloans(int loans)
        {
            
        }
        public virtual int getterloans()
        {
            return 0;
        }
        public virtual void setissueloans(string issueloans)
        {
            
        }
        public virtual string getterissueloans()
        {
            return" ";
        }
        public virtual void setlimitloans(string limitloans)
        {
            
        }
        public virtual string getterlimitloans()
        {
            return " ";
        }

        //    geeter and setter for insurance
        public virtual void setinsurances(int insurance)
        {
            
        }
        public virtual int getterinsurances()
        {
            return 0;
        }
        public virtual void setdurationins(int durations)
        {
            
        }
        public virtual int getterdurations()
        {
            return 0;
        }
        public virtual void setinstallments(string installment)
        {
           
        }
        public virtual string getterinstallments()
        {
            return " ";
        }

    }
}
