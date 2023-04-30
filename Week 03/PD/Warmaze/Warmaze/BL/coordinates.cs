using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        public int bulletcountu;
        public int bulletcountl;
        public int bulletcount;

        
        public void printscore()
        {
            //   print and increment score
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:0");
            incrementscore();
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:" + score);
        }
        public void incrementscore()
        {
            score++;
        }
       
        //   enemy 1
        public void printenemy1()
        {

            char up = (char)94;
            char box = (char)219;

            char[,] enemy1 = new char[2, 5]  {
                { '-', box, box, box, '-'},
                { ' ', ' ', 'o', ' ', ' '}
                };

            //SetConsoleTextAttribute(hConsole, 1);
            Console.SetCursorPosition(enemy1X, enemy1Y);
            for (int y = 0; y < 2; y++)
            {
                Console.SetCursorPosition(enemy1X, enemy1Y + y);
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(enemy1[y, x]);
                }
            }
            //SetConsoleTextAttribute(hConsole, 7);
        }
        public void eraseenemy1()
        {
            char[,] enemy1 = new char[2, 5] {
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '}
                };

            Console.SetCursorPosition(enemy1X, enemy1Y);
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(enemy1[y, x]);
                }
                Console.SetCursorPosition(enemy1X,enemy1Y + 1);
            }
        }
        public void enemy1movement( char[,] mazeforlevel1)
        {
            if (enemy1direction == "Right")
            {
                char next = mazeforlevel1[enemy1Y, enemy1X + 5];
                if (enemy1X == 75 && enemy1Y == 1)
                {
                    enemy1direction = "Left";
                }
                else if (next == ' ')
                {
                    eraseenemy1();
                    enemy1X++;
                    printenemy1();
                }
            }
            if (enemy1direction == "Left")
            {
                char next = mazeforlevel1[enemy1Y, enemy1X - 1];
                if (enemy1X == 13 && enemy1Y == 1)
                {
                    enemy1direction = "Right";
                }
                else if (next == ' ')
                {
                    eraseenemy1();
                    enemy1X--;
                    printenemy1();
                }
            }
        }
        public void generatebullete1( List<bullete1> b1, char[,] mazeforlevel1)
        {
            bullete1 s1 = new bullete1();
            s1.bullete1X = enemy1X + 2;
            s1.bullete1Y = enemy1Y + 2;
            s1.isbulletActivee1 = true;
            Console.SetCursorPosition(enemy1X + 2, enemy1Y + 2);
            //SetConsoleTextAttribute(hConsole, 1);
            Console.Write("o");
            mazeforlevel1[enemy1Y + 2, enemy1X + 2] = 'o';
            b1.Add(s1);
            bulletcounte1++;
            //SetConsoleTextAttribute(hConsole, 7);
        }
     
        //            enemy 2
        public void printenemy2()
        {

            char[,] enemy2 = new char[4, 6]{
                { ' ', ' ', ' ', '-', '-', '-'},
                { '<', '=', '=', '(', '-', ')'},
                { ' ', ' ', ' ', '\\', '@', '/'},
                { ' ', ' ', ' ', '*', '*', '*'}
                };
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(enemy2X, enemy2Y);

            for (int y = 0; y < 4; y++)
            {
                Console.SetCursorPosition(enemy2X, enemy2Y + y);
                for (int x = 0; x < 6; x++)
                {
                    Console.Write(enemy2[y, x]);
                }
            }
            //SetConsoleTextAttribute(hConsole, 7);
        }
        public void eraseenemy2()
        {
            char[,] enemy2 = new char[4, 6]{
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' '}
                };
            //gotoxy(enemy2X, enemy2Y);
            Console.SetCursorPosition(enemy2X, enemy2Y);
            for (int y = 0; y < 4; y++)
            {
                Console.SetCursorPosition(enemy2X, enemy2Y + y);
                for (int x = 0; x < 6; x++)
                {
                    Console.Write(enemy2[y, x]);
                }
            }
        }
        public void enemy2movement(char[,] mazeforlevel1)
        {
            if (enemy2direction == "Up")
            {
                char next = mazeforlevel1[enemy2Y - 1, enemy2X];
                if (enemy2X == 101 && enemy2Y == 6)
                {
                    enemy2direction = "Down";
                }
                else if (next == ' ')
                {
                    eraseenemy2();
                    enemy2Y--;
                    printenemy2();
                }
            }

            if (enemy2direction == "Down")
            {
                char next = mazeforlevel1[enemy2Y + 4, enemy2X];
                if (mazeforlevel1[enemy2Y + 4, enemy2X] == '#')
                {
                    enemy2direction = "Up";
                }
                else if (next == ' ')
                {
                    eraseenemy2();
                    enemy2Y++;
                    printenemy2();
                }
            }
        }
        public void printenemy2health()
        {
            //   print and decrement enemy health

            Console.SetCursorPosition(111, 16);
            Console.Write("Enemy 2 Health:100");
            enemy2health = enemy2health - 5;
            Console.SetCursorPosition(111, 16);
            Console.Write("                   ");
            if (enemy2health <= 0)
            {
                enemy2health = 0;
            }
            Console.SetCursorPosition(111, 16);
            Console.Write("Enemy 2 Health:" +enemy2health);
        }
        public void generatebullete2( List<bullete2> b2, char[,] mazeforlevel1)
        {
            bullete2 s1 = new bullete2();
            s1.bullete2X = enemy2X - 1;
            s1.bullete2Y = enemy2Y + 1;
            s1.isbulletActivee2 = true;
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(enemy2X - 1,enemy2Y + 1);
            Console.Write("*");
            mazeforlevel1[enemy2Y + 1, enemy2X - 1] = '*';
            b2.Add(s1);
            bulletcounte2++;
            //SetConsoleTextAttribute(hConsole, 7);
        }
        //         printing enemy healths
        public void printenemy1health()
        {
            //   print and decrement enemy health

            Console.SetCursorPosition(111, 15);
            Console.Write("Enemy 1 Health:100");
            enemy1health = enemy1health - 5;
            Console.SetCursorPosition(111, 15);
            Console.Write("                   ");
            if (enemy1health <= 0)
            {
                enemy1health = 0;
            }
            Console.SetCursorPosition(111, 15);
            Console.Write("Enemy 1 Health:" + enemy1health);
        }
        //            player collision with enemy

        public void playercollisionwithenemy1()
        {
            // player collision with enemy body

            if (playerX + 2 == enemy1X && (playerY == enemy1Y))
            {
                decreasedplayerhealth();
            }
            if (playerX + 1 == enemy1X + 2 && (playerY - 1 == enemy1Y + 1))
            {
                decreasedplayerhealth();
            }
            if (playerX - 1 == enemy1X + 4 && (playerY == enemy1Y))
            {
                decreasedplayerhealth();
            }
        }
        public void playercollisionwithenemy2()
        {
            // player collision with enemy body

            if (playerX + 2 == enemy2X - 1 && (playerY == enemy2Y + 2))
            {
                decreasedplayerhealth();
            }
            if (playerX + 1 == enemy2X + 3 && (playerY == enemy2Y + 4))
            {
                decreasedplayerhealth();
            }
            if (playerX + 1 == enemy2X + 4 && (playerY == enemy2Y + 4))
            {
                decreasedplayerhealth();
            }
            if (playerX + 1 == enemy2X + 5 && (playerY == enemy2Y + 4))
            {
                decreasedplayerhealth();
            }
        }
        public void decreasedplayerhealth()
        {
            Console.SetCursorPosition(111, 13);
            Console.Write("                 ");
            decrementplayerhealthbybullet();
            Console.SetCursorPosition(111, 13);
            if (playerhealth < 0)
            {
                playerhealth = 0;
            }
            Console.Write("Player Health:" + playerhealth);
        }
        public void decrementplayerhealthbybullet()
        {
            playerhealth--;
        }

        //    players
        public void printplayer( char[,] mazeforlevel1)
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
            Console.SetCursorPosition(playerX, playerY);

            for (int y = 0; y < 3; y++)
            {
                Console.SetCursorPosition(playerX, playerY + y);
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(player[y, x]);

                }
            }

        }
        public void eraseplayer(char[,] mazeforlevel1)
        {
            char[,] player = new char[3, 3]  {
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '}
                };
            Console.SetCursorPosition(playerX, playerY);

            for (int y = 0; y < 3; y++)
            {
                Console.SetCursorPosition(playerX, playerY + y);
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(player[y, x]);

                }
            }
        }
        //         player moevement   
        public void moveplayerup(char[,] mazeforlevel1)
        {
            eraseplayer(mazeforlevel1);
            playerY = playerY - 1;
            printplayer( mazeforlevel1);
        }
        public void moveplayerdown(char[,] mazeforlevel1)
        {
            eraseplayer(mazeforlevel1);
            playerY = playerY + 1;
            printplayer(mazeforlevel1);
        }
        public void moveplayerright( char[,] mazeforlevel1)
        {
            eraseplayer(mazeforlevel1);
            playerX = playerX + 1;
            printplayer(mazeforlevel1);
        }
        public void moveplayerleft(char[,] mazeforlevel1)
        {
            eraseplayer( mazeforlevel1);
            playerX = playerX - 1;
            printplayer( mazeforlevel1);
        }
        public void playercollisionwithenemybullet( char[,] mazeforlevel1)
        {
            //    colloisin from upside
            if (mazeforlevel1[playerY - 1, playerX] == 'o') //   ok
            {
                decreasedplayerhealth();
                mazeforlevel1[playerY - 1, playerX] = ' ';
            }
            //char next1 = getCharAtxy(playerX + 1, playerY - 1);
            if (mazeforlevel1[playerY - 1, playerX + 1] == 'o')
            {
                decreasedplayerhealth();
            }
            if (mazeforlevel1[playerY - 1, playerX + 2] == 'o')
            {
                decreasedplayerhealth();
            }

            //               colloision from front

            if (mazeforlevel1[playerY, playerX + 3] == '*')
            {
                decreasedplayerhealth();
            }

            if (mazeforlevel1[playerY + 1, playerX + 3] == '*')
            {
                decreasedplayerhealth();
            }

            if (mazeforlevel1[playerY + 2, playerX + 3] == '*')
            {
                decreasedplayerhealth();
            }


        }
        
        //        players firing
        public void generatebullet( List<bullet> b)
        {
            bullet s1 = new bullet();
            s1.bulletX = playerX + 3;
            s1.bulletY = playerY + 1;
            s1.isbulletActive = true;
            Console.SetCursorPosition(playerX + 3, playerY + 1);
            Console.Write("*");
            b.Add(s1);
            bulletcount++;
        }
        public void generatebulletl( List<bulletl> bl)
        {
            bulletl s1 = new bulletl();
            s1.bulletXl = playerX - 3;
            s1.bulletYl = playerY + 1;
            s1.isbulletActivel = true;
            Console.SetCursorPosition(playerX - 3, playerY + 1);
            Console.Write("*");
            bl.Add(s1);
            bulletcountl++;
        }
        public void generatebulletu( List<bulletu> bu)
        {
            bulletu s1 = new bulletu();
            s1.bulletXu = playerX;
            s1.bulletYu = playerY - 1;
            s1.isbulletActiveu = true;
            Console.SetCursorPosition(playerX, playerY - 1);
            Console.Write("*");
            bu.Add(s1);
            bulletcountu++;
        }

        //                enemy appear and disapper
        public void appeardisappearenemy1(List<bullet> b, List<bullete1> b1, char[,] mazeforlevel1)
        {
            if (enemy1health > 0) // print enemy and contol its movement and bullet
            {
                printenemy1();
                if (e1move % 2 == 0)
                {
                    enemy1movement(mazeforlevel1);
                }

                if (e1 % 6 == 0)
                {
                    generatebullete1(b1, mazeforlevel1);
                }
            }
            if (enemy1health <= 0) // erase enemy
            {
                eraseenemy1();
                enemy1X = 45;
                enemy1Y = 45;
            }
        }
        public void appeardisappearenemy2( List<bullet> b, List<bullete2> b2, char[,] mazeforlevel1)
        {
            if (enemy2health > 0) // print enemy and contol its movement and bullet
            {
                printenemy2();
                if (e2move % 3 == 0)
                {
                    enemy2movement(mazeforlevel1);
                }

                if (e2 % 7 == 0)
                {
                    generatebullete2(b2, mazeforlevel1);
                }
            }

            if (enemy2health <= 0) // erase enemy
            {
                eraseenemy2();
                enemy2X = 45;
                enemy2Y = 45;

            }
        }

        //        others
        public void displayallvalues()
        {
            Console.SetCursorPosition(111, 13);
            Console.Write("Player Health:" + playerhealth);
            Console.SetCursorPosition(111, 14);
            Console.Write("Score:" + score);
            Console.SetCursorPosition(111, 15);
            //SetConsoleTextAttribute(hConsole, 1);
            Console.Write("Enemy 1 Health:" + enemy1health);
            Console.SetCursorPosition(111, 16);
            //SetConsoleTextAttribute(hConsole, 2);
            Console.Write("Enemy 2 Health:" + enemy2health);
            Console.SetCursorPosition(111, 17);
            //SetConsoleTextAttribute(hConsole, 4);
            Console.Write("Enemy 3 Health:" + enemy3health);
            Console.SetCursorPosition(111, 18);
            //SetConsoleTextAttribute(hConsole, 5);
            Console.Write("Enemy 4 Health:" + enemy4health);
            Console.SetCursorPosition(111, 19);
            //SetConsoleTextAttribute(hConsole, 6);
            Console.Write("Enemy 5 Health:" + enemy5health);
            Console.SetCursorPosition(111, 20);
            //SetConsoleTextAttribute(hConsole, 4);
            Console.Write("Enemy 6 Health:" + enemy6health);
            //SetConsoleTextAttribute(hConsole, 7);
        }
        public void resetbulletcountforallenemy()
        {
            bulletcounte1 = 0;
            bulletcounte2 = 0;
            bulletcount = 0;
            bulletcountl = 0;
            bulletcountu = 0;
        }
        public void gameoverbyhealth()
        {
            if (playerhealth <= 0)
            {
                Console.Clear();
                header();
                Console.WriteLine(" Game Over!!!");
                Console.WriteLine(" Score:" + score);
                Console.WriteLine();
                Console.Write("  Press any key to continue:");
                Console.ReadKey();
            }
        }
        public void loading1()
        {
            Console.WriteLine();
            Console.Write(" Calculating score ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("-");
                Thread.Sleep(300);
            }
        }
        public  void header()
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
        public void endgame()
        {
            Console.Clear(); // end the game
            loading1();
            Console.Clear();
            header();
            Console.WriteLine();
            Console.WriteLine("Game Over!!!");
            Console.WriteLine("Score:" + score);
            Console.Write("Press any key to Continue:");
            Console.ReadLine();
        }
        public int newloadgame()
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
        public void printmaze(char[,] mazeforlevel1)
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
        public void clear()
        {

            Console.WriteLine();
            Console.Write("Press any Key to continue: ");
            Console.ReadKey();
            Console.Clear();
        }
        public void keys()
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
        public void instruction()
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
        public int submenu()
        {
            coordinates s = new coordinates();
            Console.Clear();
            int option = 0;
            s.header();
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
        public int menu()
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
        public int savegamemenu()
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
    }

    class bullet
    {
        // player bullet

        public int bulletX; //    for right
        public int bulletY;
        public bool isbulletActive;
        public void enemy2collisionwithbullet(coordinates s)
        {

                if (isbulletActive == true)
                {
                    if (s.enemy2X == bulletX + 1 && (s.enemy2Y ==bulletY))
                    {
                        s.printenemy2health();
                        s.printscore();
                    }
                    if (s.enemy2X == bulletX + 1 && (s.enemy2Y + 2 == bulletY))
                    {
                        s.printenemy2health();
                        s.printscore();
                    }
                    if (s.enemy2X == bulletX + 1 && (s.enemy2Y + 3 == bulletY))
                    {
                        s.printenemy2health();
                        s.printscore();
                    }
                    if (s.enemy2X - 1 == bulletX + 1 && (s.enemy2Y + 1 == bulletY))
                    {
                        s.printenemy2health();
                        s.printscore();
                    }
                }
        }

        //               player firing for right

        public void makebulletInactive()
        {
            isbulletActive = false;
        }
        public void movebullet(coordinates s, char[,] mazeforlevel1)
        {
                if (isbulletActive == true)
                {
                    //  char next = getCharAtxy(bulletX[x] + 1, bulletY[x]);
                    if (mazeforlevel1[bulletY, bulletX + 1] != ' ' || (s.enemy2X == bulletX + 1 && (s.enemy2Y == bulletY)) || (s.enemy2X == bulletX + 1 && (s.enemy2Y + 2 == bulletY)) || (s.enemy2X == bulletX + 1 && (s.enemy2Y + 3 == bulletY)) || (s.enemy2X - 1 == bulletX + 1 && (s.enemy2Y + 1 == bulletY)))
                    {
                        erasebullet(bulletX,bulletY);
                        makebulletInactive();
                    }
                    else
                    {
                        erasebullet(bulletX, bulletY);
                        bulletX =bulletX + 1;
                        printbullet(bulletX,bulletY);
                    }
                }   
        }
        public void printbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        public void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

    }
    class bulletl
    {
        public int bulletXl;
        public int bulletYl;
        public bool isbulletActivel;
       
        //                 player firing for left

        public void makebulletInactivel()
        {
            isbulletActivel = false;
        }
        public void movebulletl(coordinates s, char[,] mazeforlevel1)
        {

                if (isbulletActivel == true)
                {
                    //  char next = getCharAtxy(bulletXl[x] - 1, bulletYl[x]);
                    if (mazeforlevel1[bulletYl, bulletXl - 1] != ' ')
                    {
                        erasebullet(bulletXl, bulletYl);
                        makebulletInactivel();
                    }
                    else
                    {
                        erasebullet(bulletXl, bulletYl);
                        bulletXl = bulletXl - 1;
                        printbullet(bulletXl, bulletYl);
                    }
                }
            
        }
        public void printbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        public void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }


    }
    class bulletu
    {
        public int bulletXu;
        public int bulletYu;
        public bool isbulletActiveu;

        public void enemy1collisionwithbullet(coordinates s)
        {

                if (isbulletActiveu == true)
                {
                    if (s.enemy1X == bulletXu && (s.enemy1Y + 2 == bulletYu))
                    {
                        s.printenemy1health();
                        s.printscore();
                    }
                    if (s.enemy1X + 1 == bulletXu && (s.enemy1Y + 2 == bulletYu))
                    {
                        s.printenemy1health();
                        s.printscore();
                }
                    if (s.enemy1X + 2 == bulletXu && (s.enemy1Y + 2 == bulletYu))
                    {
                        s.printenemy1health();
                        s.printscore();
                }
                    if (s.enemy1X + 3 == bulletXu && (s.enemy1Y + 2 ==bulletYu))
                    {
                        s.printenemy1health();
                        s.printscore();
                }
                    if (s.enemy1X + 4 == bulletXu && (s.enemy1Y + 2 == bulletYu))
                    {
                        s.printenemy1health();
                        s.printscore();
                }
                }
        }

        public void makebulletInactiveu()
        {
            isbulletActiveu = false;
        }
        public void movebulletu(coordinates s, char[,] mazeforlevel1)
        {

                if (isbulletActiveu == true)
                {
                    //    char next = getCharAtxy(bulletXu[x], bulletYu[x] - 1);
                    if (mazeforlevel1[bulletYu - 1, bulletXu] != ' ' || (s.enemy1X == bulletXu && (s.enemy1Y + 2 == bulletYu)) || (s.enemy1X + 1 == bulletXu && (s.enemy1Y + 2 == bulletYu)) || (s.enemy1X + 2 == bulletXu && (s.enemy1Y + 2 == bulletYu)) || (s.enemy1X + 3 == bulletXu && (s.enemy1Y + 2 ==bulletYu)) || (s.enemy1X + 4 ==bulletXu && (s.enemy1Y + 2 == bulletYu)))
                    {
                        erasebullet(bulletXu, bulletYu);
                        makebulletInactiveu();
                    }
                    else
                    {
                        erasebullet(bulletXu, bulletYu);
                       bulletYu = bulletYu - 1;
                        printbullet(bulletXu, bulletYu);
                    }
                }
            
        }
        public void printbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        public void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

    }

    class bullete2
    {
        public int bullete2X;
        public int bullete2Y;
        public bool isbulletActivee2;
        public void movebullete2(coordinates s, char[,] mazeforlevel1)
        {

                if (isbulletActivee2 == true)
                {
                    char next = mazeforlevel1[bullete2Y, bullete2X - 1];
                    // char next = getCharAtxy(bullete2X[x] - 1, bullete2Y[x]);

                    if (next != ' ' || (s.playerX + 3 == bullete2X))
                    {
                        erasebullet(bullete2X, bullete2Y);
                        mazeforlevel1[bullete2Y, bullete2X] = ' ';
                        makebulletInactivee2();
                    }
                    else
                    {
                        erasebullet(bullete2X, bullete2Y);
                        mazeforlevel1[bullete2Y, bullete2X] = ' ';
                        bullete2X = bullete2X - 1;
                        printbulletfore2(bullete2X,bullete2Y);
                        mazeforlevel1[bullete2Y,bullete2X] = '*';
                    }
                }
            
        }
        public void makebulletInactivee2()
        {
            isbulletActivee2 = false;
        }
        public void printbulletfore2(int x, int y)
        {
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            //SetConsoleTextAttribute(hConsole, 7);
        }
        public void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }

    class bullete1
    {
        public int bullete1X;
        public int bullete1Y;
        public bool isbulletActivee1;
        public void movebullete1(coordinates s, char[,] mazeforlevel1)
        {

                if (isbulletActivee1 == true)
                {
                    char next = mazeforlevel1[bullete1Y + 1, bullete1X];
                    if (next != ' ' || (s.playerY - 1 == bullete1Y))
                    {
                        erasebullet(bullete1X, bullete1Y);
                        mazeforlevel1[bullete1Y, bullete1X] = ' ';
                        makebulletInactivee1();
                    }
                    else if (next == ' ')
                    {
                        erasebullet(bullete1X, bullete1Y);
                        mazeforlevel1[bullete1Y, bullete1X] = ' ';
                        bullete1Y = bullete1Y + 1;
                        printbulletfore1(bullete1X, bullete1Y);
                        mazeforlevel1[bullete1Y, bullete1X] = 'o';
                    }
                }
            
        }
        public void makebulletInactivee1()
        {
           isbulletActivee1 = false;
        }
        public void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void printbulletfore1(int x, int y)
        {
            //SetConsoleTextAttribute(hConsole, 1);
            Console.SetCursorPosition(x, y);
            Console.Write("o");
            //SetConsoleTextAttribute(hConsole, 7);
        }
    }
}
