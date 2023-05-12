using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class DegreeProgramCRUD
    {
      public  static void viewdegreeprograme()
        {
            foreach (DegreeProgram dp in DegreeProgramList.programlist)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
        public static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.Write("Enter degree Name : ");
            degreeName = Console.ReadLine();
            Console.Write("Enter degree duration : ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter seats for degree  : ");
            seats = int.Parse(Console.ReadLine());
            DegreeProgram degprogram = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.Write("Enter how many subjects to enter : ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                degprogram.Addsubjet(SubjectCRUD.takeInputForSubject());
            }
            return degprogram;
        }
    }
}
