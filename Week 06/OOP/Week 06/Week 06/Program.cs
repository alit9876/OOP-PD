using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06.UI;
using Week_06.BL;
using System.Threading;
using Week_06.DL;

namespace Week_06
{
    class Program
    {
        public static Coffeeshop shop = ShopCRUD.nameofshop();
        static void Main(string[] args)
        {
            //challenge1();
            //challenge2();            
        }
        static void challenge1()
        {
            int option = -1;
            while (option != 9)
            {
                Console.Clear();
                option = ShopCRUD.menu(shop.name);
                Console.Clear();
                if (option == 1)
                {
                    MenuItem obj = ShopCRUD.inputforaddmenu();
                    Listmenucs.addmenuintomenulist(shop, obj);
                }
                if (option == 2)
                {
                    MenuItem obj = Listmenucs.productwithcheapestprice(shop);
                    ShopCRUD.viewcheapest(obj);
                }
                if (option == 3)
                {
                    ShopCRUD.viewdrinkmenu(shop);
                }
                if (option == 4)
                {
                    ShopCRUD.viewFoodmenu(shop);
                    Console.ReadKey();
                }
                if (option == 5)
                {
                    MenuItem obj = ShopCRUD.addoredered();
                    bool check = Listmenucs.verifyproductavailability(shop, obj);
                    if (check)
                    {
                        Listmenucs.addproductintoorderedlist(shop, obj);
                    }
                    else
                    {
                        ShopCRUD.elseforordernot();
                    }
                }
                if (option == 6)
                {
                    bool check = Listmenucs.orderfullyavailablility(shop);
                    if (check)
                    {
                        Listmenucs.fullfilledordered(shop);
                        Listmenucs.emptylist(shop);
                    }
                    else
                    {
                        ShopCRUD.elseforfulldfillodered();
                    }
                }
                if (option == 7)
                {
                    bool check = Listmenucs.orderfullyavailablility(shop);
                    if (check)
                    {
                        Listmenucs.viewallorderedlist(shop);
                    }
                    else
                    {
                        ShopCRUD.elseforoption7();
                    }

                }
                if (option == 8)
                {
                    float price = Listmenucs.calculatetotal(shop);
                    ShopCRUD.totalprice(price);

                }
                Console.ReadKey();
            }
        }
        static void challenge2()
        {
            char[,] gameobj = new char[5, 3] { { '*', ' ', ' ' }, { '*', '*', ' ' }, { '*', '*', '*' }, { '*', '*', ' ' }, { '*', ' ', ' ' } };
            char[,] gameobj1 = new char[5, 3] { { ' ', ' ', '*' }, { ' ', '*', '*' }, { '*', '*', '*' }, { ' ', '*', '*' }, { ' ', ' ', '*' } };
            char[,] gameobj3 = new char[5, 3] { { '*', ' ', ' ' }, { '*', '*', ' ' }, { '*', '*', '*' }, { '*', '*', ' ' }, { '*', ' ', ' ' } };
            Boundary b = new Boundary(new point(0, 0), new point(0, 90), new point(90, 0), new point(90, 90));
            GameObject g1 = new GameObject(gameobj, new point(10, 5), "left", b);
            GameObject g2 = new GameObject(gameobj1, new point(80, 10), "right", b);
            GameObject g3 = new GameObject(gameobj3, new point(80, 20), "right", b);
            GameObject g4 = new GameObject(gameobj3, new point(85, 85), "diagonal", b);
            GameObject g5 = new GameObject(gameobj3, new point(40, 15), "projectile", b);
            List<GameObject> obj = new List<GameObject>();
            obj.Add(g1);
            obj.Add(g2);
            obj.Add(g3);
            obj.Add(g4);
            obj.Add(g5);
            while (true)
            {
                Thread.Sleep(1000);
                foreach (GameObject g in obj)
                {
                    g.erase();
                    g.move();
                    g.move1();
                     g.move2();
                      g.move3();
                    g.move4();
                    g.shapeprint();
                }

            }
        }
        
    }
    }

