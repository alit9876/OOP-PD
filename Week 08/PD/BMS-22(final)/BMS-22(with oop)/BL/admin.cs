using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.DL;
using BMS_22_with_oop_.UI;

namespace BMS_22_with_oop_.BL
{
    class admin: user
    {
        public admin(string name, string password) : base(name, password)
        {
            this.roles = "admin";
            this.fdata.setstatus("UnFreeze");
        }
        public admin(string name, string password, string status, string role) : base(name, password,role)
        {
            this.fdata.setstatus(status);
        }
        public override user takeinputforsignup()
        {
            admin obj = userCRUD.takeinputforsigupadmin();
            return obj;
        }
        public override string getterstattus()
        {
            return fdata.getstatus();
        }
        public override void setstatus(string status)
        {
            fdata.setstatus(status);
        }
    }
}
