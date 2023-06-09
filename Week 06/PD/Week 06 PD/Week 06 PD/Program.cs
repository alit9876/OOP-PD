using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Week_06_PD.BL;

namespace Week_06_PD
{
    class Program
    {
        static void Main(string[] args)
        {
            //t1();
            //t2();
        }
        static void t1()
        {
            int option = 0;
            do
            {
                Console.WriteLine(" Enter 1 to play the game. ");
                Console.WriteLine(" ENter 2 to exit the game. ");
                Console.Write(" Your choice:");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    bool gamerunnig = true;
                    int score = 0;
                    Deck obj = new Deck();
                    obj.shuffle();
                    card card1 = obj.dealCard();
                    while (gamerunnig)
                    {
                        int remain_check = obj.cardsLeft();
                        card card2 = obj.dealCard();
                        Console.WriteLine("****************************************************");
                        Console.WriteLine(card1.tostring());
                        Console.WriteLine(" ");
                        Console.WriteLine(" *****  Reamining Cards  *************");
                        Console.WriteLine(" Enter 1 if the next card is higher. ");
                        Console.WriteLine(" Enter 2 if the next card is lower. ");

                        int card_check = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (card2.getvalue() >= card1.getvalue())
                        {
                            score++;
                            card1 = card2;
                        }
                        else
                        {
                            gamerunnig = false;
                            Console.WriteLine(" SOORY YOU LOOSE ! PRESSA ANY KEY TO CONTINUE");
                            Console.WriteLine(" The card was " + card2.tostring());
                            Console.WriteLine(" Your score is: " + score);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        if (card_check == 2)
                        {
                            if (card2.getvalue() < card1.getvalue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                gamerunnig = false;
                                Console.WriteLine(" SOORY YOU LOOSE ! PRESSA ANY KEY TO CONTINUE");
                                Console.WriteLine(" The card was " + card2.tostring());
                                Console.WriteLine(" Your score is: " + score);
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        if (obj.cardsLeft() == 0 && card2 == null)
                        {
                            gamerunnig = false;
                            Console.WriteLine(" Congrat you have won the game. ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }
            } while (option != 2);
        }
        static void t2()
        {
            string path = "maze.txt";
            Grid mazegrid = new Grid(24, 71, path);
            Pacman player = new Pacman(9, 32, mazegrid);
            Ghost g1 = new Ghost(15, 39, "left",'H', 0.1F, ' ', mazegrid);
            Ghost g2 = new Ghost(20, 37, "up", 'V', 0.2F, ' ', mazegrid);
            Ghost g3 = new Ghost(19, 26, "up", 'R', 1F,' ',mazegrid) ;
            Ghost g4 = new Ghost(18,21,"up",'C',0.5F,' ',mazegrid);

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(g1);
            enemies.Add(g2);
            enemies.Add(g3);
            enemies.Add(g4);

            mazegrid.Draw();
            player.Print(player.X, player.Y);

            bool gamerunnig = true;
            while(gamerunnig)
            {
                Thread.Sleep(90);
                player.PrintScore();
                player.Remove(player.X,player.Y);
                player.Move();
                player.Print(player.X, player.Y);

                foreach(Ghost g in enemies)
                {
                    g.Remove(g.X,g.Y);
                    g.move();
                    g.Print(g.X,g.Y);
                }

                Console.ReadKey();
            }
        }
    }
}
