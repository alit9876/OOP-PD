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

            //b.bulletX; //    for right
            //b.bulletY = new int[100];
            //bool[] isbulletActive = new bool[100];
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
                header();
                option = menu();

                if (option == 1)
                {
                    Console.Clear();
                    int choice = newloadgame();
                    if (choice == 1)
                    {
                        loaddatafornew(s);
                        Console.Clear();
                        resetbulletcountforallenemy(s);
                        printmaze(mazeforlevel1);        // print maze 1
                        printplayer(s, mazeforlevel1);      // print player
                        displayallvalues(s); // display all values
                        game(mazeforlevel1, s,b,bl,bu,b1, b2);
                    }

                    if (choice == 2)
                    {
                        loaddataload(s); //  load data from save data file
                        Console.Clear();


                        printmaze(mazeforlevel1);
                        printplayer(s, mazeforlevel1);
                        displayallvalues(s); // display all values
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
                        header();
                        choice = submenu();

                        if (choice == 1)
                        {
                            Console.Clear();
                            header();
                            keys();
                            Console.Write("Press any key to continue: ");
                            Console.ReadKey();
                        }

                        if (choice == 2)
                        {
                            Console.Clear();
                            header();
                            instruction();
                        }

                        if (choice == 3)
                        {
                            n = 0;
                        }
                    }
                    if (n != 0)
                    {
                        clear();
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
                        moveplayerleft(s, mazeforlevel1); // player move left
                    }
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (mazeforlevel1[s.playerY, s.playerX + 3] == ' ' && mazeforlevel1[s.playerY + 1, s.playerX + 3] == ' ' && mazeforlevel1[s.playerY + 2, s.playerX + 3] == ' ')
                    {
                        moveplayerright(s, mazeforlevel1); // player move right
                    }
                }

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {

                    if (mazeforlevel1[s.playerY - 1, s.playerX] == ' ' && mazeforlevel1[s.playerY - 1, s.playerX + 1] == ' ' && mazeforlevel1[s.playerY - 1, s.playerX + 2] == ' ')
                    {
                        moveplayerup(s, mazeforlevel1); // player move up
                    }
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {

                    if (mazeforlevel1[s.playerY + 3, s.playerX] == ' ' && mazeforlevel1[s.playerY + 3, s.playerX + 1] == ' ' && mazeforlevel1[s.playerY + 3, s.playerX + 2] == ' ')
                    {
                        moveplayerdown(s, mazeforlevel1); // player move down
                    }
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    int option = savegamemenu();
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
                        generatebullet(s,b); // generate bullet right
                    }
                }

                if (Keyboard.IsKeyPressed(Key.F2))
                {
                    //      char next = getCharAtxy(playerX, playerY - 1);
                    if (mazeforlevel1[s.playerY - 1, s.playerX] == ' ')
                    {
                        generatebulletu(s,bu); // generate bullet up
                    }
                }

                if (Keyboard.IsKeyPressed(Key.F1))
                {
                    //   char next = getCharAtxy(playerX - 1, playerY + 1);
                    if (mazeforlevel1[s.playerY + 1, s.playerX - 1] == ' ')
                    {
                        generatebulletl(s,bl); // generate bullet left
                    }
                }


                if (gamerunning == true)
                {
                    appeardisappearenemy1(s,b,b1, mazeforlevel1); // control enemy
                    appeardisappearenemy2(s,b,b2, mazeforlevel1); // control enemy
                    

                    if (s.enemy1health > 0)
                    {
                        enemy1collisionwithbullet(s,bu); // coolision with bullet
                        playercollisionwithenemy1(s); // collision with enemy
                    }

                    if (s.enemy2health > 0)
                    {
                        enemy2collisionwithbullet(s,b); // collision with bullet
                        playercollisionwithenemy2(s); // collision with enemy
                    }

                    //     player bullet movement


                        movebullet(s,b, mazeforlevel1);  // move player bullet
                        movebulletl(s, bl, mazeforlevel1); // move player bullet
                        movebulletu(s, bu, mazeforlevel1); // move player bullet

                    //            enemy bullet movement

                    movebullete1(s, b1, mazeforlevel1);  // move enemy1 bullet                
                    movebullete2(s,b2, mazeforlevel1);  // move enemy2 bullet
                    playercollisionwithenemybullet(s,b, mazeforlevel1); // player collision with enemy bullet

                    s.e1++;     //  bullet movement control counter
                    s.e1move++; // movement control counter
                    s.e2++;     // bullet movement control counter
                    s.e2move++; // movement control counter
                    Console.SetCursorPosition(111, 1);
                    Console.Write(s.enemy1direction);
                    if (s.enemy1health == 0 && s.enemy2health == 0) // start level 2
                    {
                        endgame(s);
                        break;
                    }

                    if (s.playerhealth == 0)
                    {
                        gameoverbyhealth(s);
                        gamerunning = false;
                    }
                    Thread.Sleep(200);
                }
            }
        }
        static void endgame(coordinates s)
        {
            
            Console.Clear(); // end the game
            loading1();
            Console.Clear();
            header();
            Console.WriteLine();
            Console.WriteLine("Game Over!!!");
            Console.WriteLine("Score:" + s.score);
            Console.Write("Press any key to Continue:");
            Console.ReadLine();
        }
        static void loading1()
        {
            Console.WriteLine();
            Console.Write(" Calculating score ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("-");
                Thread.Sleep(300);
            }
        }
        static void header()
        {
            Console.WriteLine();

            Console.WriteLine("WWWWWWWW                           WWWWWWWW                                  MMMMMMMM               MMMMMMMM        ");
            Console.WriteLine("W::::::W                           W::::::W                                  M:::::::M             M:::::::M      ");
            Console.WriteLine("W::::::W                           W::::::W                                  M::::::::M           M::::::::M               ");
            Console.WriteLine("W::::::W                           W::::::W                                  M:::::::::M         M:::::::::M         ");
            Console.WriteLine(" W:::::W           WWWWW           W:::::Waaaaaaaaaaaaa  rrrrr   rrrrrrrrr   M::::::::::M       M::::::::::M  aaaaaaaaaaaaa   zzzzzzzzzzzzzzzzz    eeeeeeeeeeee");
            Console.WriteLine("  W:::::W         W:::::W         W:::::W a::::::::::::a r::::rrr:::::::::r  M:::::::::::M     M:::::::::::M  a::::::::::::a  z:::::::::::::::z  ee::::::::::::ee ");
            Console.WriteLine("   W:::::W       W:::::::W       W:::::W  aaaaaaaaa:::::ar:::::::::::::::::r M:::::::M::::M   M::::M:::::::M  aaaaaaaaa:::::a z::::::::::::::z  e::::::eeeee:::::ee");
            Console.WriteLine("    W:::::W     W:::::::::W     W:::::W            a::::arr::::::rrrrr::::::rM::::::M M::::M M::::M M::::::M           a::::a zzzzzzzz::::::z  e::::::e     e:::::e");
            Console.WriteLine("     W:::::W   W:::::W:::::W   W:::::W      aaaaaaa:::::a r:::::r     r:::::rM::::::M  M::::M::::M  M::::::M    aaaaaaa:::::a       z::::::z   e:::::::eeeee::::::e");
            Console.WriteLine("      W:::::W W:::::W W:::::W W:::::W     aa::::::::::::a r:::::r     rrrrrrrM::::::M   M:::::::M   M::::::M  aa::::::::::::a      z::::::z    e:::::::::::::::::e");
            Console.WriteLine("       W:::::W:::::W   W:::::W:::::W     a::::aaaa::::::a r:::::r            M::::::M    M:::::M    M::::::M a::::aaaa::::::a     z::::::z     e::::::eeeeeeeeeee");
            Console.WriteLine("        W:::::::::W     W:::::::::W     a::::a    a:::::a r:::::r            M::::::M     MMMMM     M::::::Ma::::a    a:::::a    z::::::z      e:::::::e     ");
            Console.WriteLine("         W:::::::W       W:::::::W      a::::a    a:::::a r:::::r            M::::::M               M::::::Ma::::a    a:::::a   z::::::zzzzzzzze::::::::e");
            Console.WriteLine("          W:::::W         W:::::W       a:::::aaaa::::::a r:::::r            M::::::M               M::::::Ma:::::aaaa::::::a  z::::::::::::::z e::::::::eeeeeeee");
            Console.WriteLine("           W:::W           W:::W         a::::::::::aa:::ar:::::r            M::::::M               M::::::M a::::::::::aa:::az:::::::::::::::z  ee:::::::::::::e");
            Console.WriteLine("            WWW             WWW           aaaaaaaaaa  aaaarrrrrrr            MMMMMMMM               MMMMMMMM  aaaaaaaaaa  aaaazzzzzzzzzzzzzzzzz    eeeeeeeeeeeeee  ");
            Console.WriteLine();
        }
        static void printscore(coordinates s)
        {
            //   print and increment score
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:0");
            incrementscore(s);
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:" + s.score);
        }
        static void incrementscore(coordinates s)
        {
            s.score++;
        }
        static int submenu()
        {
            Console.Clear();
            int option = 0;
            header();
            Console.WriteLine(" Options");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. Keys.");
            Console.WriteLine(" 2. Instructions.");
            Console.WriteLine(" 3. Exist.");
            Console.WriteLine();
            Console.Write("Enter any option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int menu()
        {
            int option;
            Console.WriteLine(" Menu");
            Console.WriteLine(" -------------------");
            Console.WriteLine(" 1. Start ");
            Console.WriteLine(" 2. Option");
            Console.WriteLine(" 3. Exist");
            Console.WriteLine();
            Console.Write(" Enter one option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int savegamemenu()
        {
            int choice;
            Console.Clear();
            header();
            Console.WriteLine(" Save Menu");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. Save and exit");
            Console.WriteLine(" 2. Exit only");
            Console.WriteLine();
            Console.Write(" Your choice:");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static int newloadgame()
        {
            Console.WriteLine();
            header();
            int option;
            Console.WriteLine(" Choose game");
            Console.WriteLine(" ------------");
            Console.WriteLine(" 1. Start New game");
            Console.WriteLine(" 2. Load Save Game");
            Console.WriteLine();
            Console.Write(" ENter your choice:");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void resetbulletcountforallenemy(coordinates s)
        {
            s.bulletcounte1 = 0;
            s.bulletcounte2 = 0;
            s.bulletcount = 0;
            s.bulletcountl = 0;
            s.bulletcountu = 0;
        }
        static void printmaze(char[,] mazeforlevel1)
        {
            //SetConsoleTextAttribute(hConsole, 11);

            for (int y = 0; y < 40; y++)
            {
                for (int x = 0; x < 110; x++)
                {
                    Console.Write(mazeforlevel1[y, x]);
                }
                Console.WriteLine();
            }
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void clear()
        {

            Console.WriteLine();
            Console.Write("Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }
        static void keys()
        {
            Console.WriteLine(" Keys.");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. UP                Go Up");
            Console.WriteLine(" 2. DOWN              Go Down");
            Console.WriteLine(" 3. LEFT              Go Left");
            Console.WriteLine(" 4. RIGHT             Go Right");
            Console.WriteLine(" 5. F1                Fire at Left");
            Console.WriteLine(" 6. F2                Fire at Right");
            Console.WriteLine(" 7. F3                Fire at Top");
            Console.WriteLine(" 8. SPACE             Jump");
            Console.WriteLine(" 9. ESC              End game");
            Console.WriteLine();
        }
        static void instruction()
        {
            Console.WriteLine(" Instructions ");
            Console.WriteLine(" -----------------------------------------------");

            Console.WriteLine();
            Console.WriteLine(" In level 1, player has to protect himself from enemy bullet by dodging them them by hiding from them. The player has to");
            Console.WriteLine(" defeat the enemy by firing bullets on them in oreder to advance to level 2.");
            Console.WriteLine(" In level 2, player has to protect himself from bullet enemies bullet but also from the moving obstacles too.");
            Console.WriteLine(" By defeating all the enemies, player got himself free from the maze.");
            Console.WriteLine();
            Console.WriteLine("  Press any key to continue: ");
            Console.ReadKey();
        }
        static void displayallvalues(coordinates s)
        {
            Console.SetCursorPosition(111, 13);
            Console.Write("Player Health:" + s.playerhealth);
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:" + s.score);
            Console.SetCursorPosition(111, 15);
            //SetConsoleTextAttribute(hConsole, 1);
            Console.Write("Enemy 1 Health:" + s.enemy1health);
            Console.SetCursorPosition(111, 16);
            //SetConsoleTextAttribute(hConsole, 2);
            Console.Write("Enemy 2 Health:" + s.enemy2health);
            Console.SetCursorPosition(111, 17);
            //SetConsoleTextAttribute(hConsole, 4);
            Console.Write("Enemy 3 Health:" + s.enemy3health);
            Console.SetCursorPosition(111, 18);
            //SetConsoleTextAttribute(hConsole, 5);
            Console.Write("Enemy 4 Health:" + s.enemy4health);
            Console.SetCursorPosition(111, 19);
            //SetConsoleTextAttribute(hConsole, 6);
            Console.Write("Enemy 5 Health:" + s.enemy5health);
            Console.SetCursorPosition(111, 20);
            //SetConsoleTextAttribute(hConsole, 4);
            Console.Write("Enemy 6 Health:" + s.enemy6health);
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void printplayer(coordinates s, char[,] mazeforlevel1)
        {
            char left = (char)47;
            char belly = (char)219;
            char right = (char)92;
            char middle = (char)227;
            char head = (char)2;
            char[,] player = new char[3, 3] {
                { ' ', head, ' '},
                { left, belly, right},
                { ' ', middle, ' '}
                };
            Console.SetCursorPosition(s.playerX, s.playerY);

            for (int y = 0; y < 3; y++)
            {
                Console.SetCursorPosition(s.playerX, s.playerY + y);
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(player[y, x]);

                }
            }

        }
        static void eraseplayer(coordinates s, char[,] mazeforlevel1)
        {
            char[,] player = new char[3, 3]  {
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '}
                };
            Console.SetCursorPosition(s.playerX, s.playerY);

            for (int y = 0; y < 3; y++)
            {
                Console.SetCursorPosition(s.playerX, s.playerY + y);
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(player[y, x]);

                }
            }
        }
        static void gameoverbyhealth(coordinates s)
        {
            if (s.playerhealth <= 0)
            {
                Console.Clear();
                header();
                Console.WriteLine(" Game Over!!!");
                Console.WriteLine(" Score:" + s.score);
                Console.WriteLine();
                Console.Write("  Press any key to continue:");
                Console.ReadKey();
            }
        }
        static void decrementplayerhealthbybullet(coordinates s)
        {
            s.playerhealth--;
        }
        static void decreasedplayerhealth(coordinates s)
        {
            Console.SetCursorPosition(111, 13);
            Console.Write("                 ");
            decrementplayerhealthbybullet(s);
            Console.SetCursorPosition(111, 13);
            if (s.playerhealth < 0)
            {
                s.playerhealth = 0;
            }
            Console.Write("Player Health:" + s.playerhealth);
        }
        static void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void printbulletfore1(int x, int y)
        {
            //SetConsoleTextAttribute(hConsole, 1);
            Console.SetCursorPosition(x, y);
            Console.Write("o");
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void printbulletfore2(int x, int y)
        {
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            //SetConsoleTextAttribute(hConsole, 7);
        }

        //         printing enemy healths
        static void printenemy1health(coordinates s)
        {
            //   print and decrement enemy health

            Console.SetCursorPosition(111, 15);
            Console.Write("Enemy 1 Health:100");
            s.enemy1health = s.enemy1health - 5;
            Console.SetCursorPosition(111, 15);
            Console.Write("                   ");
            if (s.enemy1health <= 0)
            {
                s.enemy1health = 0;
            }
            Console.SetCursorPosition(111, 15);
            Console.Write("Enemy 1 Health:" + s.enemy1health);
        }
        static void printenemy2health(coordinates s)
        {
            //   print and decrement enemy health

            Console.SetCursorPosition(111, 16);
            Console.Write("Enemy 2 Health:100");
            s.enemy2health = s.enemy2health - 5;
            Console.SetCursorPosition(111, 16);
            Console.Write("                   ");
            if (s.enemy2health <= 0)
            {
                s.enemy2health = 0;
            }
            Console.SetCursorPosition(111, 16);
            Console.Write("Enemy 2 Health:" + s.enemy2health);
        }

        //                 enemy 1

        static void printenemy1(coordinates s )
        {

            char up = (char)94;
            char box = (char)219;

            char[,] enemy1 = new char[2, 5]  {
                { '-', box, box, box, '-'},
                { ' ', ' ', 'o', ' ', ' '}
                };

            //SetConsoleTextAttribute(hConsole, 1);
            Console.SetCursorPosition(s.enemy1X, s.enemy1Y);
            for (int y = 0; y < 2; y++)
            {
                Console.SetCursorPosition(s.enemy1X, s.enemy1Y + y);
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(enemy1[y, x]);
                }
            }
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void eraseenemy1(coordinates s)
        {
            char[,] enemy1 = new char[2, 5] {
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '}
                };

            Console.SetCursorPosition(s.enemy1X, s.enemy1Y);
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(enemy1[y, x]);
                }
                Console.SetCursorPosition(s.enemy1X, s.enemy1Y + 1);
            }
        }
        static void enemy1movement(coordinates s, char[,] mazeforlevel1)
        {
            if (s.enemy1direction == "Right")
            {
                char next = mazeforlevel1[s.enemy1Y, s.enemy1X + 5];
                if (s.enemy1X == 75 && s.enemy1Y == 1)
                {
                    s.enemy1direction = "Left";
                }
                else if (next == ' ')
                {
                    eraseenemy1(s);
                    s.enemy1X++;
                    printenemy1(s);
                }
            }
            if (s.enemy1direction == "Left")
            {
                char next = mazeforlevel1[s.enemy1Y, s.enemy1X - 1];
                if (s.enemy1X == 13 && s.enemy1Y == 1)
                {
                    s.enemy1direction = "Right";
                }
                else if (next == ' ')
                {
                    eraseenemy1(s);
                    s.enemy1X--;
                    printenemy1(s);
                }
            }
        }
        static void enemy1collisionwithbullet(coordinates s, List<bulletu> b)
        {
            for (int x = 0; x < b.Count; x++) // enemy collision with bullet
            {

                if (b[x].isbulletActiveu == true)
                {
                    if (s.enemy1X == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu))
                    {
                        printenemy1health(s);
                        printscore(s);
                    }
                    if (s.enemy1X + 1 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu))
                    {
                        printenemy1health(s);
                        printscore(s);
                    }
                    if (s.enemy1X + 2 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu))
                    {
                        printenemy1health(s);
                        printscore(s);
                    }
                    if (s.enemy1X + 3 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu))
                    {
                        printenemy1health(s);
                        printscore(s);
                    }
                    if (s.enemy1X + 4 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu))
                    {
                        printenemy1health(s);
                        printscore(s);
                    }
                }
            }
        }
        static void generatebullete1(coordinates s, List<bullete1> b1 ,char[,] mazeforlevel1)
        {
            bullete1 s1 = new bullete1();
            s1.bullete1X = s.enemy1X + 2;
            s1.bullete1Y = s.enemy1Y + 2;
            s1.isbulletActivee1 = true;
            Console.SetCursorPosition(s.enemy1X + 2, s.enemy1Y + 2);
            //SetConsoleTextAttribute(hConsole, 1);
            Console.Write("o");
            mazeforlevel1[s.enemy1Y + 2, s.enemy1X + 2] = 'o';
            b1.Add(s1);
            s.bulletcounte1++;
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void movebullete1(coordinates s, List<bullete1> b1, char[,] mazeforlevel1)
        {
            for (int x = 0; x < s.bulletcounte1; x++)
            {
                if (b1[x].isbulletActivee1 == true)
                {
                    char next = mazeforlevel1[b1[x].bullete1Y + 1, b1[x].bullete1X];
                    if (next != ' ' || (s.playerY - 1 == b1[x].bullete1Y))
                    {
                        erasebullet(b1[x].bullete1X, b1[x].bullete1Y);
                        mazeforlevel1[b1[x].bullete1Y, b1[x].bullete1X] = ' ';
                        makebulletInactivee1(x, b1);
                    }
                    else if (next == ' ')
                    {
                        erasebullet(b1[x].bullete1X, b1[x].bullete1Y);
                        mazeforlevel1[b1[x].bullete1Y, b1[x].bullete1X] = ' ';
                        b1[x].bullete1Y = b1[x].bullete1Y + 1;
                        printbulletfore1(b1[x].bullete1X, b1[x].bullete1Y);
                        mazeforlevel1[b1[x].bullete1Y, b1[x].bullete1X] = 'o';
                    }
                }
            }
        }
        static void makebulletInactivee1(int index, List<bullete1> b1)
        {
            b1[index].isbulletActivee1 = false;
        }

        //                    enemy2 (vertical )

        static void printenemy2(coordinates s)
        {

            char[,] enemy2 = new char[4, 6]{
                { ' ', ' ', ' ', '-', '-', '-'},
                { '<', '=', '=', '(', '-', ')'},
                { ' ', ' ', ' ', '\\', '@', '/'},
                { ' ', ' ', ' ', '*', '*', '*'}
                };
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(s.enemy2X, s.enemy2Y);

            for (int y = 0; y < 4; y++)
            {
                Console.SetCursorPosition(s.enemy2X, s.enemy2Y + y);
                for (int x = 0; x < 6; x++)
                {
                    Console.Write(enemy2[y, x]);
                }
            }
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void eraseenemy2(coordinates s)
        {
            char[,] enemy2 = new char[4, 6]{
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '}
                };
            //gotoxy(enemy2X, enemy2Y);
            Console.SetCursorPosition(s.enemy2X, s.enemy2Y);
            for (int y = 0; y < 4; y++)
            {
                Console.SetCursorPosition(s.enemy2X, s.enemy2Y + y);
                for (int x = 0; x < 6; x++)
                {
                    Console.Write(enemy2[y, x]);
                }
            }
        }
        static void enemy2movement(coordinates s, char[,] mazeforlevel1)
        {
            if (s.enemy2direction == "Up")
            {
                char next = mazeforlevel1[s.enemy2Y - 1, s.enemy2X];
                if (s.enemy2X == 101 && s.enemy2Y == 6)
                {
                    s.enemy2direction = "Down";
                }
                else if (next == ' ')
                {
                    eraseenemy2(s);
                    s.enemy2Y--;
                    printenemy2(s);
                }
            }

            if (s.enemy2direction == "Down")
            {
                char next = mazeforlevel1[s.enemy2Y + 4, s.enemy2X];
                if (mazeforlevel1[s.enemy2Y + 4, s.enemy2X] == '#')
                {
                    s.enemy2direction = "Up";
                }
                else if (next == ' ')
                {
                    eraseenemy2(s);
                    s.enemy2Y++;
                    printenemy2(s);
                }
            }
        }
        static void generatebullete2(coordinates s , List<bullete2> b2, char[,] mazeforlevel1)
        {
            bullete2 s1 = new bullete2();
            s1.bullete2X = s.enemy2X - 1;
            s1.bullete2Y = s.enemy2Y + 1;
            s1.isbulletActivee2 = true;
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(s.enemy2X - 1, s.enemy2Y + 1);
            Console.Write("*");
            mazeforlevel1[s.enemy2Y + 1, s.enemy2X - 1] = '*';
            b2.Add(s1);
            s.bulletcounte2++;
            //SetConsoleTextAttribute(hConsole, 7);
        }
        static void movebullete2(coordinates s, List<bullete2> b2, char[,] mazeforlevel1)
        {
            for (int x = 0; x < s.bulletcounte2; x++)
            {
                if (b2[x].isbulletActivee2 == true)
                {
                    char next = mazeforlevel1[b2[x].bullete2Y, b2[x].bullete2X - 1];
                    // char next = getCharAtxy(bullete2X[x] - 1, bullete2Y[x]);

                    if (next != ' ' || (s.playerX + 3 == b2[x].bullete2X))
                    {
                        erasebullet(b2[x].bullete2X, b2[x].bullete2Y);
                        mazeforlevel1[b2[x].bullete2Y, b2[x].bullete2X] = ' ';
                        makebulletInactivee2(x,b2);
                    }
                    else
                    {
                        erasebullet(b2[x].bullete2X, b2[x].bullete2Y);
                        mazeforlevel1[b2[x].bullete2Y, b2[x].bullete2X] = ' ';
                        b2[x].bullete2X = b2[x].bullete2X - 1;
                        printbulletfore2(b2[x].bullete2X, b2[x].bullete2Y);
                        mazeforlevel1[b2[x].bullete2Y, b2[x].bullete2X] = '*';
                    }
                }
            }
        }
        static void makebulletInactivee2(int x, List<bullete2> b2)
        {
            b2[x].isbulletActivee2 = false;
        }
        static void enemy2collisionwithbullet(coordinates s, List<bullet> b)
        {
            for (int x = 0; x < b.Count; x++) // enemy collision with bullet
            {

                if (b[x].isbulletActive == true)
                {
                    if (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y == b[x].bulletY))
                    {
                        printenemy2health(s);
                        printscore(s);
                    }
                    if (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y + 2 == b[x].bulletY))
                    {
                        printenemy2health(s);
                        printscore(s);
                    }
                    if (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y + 3 == b[x].bulletY))
                    {
                        printenemy2health(s);
                        printscore(s);
                    }
                    if (s.enemy2X - 1 == b[x].bulletX + 1 && (s.enemy2Y + 1 == b[x].bulletY))
                    {
                        printenemy2health(s);
                        printscore(s);
                    }
                }
            }
        }

        //            player collision with enemy

        static void playercollisionwithenemy1(coordinates s)
        {
            // player collision with enemy body

            if (s.playerX + 2 == s.enemy1X && (s.playerY == s.enemy1Y))
            {
                decreasedplayerhealth(s);
            }
            if (s.playerX + 1 == s.enemy1X + 2 && (s.playerY - 1 == s.enemy1Y + 1))
            {
                decreasedplayerhealth(s);
            }
            if (s.playerX - 1 == s.enemy1X + 4 && (s.playerY == s.enemy1Y))
            {
                decreasedplayerhealth(s);
            }
        }
        static void playercollisionwithenemy2(coordinates s)
        {
            // player collision with enemy body

            if (s.playerX + 2 == s.enemy2X - 1 && (s.playerY == s.enemy2Y + 2))
            {
                decreasedplayerhealth(s);
            }
            if (s.playerX + 1 == s.enemy2X + 3 && (s.playerY == s.enemy2Y + 4))
            {
                decreasedplayerhealth(s);
            }
            if (s.playerX + 1 == s.enemy2X + 4 && (s.playerY == s.enemy2Y + 4))
            {
                decreasedplayerhealth(s);
            }
            if (s.playerX + 1 == s.enemy2X + 5 && (s.playerY == s.enemy2Y + 4))
            {
                decreasedplayerhealth(s);
            }
        }

        //       player collision with bullet

        //                decrement enemy health
        static void decrementenemy1health(ref int enemy1health)
        {
            enemy1health = enemy1health - 20;
        }
        static void decrementenemy2health(ref int enemy2health)
        {
            enemy2health = enemy2health - 20;
        }

        //         player firing

        //               player firing for right

        static void generatebullet(coordinates s, List<bullet> b)
        {
            bullet s1 = new bullet();
            s1.bulletX = s.playerX + 3;
            s1.bulletY = s.playerY + 1;
            s1.isbulletActive = true;
            Console.SetCursorPosition(s.playerX + 3, s.playerY + 1);
            Console.Write("*");
            b.Add(s1);
            s.bulletcount++;
        }
        static void makebulletInactive(int index, List<bullet> b)
        {
            b[index].isbulletActive = false;
        }
        static void movebullet(coordinates s, List<bullet> b, char[,] mazeforlevel1)
        {
            for (int x = 0; x < s.bulletcount; x++)
            {
                if (b[x].isbulletActive == true)
                {
                    //  char next = getCharAtxy(bulletX[x] + 1, bulletY[x]);
                    if (mazeforlevel1[b[x].bulletY, b[x].bulletX + 1] != ' ' || (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y == b[x].bulletY))|| (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y + 2 == b[x].bulletY)) || (s.enemy2X == b[x].bulletX + 1 && (s.enemy2Y + 3 == b[x].bulletY)) || (s.enemy2X - 1 == b[x].bulletX + 1 && (s.enemy2Y + 1 == b[x].bulletY)))
                    {
                        erasebullet(b[x].bulletX, b[x].bulletY);
                        makebulletInactive(x, b);
                    }
                    else
                    {
                        erasebullet(b[x].bulletX, b[x].bulletY);
                        b[x].bulletX = b[x].bulletX + 1;
                        printbullet(b[x].bulletX, b[x].bulletY);
                    }
                }
            }
        }
        static void printbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }

        //                 player firing for left

        static void generatebulletl(coordinates s, List<bulletl> bl)
        {
            bulletl s1 = new bulletl();
            s1.bulletXl = s.playerX - 3;
            s1.bulletYl = s.playerY + 1;
            s1.isbulletActivel = true;
            Console.SetCursorPosition(s.playerX - 3, s.playerY + 1);
            Console.Write("*");
            bl.Add(s1);
            s.bulletcountl++;
        }
        static void makebulletInactivel(int index, List<bulletl> bl)
        {
            bl[index].isbulletActivel = false;
        }
        static void movebulletl(coordinates s, List<bulletl> b, char[,] mazeforlevel1)
        {
            for (int x = 0; x < s.bulletcountl; x++)
            {
                if (b[x].isbulletActivel == true)
                {
                    //  char next = getCharAtxy(bulletXl[x] - 1, bulletYl[x]);
                    if (mazeforlevel1[b[x].bulletYl, b[x].bulletXl - 1] != ' ')
                    {
                        erasebullet(b[x].bulletXl, b[x].bulletYl);
                        makebulletInactivel(x, b);
                    }
                    else
                    {
                        erasebullet(b[x].bulletXl, b[x].bulletYl);
                        b[x].bulletXl = b[x].bulletXl - 1;
                        printbullet(b[x].bulletXl, b[x].bulletYl);
                    }
                }
            }
        }

        //                player firing for up

        static void generatebulletu(coordinates s, List<bulletu> bu)
        {
            bulletu s1 = new bulletu();
            s1.bulletXu = s.playerX;
            s1.bulletYu = s.playerY - 1;
            s1.isbulletActiveu = true;
            Console.SetCursorPosition(s.playerX, s.playerY - 1);
            Console.Write("*");
            bu.Add(s1);
            s.bulletcountu++;
        }
        static void makebulletInactiveu(int index, List<bulletu> b)
        {
            b[index].isbulletActiveu = false;
        }
        static void movebulletu(coordinates s, List<bulletu> b, char[,] mazeforlevel1)
        {
            for (int x = 0; x < s.bulletcountu; x++)
            {
                if (b[x].isbulletActiveu == true)
                {
                    //    char next = getCharAtxy(bulletXu[x], bulletYu[x] - 1);
                    if (mazeforlevel1[b[x].bulletYu - 1, b[x].bulletXu] != ' ' || (s.enemy1X == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu)) || (s.enemy1X + 1 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu)) || (s.enemy1X + 2 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu)) || (s.enemy1X + 3 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu)) || (s.enemy1X + 4 == b[x].bulletXu && (s.enemy1Y + 2 == b[x].bulletYu)))
                    {
                        erasebullet(b[x].bulletXu, b[x].bulletYu);
                        makebulletInactiveu(x, b);
                    }
                    else
                    {
                        erasebullet(b[x].bulletXu, b[x].bulletYu);
                        b[x].bulletYu = b[x].bulletYu - 1;
                        printbullet(b[x].bulletXu, b[x].bulletYu);
                    }
                }
            }
        }

        //         player moevement   
        static void moveplayerup(coordinates s, char[,] mazeforlevel1)
        {
            eraseplayer(s, mazeforlevel1);
            s.playerY = s.playerY - 1;
            printplayer(s, mazeforlevel1);
        }
        static void moveplayerdown(coordinates s, char[,] mazeforlevel1)
        {
            eraseplayer(s, mazeforlevel1);
            s.playerY = s.playerY + 1;
            printplayer(s, mazeforlevel1);
        }
        static void moveplayerright(coordinates s, char[,] mazeforlevel1)
        {
            eraseplayer(s, mazeforlevel1);
            s.playerX = s.playerX + 1;
            printplayer(s, mazeforlevel1);
        }
        static void moveplayerleft(coordinates s, char[,] mazeforlevel1)
        {
            eraseplayer(s, mazeforlevel1);
            s.playerX = s.playerX - 1;
            printplayer(s, mazeforlevel1);
        }
        static void playercollisionwithenemybullet(coordinates s, List<bullet> b,char[,] mazeforlevel1)
        {
            //    colloisin from upside
            if (mazeforlevel1[s.playerY - 1, s.playerX] == 'o') //   ok
            {
                decreasedplayerhealth(s);
                mazeforlevel1[s.playerY - 1, s.playerX] = ' ';
            }
            //char next1 = getCharAtxy(playerX + 1, playerY - 1);
            if (mazeforlevel1[s.playerY -1, s.playerX +1] == 'o')
            {
                decreasedplayerhealth(s);
            }
            if (mazeforlevel1[s.playerY - 1, s.playerX + 2] == 'o')
            {
                decreasedplayerhealth(s);
            }

            //               colloision from front

            if (mazeforlevel1[s.playerY, s.playerX +3] == '*')
            {
                decreasedplayerhealth(s);
            }

            if (mazeforlevel1[s.playerY +1, s.playerX +3] == '*')
            {
                decreasedplayerhealth(s);
            }

            if (mazeforlevel1[s.playerY +2, s.playerX +3] == '*')
            {
                decreasedplayerhealth(s);
            }


        }


        //                enemy appear and disapper

        static void appeardisappearenemy1(coordinates s, List<bullet> b, List<bullete1> b1, char[,] mazeforlevel1)
        {
            if (s.enemy1health > 0) // print enemy and contol its movement and bullet
            {
                printenemy1(s);
                if (s.e1move % 2 == 0)
                {
                    enemy1movement(s, mazeforlevel1);
                }

                if (s.e1 % 6 == 0)
                {
                  generatebullete1(s,b1, mazeforlevel1);
                }
            }
            if (s.enemy1health <= 0) // erase enemy
            {
                eraseenemy1(s);
                s.enemy1X = 45;
                s.enemy1Y = 45;
            }
        }
        static void appeardisappearenemy2(coordinates s, List<bullet> b,List<bullete2> b2, char[,] mazeforlevel1)
        {
            if (s.enemy2health > 0) // print enemy and contol its movement and bullet
            {
                printenemy2(s);
                if (s.e2move % 3 == 0)
                {
                    enemy2movement(s, mazeforlevel1);
                }

                if (s.e2 % 7 == 0)
                {
                    generatebullete2(s,b2, mazeforlevel1);
                }
            }

            if (s.enemy2health <= 0) // erase enemy
            {
                eraseenemy2(s);
                s.enemy2X = 45;
                s.enemy2Y = 45;

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
