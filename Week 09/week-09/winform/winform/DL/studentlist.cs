using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.BL;

namespace winform.DL
{
    class studentlist
    {
        public static List<student> stdlist = new List<student>();
        public static void addstudent()
        {
            student s1 = new student();
            s1.name = "Ali";
            s1.fname = "Tariq";
            s1.marks = 555;
            student s2 = new student();
            s2.name = "Abd";
            s2.fname = "iftikhar";
            s2.marks = 55667;
            stdlist.Add(s1);
            stdlist.Add(s2);
        }
        public static List<student> GetStudent()
        {
            return stdlist;
        }
        
    }
}
