using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_03.BL
{
    class Stident
    {
        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmark;
        public float aggregate;
    }
    class Student
    {
        //public Student()
        //{
        //    Console.WriteLine("Default Constructor called");
        //}
        public Student()
            {
            sname = "Jill";
            }

        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmark;
        public float aggregate;
    }
    class Student1
    {
        public Student1()
        {
            sname = "Ali";
            matricmarks = 990F;
            fscmarks = 1050F;
            ecatmark = 315F;
            aggregate = 3.77F;
        }
     
        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmark;
        public float aggregate;
    }
    class Student2
    {
        public Student2(string n)
        {
            sname = n;
        }

        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmark;
        public float aggregate;
    }
    class Student3
    {
        public Student3(string n,float m, float f, float e, float ag)
        {
            sname = n;
            matricmarks = m;
            fscmarks = f;
            ecatmark = e;
            aggregate = ag;
        }

        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmark;
        public float aggregate;
    }
    class student9
    {
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;

        public student9()
        {
            Console.Write("Default Constructor Called ");
        }
        public student9(string sname)
        {
            this.sname = sname;
        }
        public student9(student9 s)
        {
            sname = s.sname;
            matricMarks = s.matricMarks;
            fscMarks = s.fscMarks;
            ecatMarks = s.ecatMarks;
            aggregate = s.aggregate;
        }
    }
    class clockType
    {
        public int hours;
        public int minutes;
        public int seconds;

        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int hours)
        {
            this.hours = hours;
        }
        public clockType(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
        public clockType(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public void incrementSecond()
        {
            seconds++;
        }
        public void incrementHour()
        {
            hours++;
        }
        public void incrementMinute()
        {
            minutes++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(clockType t)
        {
            if (hours == t.hours && minutes == t.minutes && seconds == t.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    class Product
    {
        public string name;
        public string category;
        public float price;
        public int quantity;
        public int minimum;

        public Product()
            {

            }
        public void view()
        {
                Console.WriteLine(" Product Name: " + name + "  Category: " + category + "  Price: " + price + "  Stock: " + quantity); 
        }
        public string highestprice( List<Product> s)
        {
            float highest = 0;
            string name = "";
            for(int x =0; x < s.Count; x++)
            {
                if(highest < s[x].price)
                {
                    highest = s[x].price;
                    name = s[x].name;
                }
            }
            return name; 
        }
        public string ordered()
        {
            string ordered = "";
            if(minimum < 10)
            {
                ordered = name;
            }
            return ordered;
        }
        public float caltaxes()
        {
            float tax = 0F;
            if (category == "Grocery")
            {
                tax = (price * 10) / 100;
            }
            if (category == "fruit")
            {
                tax = (price * 5) / 100;
            }
            if (category != "fruit" && category != "Grocery")
            {
                tax = (price * 15) / 100;
            }
            return tax;
        }
    }
    class clock
    {
        public int hours;
        public int minutes;
        public int seconds;
        public int Remhours;
        public int Remminutes;
        public int Remseconds;
        public int difhours;
        public int difminutes;
        public int difseconds;

        public clock(int hour, int minute, int second)
        {
            this.hours = hour;
            this.minutes = minute;
            this.seconds = second;
            if (minutes != 0 && second != 0)
            {
                Remhours = 24 - hours - 1;
            }
            else if (minutes == 0 && second == 0)
            {
                Remhours = 24 - hours;
            }
            Remminutes = 60 - minutes - 1;
            Remseconds = 60 - seconds;
            if (Remhours < 0)
            {
                if (hours == 24)
                {
                    Remhours = 0;
                }
                Remminutes = Remminutes * -1;
                Remseconds = Remseconds * -1;
            }
        }
        public void dif(int dhour, int dminute, int dsecond)
        {
            this.difhours = dhour;
            this.difminutes = dminute;
            this.difseconds = dsecond;
            difhours = hours - dhour;
            difminutes = minutes - dminute;
            difseconds = seconds - dsecond;
            if (difhours < 0)
            {
                if (dhour == 24)
                {
                    difhours = 0;
                }
                difminutes = difminutes * -1;
                difseconds = difseconds * -1;
            }
        }
        public void printdClock(int hour, int minute, int second)
        {
            Console.WriteLine("Clock: " + hour + " " + minute + " " + second);
        }
        public void printRTime()
        {
            Console.WriteLine("Remaining: " + Remhours + " " + Remminutes + " " + Remseconds);
        }
        public void printdTime()
        {
            Console.WriteLine("Difference: " + difhours + " " + difminutes + " " + difseconds);
        }
        public void printTime()
        {
            Console.WriteLine("Elapsed: " + hours + " " + minutes + " " + seconds);
        }

    }
}
