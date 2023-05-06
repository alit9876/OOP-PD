using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD_05.BL
{
    class ship
    {
        public string shipno;
        angle latitude = new angle();
        angle longitude = new angle();
        public void shiplat(int deg, float min, char dir)
        {
            latitude.degree = deg;
            latitude.direction = dir;
            latitude.minute = min;
        }
        public ship()
        {

        }
        public void shiplong(int deg, float min, char dir)
        {
            longitude.degree = deg;
            longitude.direction = dir;
            longitude.minute = min;
        }
        public ship(string shipno)
        {
            this.shipno = shipno;
        }
        public int shipposition(List<ship> shipsdata, string name)
        {
            int serialnumber = 0;
            for(int x=0; x<shipsdata.Count;x++ )
            {
                if(shipsdata[x].shipno == name)
                {
                    serialnumber = x;
                }
            }
            return serialnumber; 
        }
        public void latvalue(ref int deg, ref float min, ref char dir)
        {
             deg = latitude.degree;
             min= latitude.minute ;
             dir = latitude.direction;
        }
        public void longvalue(ref int deg, ref float min, ref char dire)
        {
            deg = longitude.degree;
             min = longitude.minute;
             dire = longitude.direction ;
        }
        public void shipserialnumber( string longcoordinates, string latcoordinates,ref int latdegree , ref float latminute , ref char latdirection,ref int longdegree,ref float longminute,ref char longdirection)
        {
             
            int degsign = 0;
            int minsign = 0;
            string data = ""; //   for data conversion
            for(int x=0;x < longcoordinates.Count();x++)
            {
                if(longcoordinates[x] == '>')
                {
                    degsign = x;
              
                }
                if(longcoordinates[x] == '<')
                {
                    minsign = x;
                
                }
            }
            for (int y = 0; y < degsign; y++)
            {
                data = data + longcoordinates[y];
            }
            
            longdegree = int.Parse(data);
            data = "";
            for(int z=degsign+1;z<minsign;z++)
            {
                data = data + longcoordinates[z];
            }
            
            longminute = int.Parse(data);
            longdirection = (longcoordinates[longcoordinates.Count() - 1]);

            degsign = 0;
            minsign = 0;
            data = "";
            for (int x = 0; x < latcoordinates.Count(); x++)
            {
                if (latcoordinates[x] == '>')
                {
                    degsign = x;
            
                }
                if (latcoordinates[x] == '<')
                {
                    minsign = x;
                }
            }
            for (int y = 0; y < degsign; y++)
            {
                data = data + latcoordinates[y];
            }
            latdegree = int.Parse(data);
            data = "";
            for (int z = degsign + 1; z < minsign; z++)
            {
                data = data + latcoordinates[z];
            }
            latminute = int.Parse(data);
            latdirection = (latcoordinates[latcoordinates.Count() - 1]);
            
        }
        public bool valusereturn( ref int latdegree, ref float latminute, ref char latdirection, ref int longdegree, ref float longminute, ref char longdirection)
        {
            bool index = false;
            if((latitude.degree== latdegree) &&(latitude.minute == latminute) && (latitude.direction == latdirection) && (longitude.direction == longdirection) && (longitude.minute == longminute) && (longitude.direction == longdirection))
            {
                index = true;
            }
            return index;
        }

    }
    class angle
    {
        public int degree;
        public float minute;
        public char direction;
    }


}
