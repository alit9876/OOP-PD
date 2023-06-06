using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_08.Bl
{
    class shape
    {
        protected double area;
        public virtual string getshape()
        {
            return " ";
        }
        public virtual double getarea()
        {
            return 0;
        }
        public virtual string tostring()
        {
            return " ";
        }
    }
    class rectangleBL : shape
    {
        private double length;
        private double width;
        public rectangleBL(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        public override string getshape()
        {
            return "rectangle";
        }
        public override double getarea()
        {
            double area = length * width;
            return area;
        }
        public override string tostring()
        {
            string name = "The shape is " + getshape() + " and its area is " + getarea();
            return name;
        }
    }
    class squareBL : shape
    {
        private int side;
        public squareBL(int side)
        {
            this.side = side;
        }
        public override string getshape()
        {
            return "Square";
        }
        public override double getarea()
        {
            double area = side * side;
            return area;
        }
        public override string tostring()
        {
            string name = "The shape is " + getshape() + " and its area is " + getarea();
            return name;
        }
    }
    class circleBL :shape
    {
        private int radius;
        public circleBL(int radius)
        {
            this.radius = radius;
        }
        public override string getshape()
        {
            return "Circle";
        }
        public override double getarea()
        {
            double area = 2* Math.PI * Math.Pow(radius,2);
            return area;
        }
        public override string tostring()
        {
            string name = "The shape is " + getshape() + " and its area is " + getarea();
            return name;
        }
    }



}
