using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmaze.BL
{
    class coordinates
    {
        public int playerX;                  //      player corrdinate X
        public int playerY;                 //      player coordinate Y
        public int enemy1X;                 //      enemy 1 coordinate X
        public int enemy1Y;                  //      enemy 1 coordinate Y
        public string enemy1direction; //      enemy 1 direction of movement
        public int enemy1health;            //      enemy1 health counter
        public int enemy2health;            //      enemy2 health counter
        public int enemy3health;            //      enemy2 health counter
        public int enemy4health;            //      enemy2 health counter
        public int enemy5health;            //      enemy2 health counter
        public int enemy6health;            //      enemy2 health counter
        public int score;                    //     score value
        public int playerhealth;
        public string enemy2direction;   //         enemy 2 direction of movement
        public int enemy2X;               //         enemy 2 coordinate X
        public int enemy2Y;                //         enemy 2 coordinate Y


        //                 enemy bullet speedd

        public int e1;     //      enemy 1 bullet speed
        public int e2;     //      enemy 2 bullet speed
        public int e1move; //      enemy 1 movement speed
        public int e2move; //      enemy 1 movement speed

        public int bulletcounte1;
        public int bulletcounte2;
        public int  bulletcountu;
        public int bulletcountl;
        public int bulletcount;
    }
    class bullet
    {
        // player bullet

        public int bulletX; //    for right
        public int bulletY;
        public bool isbulletActive;
    }
    class bulletl
    {
        public int bulletXl;
        public int bulletYl;
        public bool isbulletActivel;
    }
    class bulletu
    {
        public int bulletXu;
        public int bulletYu;
        public bool isbulletActiveu;
    }

    class bullete2
    {
        public int bullete2X;
        public int bullete2Y;
        public bool isbulletActivee2;
    }

    class bullete1
    {
        public int bullete1X;
        public int bullete1Y;
        public bool isbulletActivee1;
    }



}
