using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.UI;
namespace uams.DL
{
    class StudentList

    {
        public static List<Student> studentlist = new List<Student>();
        public static void addIntoStudentList(Student s)
        {
            studentlist.Add(s);
        }
        public static Student studentPresent(string name)
        {
            foreach (Student s in studentlist)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Student> sortbymerit()
        {
            List<Student> sortedsrudentinlist = new List<Student>();
            foreach (Student s in studentlist)
            {
                s.calculatemerit();
            }
            sortedsrudentinlist = studentlist.OrderByDescending(o => o.merit).ToList();
            return sortedsrudentinlist;
        }

        public static void giveadmission(List<Student> sortedsrudentinlist)
        {
            foreach (Student s in sortedsrudentinlist)
            {
                foreach (DegreeProgram d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
    }
}
