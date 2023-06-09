using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class Bicyle
    {
        private int cadence;
        private int gear;
        private int speed;
       public Bicyle()
        {

        }
        
        public Bicyle(int cadence, int speed, int gear)
        {
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;
        }
        public void setcadence(int cadence)
        {
            this.cadence = cadence;
        }
        public void setgear(int gear)
        {
            this.gear = gear;
        }
        public void setspeed(int speed)
        {
            this.speed = speed;
        }
        public void aapplebrake(int decrement)
        {
            speed = speed - decrement;
        }
        public void speedup(int increment)
        {
            speed = speed + increment;
        }
    }
    class Mountainbike : Bicyle
    {
        private int seatHeight;
        public Mountainbike()
        {

        }
        public Mountainbike(int seatHeight,int cadence, int speed, int gear): base(cadence,speed,  gear)
        {
            this.seatHeight = seatHeight;
        }
        public void setSeatheigth(int seatHeight)
        {
            this.seatHeight = seatHeight;
        }
    }


}
