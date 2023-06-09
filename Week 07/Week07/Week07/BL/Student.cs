using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class Student
    {
        public  string name;
        public string session;
        public bool isdayscholar;
        public int entrytestM;
        public int HSmark;
        public double calmerit()
        {
            double merit = 0;
            return merit;
        }
    }
    class Hostilde : Student
    {
        public int roomnumber;
        public bool isfridge;
        public bool isinternetavailable;
        public double calhostelfee()
        {
            double fee = 0;
            return fee;
        }
    }
    class Dayscholar : Student
    {
        public string pickuppiont;
        public int busno;
        public int pickupdistance;
        public double calbusfee()
        {
            double fee = 0;
            return fee;
        }
    }


}
