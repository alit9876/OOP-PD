using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_08.Bl
{
    class animal
    {
        protected string name;
        public animal()
        {

        }
        public animal(string name)
        {
            this.name = name;
        }
        public string getname()
        {
            return name;
        }
        public string tostring()
        {
            string name = " Name: " + getname();
            return name;
        }
        public virtual void greets()
        {

        }
        public virtual void greets(dog another)
        {

        }
    }
    class mammal: animal
    {
        protected string Mammal;
        public new string tostring()
        {
            string name = " Mammal: " + Mammal + " Animal: " + getname();
            return name;
        }
        public mammal(string mammal)
        {
            this.Mammal = mammal;
        }
        public mammal(string animal, string mammal): base (animal)
        {
            this.Mammal = mammal;
        }
        public override void greets()
        {

        }
        public override void greets(dog another)
        {

        }
    }
    class cat : mammal
    {
        private string catname;
        public override void greets()
        {
            Console.WriteLine( "Meow");
        }
        public new string tostring()
        {
            string name = "Cat: " + catname;
            return name;
        }
        public cat(string anima, string mammal, string catname): base(anima, mammal)
        {
            this.catname = catname;
        }
        public override void greets(dog another)
        {
            Console.WriteLine("Woooooof");
        }
    }
    class dog : mammal
    {
        private string dogname;
        public override void greets()
        {
            Console.WriteLine("Woof");
        }
        public override void greets(dog another)
        {
            Console.WriteLine("Woooooof");
        }
        public new string tostring()
        {
            string name = " Dog: " + dogname;
            return name;
        }
        public dog(string anima, string mammal, string dogname) : base(anima, mammal)
        {
            this.dogname = dogname;
        }
    }



}
