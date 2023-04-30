using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using EZInput;
using Warmaze.BL;

namespace Warmaze
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] mazeforlevel1 = new char[40, 110];
            coordinates s = new coordinates();
            List<bullet> b = new List<bullet>();
            List<bulletl> bl = new List<bulletl>();
            List<bulletu> bu = new List<bulletu>();
            List<bullete2> b2 = new List<bullete2>();
            List<bullete1> b1 = new List<bullete1>();

            s.playerX = 5;                  //      player corrdinate X
            s.playerY = 29;                 //      player coordinate Y
            s.enemy1X = 13;                 //      enemy 1 coordinate X
            s.enemy1Y = 1;                  //      enemy 1 coordinate Y
            s.enemy1direction = "Right"; //      enemy 1 direction of movement
            s.enemy1health = 100;            //      enemy1 health counter
            s.enemy2health = 100;            //      enemy2 health counter
            s.enemy3health = 10;            //      enemy2 health counter
            s.enemy4health = 10;            //      enemy2 health counter
            s.enemy5health = 10;            //      enemy2 health counter
            s.enemy6health = 10;            //      enemy2 health counter
            s.score = 0;                    //     score value
            s.playerhealth = 100;
            s.enemy2direction = "Up";   //         enemy 2 direction of movement
            s.enemy2X = 101;               //         enemy 2 coordinate X
            s.enemy2Y = 10;                //         enemy 2 coordinate Y


            //                 enemy bullet speedd

            s.e1 = 0;     //      enemy 1 bullet speed
            s.e2 = 0;     //      enemy 2 bullet speed
            s.e1move = 0; //      enemy 1 movement speed
            s.e2move = 0; //      enemy 1 movement speed

            // player bullet

            s.bulletcount = 0;

            //  for left

            
            s.bulletcountl = 0;

            //    for up

            
            s.bulletcountu = 0;

            //               enemy firing

            //          e1
            s.bulletcounte1 = 0;
            
            //     e2

            s.bulletcounte2 = 0;

            Console.Clear();
            int option = 0;
            savedata(s);
            // savemazeforlevel1();
            // savemazeforlevel2();
            loadmazeforlevel1(mazeforlevel1);
            //loadmazeforlevel2();
            while (option != 3)
            {

                Console.Clear();
                s.header();
                option = s.menu();

                if (option == 1)
                {
                    Console.Clear();
                    int choice = s.newloadgame();
                    if (choice == 1)
                    {
                        loaddatafornew(s);
                        Console.Clear();
                        s.resetbulletcountforallenemy();
                        s.printmaze(mazeforlevel1);        // print maze 1
                        s.printplayer( mazeforlevel1);      // print player
                        s.displayallvalues(); // display all values
                        game(mazeforlevel1, s,b,bl,bu,b1, b2);
                    }

                    if (choice == 2)
                    {
                        loaddataload(s); //  load data from save data file
                        Console.Clear();


                        s.printmaze(mazeforlevel1);
                        s.printplayer(mazeforlevel1);
                        s.displayallvalues(); // display all values
                        game(mazeforlevel1, s, b,bl,bu,b1,b2);             // game level 1

                        //if (valuefromlevel2 != 0)
                        {
                            //gamelevel2(); // game level 2
                        }
                    }
                }

                if (option == 2)
                {
                    int choice = 0;
                    int n = -1;
                    while (n != 0)
                    {
                        Console.Clear();
                        s.header();
                        choice = s.submenu();

                        if (choice == 1)
                        {
                            Console.Clear();
                            s.header();
                            s.keys();
                            Console.Write("Press any key to continue: ");
                            Console.ReadKey();
                        }

                        if (choice == 2)
                        {
                            Console.Clear();
                            s.header();
                            s.instruction();
                        }

                        if (choice == 3)
                        {
                            n = 0;
                        }
                    }
                    if (n != 0)
                    {
                        s.clear();
                    }
                }
            }

            Console.Clear();

        }
        static void game(char[,] mazeforlevel1, coordinates s, List<bullet> b,List<bulletl> bl,List<bulletu> bu, List<bullete1> b1, List<bullete2> b2)
        {

            bool gamerunning = true;
            while (gamerunning)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (mazeforlevel1[s.playerY, s.playerX - 1] == ' ' && mazeforlevel1[s.playerY + 1, s.playerX - 1] == ' ' && mazeforlevel1[s.playerY + 2, s.playerX - 1] == ' ')
                    {
                        s.moveplayerleft( mazeforlevel1); // player move left
                    }
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (mazeforlevel1[s.playerY, s.playerX + 3] == ' ' && mazeforlevel1[s.playerY + 1, s.playerX + 3] == ' ' && mazeforlevel1[s.playerY + 2, s.playerX + 3] == ' ')
                    {
                        s.moveplayerright(mazeforlevel1); // player move right
                    }
                }

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {

                    if (mazeforlevel1[s.playerY - 1, s.playerX] == ' ' && mazeforlevel1[s.playerY - 1, s.playerX + 1] == ' ' && mazeforlevel1[s.playerY - 1, s.playerX + 2] == ' ')
                    {
                        s.moveplayerup(mazeforlevel1); // player move up
                    }
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {

                    if (mazeforlevel1[s.playerY + 3, s.playerX] == ' ' && mazeforlevel1[s.playerY + 3, s.playerX + 1] == ' ' && mazeforlevel1[s.playerY + 3, s.playerX + 2] == ' ')
                    {
                        s.moveplayerdown(mazeforlevel1); // player move down
                    }
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    int option = s.savegamemenu();
                    if (option == 1)
                    {
                        savedataload(s);
                        gamerunning = false; // exist from game
                    }
                    if (option == 2)
                    {
                        gamerunning = false;
                    }
                }

                if (Keyboard.IsKeyPressed(Key.F3))
                {
                    //   char next = getCharAtxy(playerX + 3, playerY + 1);
                    if (mazeforlevel1[s.playerY + 1, s.playerX + 3] == ' ')
                    {
                        s.generatebullet(b); // generate bullet right
                    }
                }

                if (Keyboard.IsKeyPressed(Key.F2))
                {
                    //      char next = getCharAtxy(playerX, playerY - 1);
                    if (mazeforlevel1[s.playerY - 1, s.playerX] == ' ')
                    {
                        s.generatebulletu(bu); // generate bullet up
                    }
                }

                if (Keyboard.IsKeyPressed(Key.F1))
                {
                    //   char next = getCharAtxy(playerX - 1, playerY + 1);
                    if (mazeforlevel1[s.playerY + 1, s.playerX - 1] == ' ')
                    {
                        s.generatebulletl(bl); // generate bullet left
                    }
                }


                if (gamerunning == true)
                {
                    s.appeardisappearenemy1(b,b1, mazeforlevel1); // control enemy
                    s.appeardisappearenemy2(b,b2, mazeforlevel1); // control enemy
                    

                    if (s.enemy1health > 0)
                    {
                        for (int x = 0; x < bu.Count; x++) // enemy collision with bullet
                        {

                            bu[x].enemy1collisionwithbullet(s); // coolision with bullet
                        }
                        s.playercollisionwithenemy1(); // collision with enemy
                    }

                    if (s.enemy2health > 0)
                    {
                        for (int x = 0; x < b.Count; x++) // enemy collision with bullet
                        {

                            b[x].enemy2collisionwithbullet(s); // collision with bullet
                        }
                        s.playercollisionwithenemy2(); // collision with enemy
                    }

                    //     player bullet movement

                    for (int x = 0; x < s.bulletcount; x++)
                    {

                        b[x].movebullet(s, mazeforlevel1);  // move player bullet
                    }
                    for (int x = 0; x < s.bulletcountl; x++)
                    {
                        bl[x].movebulletl(s, mazeforlevel1); // move player bullet
                    }
                    for (int x = 0; x < s.bulletcountu; x++)
                    {
                        bu[x].movebulletu(s, mazeforlevel1); // move player bullet
                    }

                    //            enemy bullet movement
                    for (int x = 0; x < s.bulletcounte1; x++)
                    {
                        b1[x].movebullete1(s, mazeforlevel1);  // move enemy1 bullet
                    }                                   // 
                    for (int x = 0; x < s.bulletcounte2; x++)
                    {
                        b2[x].movebullete2(s,mazeforlevel1);  // move enemy2 bullet
                    }
                    s.playercollisionwithenemybullet(mazeforlevel1); // player collision with enemy bullet

                    s.e1++;     //  bullet movement control counter
                    s.e1move++; // movement control counter
                    s.e2++;     // bullet movement control counter
                    s.e2move++; // movement control counter
                    Console.SetCursorPosition(111, 1);
                    Console.Write(s.enemy1direction);
                    if (s.enemy1health == 0 && s.enemy2health == 0) // start level 2
                    {
                        s.endgame();
                        break;
                    }

                    if (s.playerhealth == 0)
                    {
                        s.gameoverbyhealth();
                        gamerunning = false;
                    }
                    Thread.Sleep(200);
                }
            }
        }
        

        //        file handling

        public static string getfield(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void loadmazeforlevel1(char[,] mazeforlevel1)
        {
            string path = "mazelevel1.txt";
            StreamReader myfile = new StreamReader(path);
            string line;
            int row = 0;
            while ((line = myfile.ReadLine()) != null)
            {
                for (int x = 0; x < 110; x++)
                {
                    mazeforlevel1[row, x] = line[x];
                }
                Console.WriteLine();
                row++;
            }
            myfile.Close();
        }
        static void savedata(coordinates s)
        {
            string path = "newgame.txt";
            StreamWriter file = new StreamWriter(path, false);

            file.Write(s.playerX + ",");
            file.Write(s.playerY + ",");
            file.Write(s.enemy1X + ",");
            file.Write(s.enemy1Y + ",");
            file.Write(s.enemy2X + ",");
            file.Write(s.enemy2Y + ",");

            file.Write(s.playerhealth + ",");
            file.Write(s.score + ",");
            file.Write(s.enemy1direction + ",");
            file.Write(s.enemy2direction + ",");

            file.Write(s.e1 + ",");
            file.Write(s.e2 + ",");

            file.Write(s.e1move + ",");
            file.Write(s.e2move + ",");

            file.Write(s.enemy1health + ",");
            file.Write(s.enemy2health);

            file.Close();
        }
        static void loaddatafornew(coordinates s)
        {
            string record;
            string path = "newgame.txt";
            StreamReader myfile = new StreamReader(path);
            record = myfile.ReadLine();
            s.playerX = int.Parse(getfield(record, 1));
            s.playerY = int.Parse(getfield(record, 2));
            s.enemy1X = int.Parse(getfield(record, 3));
            s.enemy1Y = int.Parse(getfield(record, 4));
            s.enemy2X = int.Parse(getfield(record, 5));
            s.enemy2Y = int.Parse(getfield(record, 6));

            s.playerhealth = int.Parse(getfield(record, 7));
            s.score = int.Parse(getfield(record, 8));
            s.enemy1direction = getfield(record, 9);
            s.enemy2direction = getfield(record, 10);

            s.e1 = int.Parse(getfield(record, 11));
            s.e2 = int.Parse(getfield(record, 12));

            s.e1move = int.Parse(getfield(record, 13));
            s.e2move = int.Parse(getfield(record, 14));
            s.enemy1health = int.Parse(getfield(record, 15));
            s.enemy2health = int.Parse(getfield(record, 16));
            myfile.Close();
        }
        static void savedataload(coordinates s)
        {
            string path = "loaddata.txt";
            StreamWriter file = new StreamWriter(path, false);

            file.Write(s.playerX + ",");
            file.Write(s.playerY + ",");
            file.Write(s.enemy1X + ",");
            file.Write(s.enemy1Y + ",");
            file.Write(s.enemy2X + ",");
            file.Write(s.enemy2Y + ",");

            file.Write(s.playerhealth + ",");
            file.Write(s.score + ",");
            file.Write(s.enemy1direction + ",");
            file.Write(s.enemy2direction + ",");

            file.Write(s.e1 + ",");
            file.Write(s.e2 + ",");

            file.Write(s.e1move + ",");
            file.Write(s.e2move + ",");

            file.Write(s.enemy1health + ",");
            file.Write(s.enemy2health);

            file.Close();
        }
        static void loaddataload(coordinates s)
        {
            string record;
            string path = "loaddata.txt";
            StreamReader myfile = new StreamReader(path);
            record = myfile.ReadLine();
            s.playerX = int.Parse(getfield(record, 1));
            s.playerY = int.Parse(getfield(record, 2));
            s.enemy1X = int.Parse(getfield(record, 3));
            s.enemy1Y = int.Parse(getfield(record, 4));
            s.enemy2X = int.Parse(getfield(record, 5));
            s.enemy2Y = int.Parse(getfield(record, 6));

            s.playerhealth = int.Parse(getfield(record, 7));
            s.score = int.Parse(getfield(record, 8));
            s.enemy1direction = getfield(record, 9);
            s.enemy2direction = getfield(record, 10);

            s.e1 = int.Parse(getfield(record, 11));
            s.e2 = int.Parse(getfield(record, 12));

            s.e1move = int.Parse(getfield(record, 13));
            s.e2move = int.Parse(getfield(record, 14));
            s.enemy1health = int.Parse(getfield(record, 15));
            s.enemy2health = int.Parse(getfield(record, 16));
            myfile.Close();
        }
    
        //   finishs
    }
}
