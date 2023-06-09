using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    
    class ladder
    {
        private int length;
        private string colour;
    }
    class HosePipe
    {
        private string material;
        private string shape;
        private double diameter;
        private double flowrate;
    }
    class drive
    {
        protected string name;
        public void drivetruck()
        {

        }
        public void extinguishfire()
        {

        }
    }
    class firefighter : drive
    {

    }
    class firechief : drive
    {
        public void delegateresponsibility()
        {

        }
    }
    class truck
    {
        public ladder ld;
        public HosePipe Hp;
        public List<drive> dd = new List<drive>();
        public truck()
        {
            this.ld = new ladder();
        }           
        public void sethosepie(HosePipe obj)
        {
            this.Hp = obj;
        }
    }
}
