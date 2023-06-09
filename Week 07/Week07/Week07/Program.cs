using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week07.BL;

namespace Week07
{
    class Program
    {
        static void Main(string[] args)
        {
            // t1();
            // t2();
            //truck Truck = new truck();
            // HosePipe obj = new HosePipe();
            // Truck.sethosepie(obj);
            t3();
        }
        static void t1()
        {
            // for dayscholar
            Dayscholar std = new Dayscholar();
            std.name = "Ali";
            std.busno = 03;
            Console.WriteLine(std.name + " is allocated bus " + std.busno);
            Console.ReadKey();
        }
        static void t2()
        {
            //   for hostelide
            Hostilde std = new Hostilde();
            std.name = "Ahmed";
            std.roomnumber = 102;
            Console.WriteLine(std.name + " is allocated room number: " + std.roomnumber);
            Console.ReadKey();
        }
        static void t3()
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

    }

}
