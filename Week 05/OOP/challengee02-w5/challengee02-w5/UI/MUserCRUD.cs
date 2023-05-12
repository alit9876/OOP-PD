using challengee02_w5.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengee02_w5.UI
{
     class MUserCRUD
    {
        public static int menu()
        {
            Console.WriteLine();
            Console.WriteLine(" 1. Sign In");
            Console.WriteLine(" 1. Sign Up");
            Console.WriteLine(" 3.Exit");
            Console.Write(" Enter your choice: ");
            int menu = int.Parse(Console.ReadLine());
            return menu;
        }
        public static MUser signin()
        {
            Console.WriteLine();
            Console.WriteLine("    Sign In   ");
            Console.WriteLine();
            Console.Write(" Enter your name: ");
            string name = Console.ReadLine();
            Console.Write(" ENter your password: ");
            string password = Console.ReadLine();
            MUser s = new MUser(name, password);
            return s;
        }
        public static MUser signUp()
        {
            Console.WriteLine();
            Console.WriteLine("          Sign Up");
            Console.WriteLine();
            Console.Write(" Enter your name: ");
            string name = Console.ReadLine();
            Console.Write(" ENter your password: ");
            string password = Console.ReadLine();
            Console.Write(" Enter your role: ");
            string role = Console.ReadLine();
            MUser s = new MUser(name, password,role);
            return s;
        }
        public static void notuserfound()
        {
            Console.Write(" USer not found!!!!");
        }
        public static int adminmenu()
        {
            int option = 0;
            Console.WriteLine(" 1. Add");
            Console.WriteLine(" 2. View all product");
            Console.WriteLine(" 3. Find product with highest Unit Price");
            Console.WriteLine(" 4. View sale Tax of all product");
            Console.WriteLine(" 5. Product to be Ordered");
            Console.WriteLine(" 6. Exit");
            Console.Write("ENter your choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public  static Product takeInputProduct()
        {
            Console.WriteLine();
            Console.Write(" Enter name of Product: ");
            string name = Console.ReadLine();
            Console.Write(" Enter category: ");
            string category = Console.ReadLine();
            Console.Write(" Enter Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write(" Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write(" Enter Minmum value: ");
            int threshold = int.Parse(Console.ReadLine());
            Product obj = new Product(name, category,price,quantity,threshold);
            return obj;
        }
        public static void headerforadminoption2()
        {
            Console.WriteLine();
            Console.WriteLine("                 All Products                 ");
            Console.WriteLine();
            Console.WriteLine("Name \tCategory\tPrice\tStock\tTHreshold value");
            Console.WriteLine();
        }
        public static void displayallproduct(Product p)
        {
            Console.WriteLine(p.productnmae+"\t"+p.category + "\t" +p.price + "\t" +p.Astockquantity + "\t" +p.thresholdstock);
        }
        public static void displayhighestP(Product p)
        {
            Console.WriteLine();
            Console.WriteLine("          Product With highest Price               ");
            Console.WriteLine();
            Console.WriteLine("Name \tCategory\tPrice\tStock");
            Console.WriteLine();
            Console.WriteLine(p.productnmae + "\t" + p.category + "\t" + p.price + "\t" + p.Astockquantity);
        }
        public static void displaytax(Product p)
        {
            Console.WriteLine(p.productnmae + "\t" + p.category + "\t" + p.price + "\t" + p.tax);
        }
        public static void headerforsaletax()
        {
            Console.WriteLine();
            Console.WriteLine("    Sale Tax of All Product");
            Console.WriteLine();
            Console.WriteLine("Name \tCategory\tPrice\tSaleTax");
            Console.WriteLine();
        }
        public static void displayproducttobeordered(Product p)
        {
            Console.WriteLine();
            Console.WriteLine(" The Product to be ordered are: " + p.productnmae);
        }
        public static void displatelsefororedertobeorder()
        {
            Console.WriteLine();
            Console.WriteLine(" No Product needed to be orderd");
        }
        public static void clear()
        {
            Console.WriteLine();
            Console.Write(" Press any Key to Continue:");
            Console.ReadKey();
            Console.Clear();
        }
        public static int Usermenu()
        {
            Console.WriteLine();
            Console.WriteLine(" 1.View all Products");
            Console.WriteLine(" 2. Buy the products");
            Console.WriteLine(" 3. Generate Invoice");
            Console.WriteLine(" 4. Exit");
            Console.Write(" ENter your choice:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void viewallproductheaderU()
        {
            Console.WriteLine();
            Console.WriteLine("          All Products");
            Console.WriteLine();
            Console.WriteLine("Name \tCategory\tPrice");
        }
        public static void displayoption1User(Product p)
        {
            Console.WriteLine(p.productnmae + "\t" + p.category + "\t" + p.price );
        }
        public static void elseforUm1()
        {
            Console.WriteLine();
            Console.WriteLine(" No Product Available. Try again later!!!!");
        }
        public static customer buyproducts()
        {
            string pname;
            Console.WriteLine();
            Console.Write(" Enter product name you want to buy:");
            pname = Console.ReadLine();
            int quantity;
            Console.Write(" Enter quantity:");
            quantity = int.Parse(Console.ReadLine());
            customer obj = new customer(pname, quantity);
            return obj;
        }
        public static void elseforquan()
        {
            Console.WriteLine();
            Console.WriteLine(" Not Enough stock available. Try again later !!!!");
        }
        public static void elseforavail()
        {
            Console.WriteLine();
            Console.WriteLine(" Product not fouud. Plz enter valid product name");
        }
        public static void generateinvoice(float tax)
        {
            Console.WriteLine();
            Console.WriteLine(" Total bill after sale tax to be applied is: " + tax);
        }
   
    }
   

}
