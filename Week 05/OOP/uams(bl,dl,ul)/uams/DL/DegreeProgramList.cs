using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.UI;

namespace uams.DL
{
    class DegreeProgramList
    {
       
       public static List<DegreeProgram> programlist = new List<DegreeProgram>();

       public static void addIntoDegreeList(DegreeProgram d)
        {
            programlist.Add(d);
        }
        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram d in programlist)
            {
                if (d.degreeName == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
    }
}
