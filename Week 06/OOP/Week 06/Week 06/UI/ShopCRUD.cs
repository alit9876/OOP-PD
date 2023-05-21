using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week_06.BL;
using System.Threading.Tasks;

namespace Week_06.UI
{
    class ShopCRUD
    {
        
        public static int menu(string name)
        {
            int option = 0;
            Console.WriteLine(" Welcome to the " + name + "'s Coffe Shop");
            Console.WriteLine();
            Console.WriteLine(" 1. Add a menu item");
            Console.WriteLine(" 2. View the Cheapest menu in the menu");
            Console.WriteLine(" 3. View the drink's menu");
            Console.WriteLine(" 4. View the food's menu");
            Console.WriteLine(" 5. Add Order");
            Console.WriteLine(" 6. Fullfill the Order");
            Console.WriteLine(" 7. View the Orders's List");
            Console.WriteLine(" 8. Total Payable Amount");
            Console.WriteLine(" 9. Exit");
            Console.Write(" Enter your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static Coffeeshop nameofshop()
        {
            Console.WriteLine();
            Console.Write(" Enter name of your shop: ");
            string name = Console.ReadLine();
            Coffeeshop obj = new Coffeeshop(name); 
            return obj;
        }
        public static MenuItem inputforaddmenu()
        {
            Console.WriteLine();
            Console.Write(" Enter name of the product: ");
            string name = Console.ReadLine();
            Console.Write(" ENter type of product: ");
            string type = Console.ReadLine();
            Console.Write(" Enter price of product: ");
            float price = float.Parse(Console.ReadLine());
            MenuItem obj = new MenuItem(name, type, price);
            return obj;
        }
        public static void viewcheapest(MenuItem obj)
        {
            Console.WriteLine();
            Console.WriteLine(" Name\tType\tPrice");
            Console.WriteLine();
            Console.WriteLine(obj.name + "  " + obj.type + " " + obj.price);
        }
        public static void viewdrinkmenu(Coffeeshop obj)
        {
            Console.WriteLine();
            Console.WriteLine("Name\tType\tPrice");
            Console.WriteLine();
            for(int x=0;x<obj.menulist.Count;x++)
            {
                if(obj.menulist[x].type == "Drink")
                {
                    Console.WriteLine(obj.menulist[x].name + " " + obj.menulist[x].type + " " + obj.menulist[x].price);
                }
            }
        }
        public static void viewFoodmenu(Coffeeshop obj)
        {
            Console.WriteLine();
            Console.WriteLine("Name\tType\tPrice");
            Console.WriteLine();
            for (int x = 0; x < obj.menulist.Count; x++)
            {
                if (obj.menulist[x].type == "Food")
                {
                    Console.WriteLine(obj.menulist[x].name + " " + obj.menulist[x].type + " " + obj.menulist[x].price);
                }
            }
        }
        public static MenuItem addoredered()
        {
            Console.WriteLine();
            Console.Write(" Enter the name of product: ");
            string name = Console.ReadLine();
            MenuItem obj = new MenuItem(name);
            return obj;
        }
        public static void elseforordernot()
        {
            Console.WriteLine();
            Console.WriteLine(" The item is currently unavailable");
        }
        public static void elseforfulldfillodered()
        {
            Console.WriteLine();
            Console.WriteLine(" All Ordered has been fullfilled");
        }
        public static void viewfullfilledorderd( string ordered)
        {
            Console.WriteLine();
            Console.WriteLine("The " + ordered + " is ready.");
        }
        public static void showorderedlist(string ordered)
        {
            Console.WriteLine();
            Console.WriteLine("Ordered item are: " + ordered);
        }
        public static void elseforoption7()
        {
            Console.WriteLine();
            Console.WriteLine(" All item has been exhausted");
        }
        public static void totalprice(float price)
        {
            Console.WriteLine();
            Console.WriteLine(" The total bill is: " + price); ;
        }

        }
    
}
