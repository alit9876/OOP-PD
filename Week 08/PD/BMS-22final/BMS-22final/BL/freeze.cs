using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22final.BL
{
    class freeze
    {
        protected string status;
        protected int fdurations;
        public freeze(string status, int dur)
        {
            this.status = status;
            this.fdurations = dur;
        }
        public freeze()
        {

        }
        public  void setstatus(string status)
        {
            this.status = status;
        }
        public   string getterstatus()
        {
            return status;
        }
        public   void setfdurations(int fdurations)
        {
            this.fdurations = fdurations;
        }
        public   int getterfdurations()
        {
            return fdurations;
        }
    }
}
