using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22final.UI;

namespace BMS_22final.BL
{
    class admin : user
    {
        public admin(string name, string password): base (name, password)
        {
            this.roles = "Admin";
        }
        public override user takeinputforsignup()
        {
            admin obj = userCRUD.takeinputforsigupadmin();
            return obj;
        }
    }
}
