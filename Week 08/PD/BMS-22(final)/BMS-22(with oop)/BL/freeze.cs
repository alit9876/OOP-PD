using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;
using System.Threading.Tasks;

namespace BMS_22_with_oop_.BL
{
    class freeze
    {
        private string status;
        private int fdurations;
        public freeze(string status, int dur)
        {
            this.status = status;
            this.fdurations = dur;
        }
        public freeze()
        {

        }
        public void setstatus(string status)
        {
            this.status = status;
        }
        public string getstatus()
        {
            return status;
        }
        public void setfdurations(int fdurations)
        {
            this.fdurations = fdurations;
        }
        public int getterfdurations()
        {
            return fdurations;
        }
        public static bool unfreezeaccount(customer obj, List<user> s)
        {
            bool ischeck = false;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].gettername() == obj.gettername() && s[index].getteraccountnumbers() == obj.getteraccountnumbers())
                {
                    s[index].setstatus("UnFreeze");
                    ischeck = true;
                    break;
                }
            }
            return ischeck;
        }
    }
}
