using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_08.Bl
{
    class circle
    {
        protected double radius;
        protected string color;
        public circle()
        {

        }
        public circle(double radius)
        {
            this.radius = radius;
        }
        public circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }
        public double getradius()
        {
            return radius;
        }
        public void setradius(double radius)
        {
            this.radius = radius;
        }
        public string getcolor()
        {
            return color;
        }
        public void setcolor(string color)
        {
            this.color = color;
        }
        public double getarea()
        {
            return (2 * Math.PI * Math.Pow(radius, 2));
        }
        public string tostring()
        {
            string name =  " colour: " + color + " Radius: " + (radius) + " Area: " + getarea();
            return name;
        }
    }
    class cylinder: circle
    {
        private double height;
        public cylinder()
        {

        }
        public cylinder(double radius) : base(radius)
        {

        }
        public cylinder(double radius, double height): base(radius)
        {
            this.height = height;
        }
        public cylinder(double radius, double height, string color): base(radius, color)
        {
            this.height = height;
        }
        public void setheight(double height)
        {
            this.height = height;
        }
        public double getheight()
        {
            return height;
        }
        public double getvolume()
        {
            double vol = 2 * Math.PI * radius * height;
            return vol;
        }
    }


}
