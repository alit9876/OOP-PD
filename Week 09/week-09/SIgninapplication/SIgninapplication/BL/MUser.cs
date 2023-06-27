using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIgninapplication.BL
{
    class MUser
    {
        private string usernmae;
        private string password;
        private string role;
        public MUser(string name, string password, string role)
        {
            this.usernmae = name;
            this.password = password;
            this.role = role;
        }
        public MUser(string nmae, string password)
        {
            this.usernmae = nmae;
            this.password = password;
            this.role = "N/A";
        }
        public string getname()
        {
            return usernmae;
        }
        public void setname(string name)
        {
            this.usernmae = name;
        }
        public string getpassword()
        {
            return password;
        }
        public string getrole()
        {
            return role;
        }
        public bool isAdmin()
        {
            if (role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
