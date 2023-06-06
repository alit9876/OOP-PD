using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_08.Bl
{
    class person
    {
        protected string name;
        protected string address;
        public person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public person()
        {

        }
        public string getname()
        {
            return name;
        }
        public string getaddress()
        {
            return address;
        }
        public void setaddress(string address)
        {
            this.address = address;
        }
        public string tostring()
        {
            string name = " Name: " + getname() + " Address: " + address;
            return name;
        }
    }
    class Student : person
    {
        private string program;
        private int year;
        private double fee;
        public Student(string name, string address, string program, int year, double fee) : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }
        public string getprogram()
        {
            return program;
        }
        public void setprogram(string program)
        {
            this.program = program;
        }
        public int getyear()
        {
            return year;
        }
        public void setyear(int year)
        {
            this.year = year;
        }
        public double getfee()
        {
            return fee;
        }
        public void setfee(double fee)
        {
            this.fee = fee;
        }
        public new string tostring()
        {
            string name = base.tostring() + " Program: " + program + " Year: " + year + " Fee: " + fee;
            return name;
        }
    }
    class Staff : person
    {
        private string school;
        private double pay;
        public Staff(string name, string address, string school, double pay): base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string getschool()
        {
            return school;
        }
        public void setschool(string school)
        {
            this.school = school;
        }
        public double getpay()
        {
            return pay;
        }
        public void setpay(double pay)
        {
            this.pay = pay;
        }
        public new string tostring()
        {
            string name = base.tostring() + " School: " + school + " PAy: " + pay;
            return name;
        }
    }



}
