using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;

namespace BMS_22_with_oop_.BL
{
    class user
    {
        protected string names;
        protected string passwords;
        protected string roles;
        public user()
        {

        }
        public virtual user takeinputforsignup()
        {
            return new user();
        }
        public user(string name, string password, string role)
        {
            this.names = name;
            this.roles = role;
            this.passwords = password;
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
        public void setrole(string role)
        {
            this.roles = role;
        }
        public string getterrole()
        {
            return roles;
        }

        // customerr
        public virtual void setaccountnumbers(int accountnumber)
        {
            
        }
        public virtual int getteraccountnumbers()
        {
            return 0;
        }
        public virtual void settypes(string types)
        {
            
        }
        public virtual string gettertypes()
        {
            return "";
        }
        public virtual void setbalances(int balances)
        {
         
        }
        public virtual int getterbalances()
        {
            return 0;
        }
        
        public virtual void setcomplains(string complains)
        {
            
        }
        public virtual string gettercomplains()
        {
            return "";
        }

        //   freeze
        public virtual string getterstattus()
        {
            return "";
        }
        public  virtual void setstatus(string status)
        {
  
        }
        
        public virtual void setfdurations(int fdurations)
        {

         }
        public virtual int getterfdurations()
        {
            return 0;
        }
        // loan
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
            return "";
        }
        public virtual void setlimitloans(string limitloans)
        {
            
        }
        public virtual string getterlimitloans()
        {
            return "";
        }
        //   insurance
        public virtual void setinsurances(int insurance)
        {
            
        }
        public virtual int getterinsurances()
        {
            return 0;
        }
        public virtual void setdurations(int durations)
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
            return "";
        }
        public virtual void freezeueraccount(int duration)
        {
            
        }
        public virtual void changebothadmin(user obj)
        {
            setname(obj.gettername());
            setpassword(obj.getterpassword());
        }
        public virtual void providingloan(loan obj,ref int bankbalance)
        {
            
        }
        public virtual void depositmoney(int deposit)
        {

        }
        public virtual void withdraw(int withdrew)
        {
            setbalances(getterbalances() - withdrew);
        }
        public virtual bool checkamountavailability(int amount)
        {
            bool ischeck = false;
            if (getterbalances() >= amount)
            {
                ischeck = true;
            }
            return ischeck;
        }
        public virtual void usereditname(string name)
        {
            setname(name);
        }
        public virtual void usereditaccountmenu(user obj)
        {
            setname(obj.gettername());
            setpassword(obj.getterpassword());
            settypes(obj.gettertypes());
        }
        public virtual void usereditpassword(string password)
        {
            setpassword(password);
        }
        public virtual void useredittype(string type)
        {
            settypes(type);
        }
        public virtual string applyforloan(customer linput)
        {
            string valid = "false";
            return valid;
        }
        public virtual void saveloandetails(loan obj, user s, ref int bankbalance)
        {
            s.setloans(obj.getterloans());
            s.setissueloans(obj.getterissueloans());
            s.setlimitloans(obj.getterlimitloans());
            bankbalance = bankbalance - obj.getterloans();
        }
        public virtual void applyforinsurance(insurance obj)
        {
           
        }
        public virtual void payable( int amount)
        {
         
        }
        public virtual void returnloan(int returnloan)
        {
            
        }
    }
}
