using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.BL;

namespace lab6
{
    class Program
    {
        static List<Student> studentlist = new List<Student>();
        static List<DegreeProgram> programlist = new List<DegreeProgram>();
        static void Main()
        {
            string option;
            do
            {
                option = Menu();
                clear();
                if (option == "1")
                {
                    if (programlist.Count > 0)
                    {
                        Student s = takeInputforStudent();
                        addIntoStudentList(s);
                    }
                }
                else if (option == "2")
                {
                    DegreeProgram d = takeInputForDegree();
                    addIntoDegreeList(d);
                }
                else if (option == "3")
                {
                    List<Student> sortedstudentlsit = new List<Student>();
                    sortedstudentlsit = sortbymerit();
                    giveadmission(sortedstudentlsit);
                    printstudents();
                }
                else if (option == "4")
                {
                    viewRegisteredstudent();
                }
                else if (option == "5")
                {
                    string degreename;
                    Console.Write("Enter Degree Name :");
                    degreename = Console.ReadLine();
                    viewstudentindegree(degreename);
                }
                else if (option == "6")
                {
                    Console.Write("Enter the Student Name : ");
                    string name = Console.ReadLine();
                    Student s = studentPresent(name);
                    if (s != null)
                    {
                        viewsubject(s);
                        registerSubjects(s);
                    }
                }
                else if (option == "7")
                {
                    calculatefeeforALl();
                }
                clear();
            }
            while (option != "8");
            Console.ReadLine();
    }
    static Student studentPresent(string name)
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
        public static void calculatefeeforALl()
        {
            foreach (Student s in studentlist)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "  has " + s.calfees() + "  fees");
                }
            }
        }
        static void registerSubjects(Student s)
    {
        Console.Write("Enter how many subjects you want to Register :");
        int count = int.Parse(Console.ReadLine());
        for (int x = 0; x < count; x++)
        {
            Console.Write("Enter the subject Code : ");
            string code = Console.ReadLine();
            bool flag = false;
            foreach (Subject sub in s.regDegree.subjects)
            {
                if (code == sub.code && !(s.regsubject.Contains(sub)))
                {

                    s.redStudentSubject(sub);
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Enter  valid course.");
                x--;
            }
        }

    }
    static List<Student> sortbymerit()
    {
        List<Student> sortedsrudentinlist = new List<Student>();
        foreach (Student s in studentlist)
        {
            s.calculatemerit();
        }
        sortedsrudentinlist = studentlist.OrderByDescending(o => o.merit).ToList();
        return sortedsrudentinlist;
    }

    static void giveadmission(List<Student> sortedsrudentinlist)
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
    static void printstudents()
    {
        foreach (Student s in studentlist)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine(s.name + "  got admission in  " + s.regDegree.degreeName);
            }
            else
            {
                Console.WriteLine(s.name + " did not got admission ");

            }
        }
    }
    static void clear()
    {
        Console.Write("Press any Key to continue..");
        Console.ReadLine();
        Console.Clear();
    }
    static void viewstudentindegree(string degname)
    {
        Console.WriteLine("Name \t FSC \t ECAT \t AGE");
        foreach (Student s in studentlist)
        {
            if (s.regDegree != null)
            {
                if (degname == s.regDegree.degreeName)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
    }
    static void viewRegisteredstudent()
    {
        Console.WriteLine("Name \t FSC \t ECAT \t AGE");
        foreach (Student s in studentlist)
        {
            if (s.regDegree != null)
            {

                Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);

            }
        }
    }
    static void addIntoDegreeList(DegreeProgram d)
    {
        programlist.Add(d);
    }
    static DegreeProgram takeInputForDegree()
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
            degprogram.Addsubjet(takeInputForSubject());
        }
        return degprogram;
    }
    static Subject takeInputForSubject()
    {
        string code;
        string type;
        int credithours;
        int subjetfees;
        Console.Write("Enter subject code : ");
        code = Console.ReadLine();
        Console.Write("Enter Subject type : ");
        type = Console.ReadLine();
        Console.Write("Enter Subject credit hours  : ");
        credithours = int.Parse(Console.ReadLine());
        Console.Write("Enter Subject Fees  : ");
        subjetfees = int.Parse(Console.ReadLine());
        Subject sub = new Subject(code, type, credithours, subjetfees);


        return sub;
    }
    static void addIntoStudentList(Student s)
    {
        studentlist.Add(s);
    }
    static Student takeInputforStudent()
    {
        string name;
        int age;
        double fscmarks;
        double eactmarks;
        List<DegreeProgram> preferences = new List<DegreeProgram>();
        Console.Write("Enter Student name : ");
        name = Console.ReadLine();
        Console.Write("Enter student age : ");
        age = int.Parse(Console.ReadLine());
        Console.Write("Enter Student Fsc marks  : ");
        fscmarks = double.Parse(Console.ReadLine());
        Console.Write("Enter Student eact marks   : ");
        eactmarks = double.Parse(Console.ReadLine());
        Console.WriteLine("Available degree programs  : ");
        viewdegreeprograme();
        Console.Write("Enter how many preferences to Enter  : ");
        int count = int.Parse(Console.ReadLine());
        for (int x = 0; x < count; x++)
        {
            string degreename = Console.ReadLine();
            bool flag = false;
            foreach (DegreeProgram dp in programlist)
            {
                if (degreename == dp.degreeName && !(preferences.Contains(dp)))
                {
                    preferences.Add(dp);
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Enter Valid degree program Name");
                x--;
            }
        }
        Student s = new Student(name, age, fscmarks, eactmarks, preferences);
        return s;
    }
    static void viewdegreeprograme()
    {
        foreach (DegreeProgram dp in programlist)
        {
            Console.WriteLine(dp.degreeName);
        }
    }
    static void header()
    {
        Console.WriteLine("*******************************************");
        Console.WriteLine("*******             UAMS            *******");
        Console.WriteLine("*******************************************");
    }
    static void viewsubject(Student s)
    {
        if (s.regDegree != null)
        {
            Console.WriteLine("Sub Code \t Sub Type");
            foreach (Subject sub in s.regDegree.subjects)
            {
                Console.WriteLine(sub.code + " \t " + sub.type);
            }
        }
    }
    static string Menu()
    {
        header();
        string option;
        Console.WriteLine(" 1.Add Student .");
        Console.WriteLine(" 2.Add Degree program .");
        Console.WriteLine(" 3.Generate Merit .");
        Console.WriteLine(" 4.View Registered Student .");
        Console.WriteLine(" 5.View student of a specific Program .");
        Console.WriteLine(" 6. Register Subjet for a Specific Student .");
        Console.WriteLine(" 7.Calculate fee for all Registered Students .");
        Console.WriteLine(" 8.Exit .");
        Console.WriteLine("  Enter Option.");
        option = Console.ReadLine();
        return option;
    }
}

}

