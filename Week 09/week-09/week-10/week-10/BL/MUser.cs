using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_10.BL
{
    public class MUser
    {
        private string username;
        private string userpassword;
        private string userrole;
        public string UserName { get => username; set => username = value; }
        public string UserPassword { get => userpassword; set => userpassword = value; }
        public string UserRole { get => userrole; set => userrole = value; }
        public MUser(string name, string password, string role)
        {
            this.username = name;
            this.userpassword = password;
            this.userrole = role;
        }
        public MUser(string name, string password)
        {
            this.username = name;
            this.userpassword = password;
            this.UserRole = "N/A";
            this.UserRole = userrole;
        }
        public string getusername()
        {
            return username;
        }
        public string getpassword()
        {
            return userpassword;
        }
        public string getuserrole()
        {
            return userrole;
        }
        public bool isAdmin()
        {
            if(userrole == "Admin")
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
