using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
using uams.UI;

namespace uams
{
    class Program
    {
        static void Main()
        {
            Menu.clearScreen();
            while (true)
            {
                string op = Menu.menu();
                if (op == "1")
                {
                    if (DegreeProgramList.programlist.Count > 0)
                    {
                        Student s = StudentCRUD.takeInputforStudent();
                        StudentList.addIntoStudentList(s);
                    }
                }
                else if (op == "2")
                {
                    DegreeProgram d = DegreeProgramCRUD.takeInputForDegree();
                    DegreeProgramList.addIntoDegreeList(d);
                }
                else if (op == "3")
                {
                    List<Student> sortedstudentlsit = new List<Student>();
                    sortedstudentlsit = StudentList.sortbymerit();
                    StudentList.giveadmission(sortedstudentlsit);
                    StudentCRUD.printstudents();
                }
                else if (op == "4")
                {
                    StudentCRUD.viewRegisteredstudent();
                }
                else if (op == "5")
                {
                    string degreename;
                    Console.Write("Enter Degree Name :");
                    degreename = Console.ReadLine();
                    StudentCRUD.viewstudentindegree(degreename);
                }
                else if (op == "6")
                {
                    Console.Write("Enter the Student Name : ");
                    string name = Console.ReadLine();
                    Student s = StudentList.studentPresent(name);
                    if (s != null)
                    {
                        SubjectCRUD.viewsubject(s);
                        SubjectCRUD.registerSubjects(s);
                    }
                }
                else if (op == "7")
                {
                    StudentCRUD.calculatefeeforALl();
                }
                else if (op == "8")
                {
                    Environment.Exit(0);
                }
            }
            Menu.clearScreen();
            Console.ReadLine();

        }
    }
}

