using System;
using System.Collections.Generic;
using System.Linq;
using others.BL;
using System.Text;
using System.Threading.Tasks;

namespace others
{
    class Program
    {
        static void Main(string[] args)
        {
            t2();
            //t3();
        }
        public static void t2()
        {

            List<Customer> customers = new List<Customer>();
            List<Product> product = new List<Product>();
            int option;
            Customer customer = new Customer();
            Product products = new Product();

            do
            {
                option = menu1();
                if (option == 1)
                {
                    Console.ReadLine();
                    Console.Clear();
                    customer = takeInPutForInformation();
                    storeInformationInList(customers, customer);
                    Console.ReadKey();

                }
                else if (option == 2)
                {
                    Console.Clear();
                    products = addProducts();
                    customer.storeInList(products);
                    Console.ReadKey();

                }
                else if (option == 3)
                {
                    Console.Clear();
                    viewCustomerInformation(customers);
                    Console.ReadKey();

                }
                else if (option == 4)
                {
                    Console.Clear();
                    product = customer.getAllProduct();
                    viewAllProduct(product);
                    Console.ReadKey();

                }
                else if (option == 5)
                {
                    Console.Clear();
                    float tax = products.calculateText(customer);
                    viewTax(tax);
                    Console.ReadKey();

                }

            }
            while (option != 6);
            Console.ReadKey();
        }
        public static int menu1()
        {
            Console.Clear();
            Console.WriteLine("1.enter information of customer:");
            Console.WriteLine("2.enter products:");
            Console.WriteLine("3.view customer information:");
            Console.WriteLine("4.view total purchased:");
            Console.WriteLine("5.calculate tex:");
            Console.WriteLine("6.exit:");

            int option = int.Parse(Console.ReadLine());
            return option;

        }
        public static Customer takeInPutForInformation()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter your name: ");
            customer.custmerName = Console.ReadLine();
            Console.WriteLine("enter your contact number: ");
            customer.custmerContact = Console.ReadLine();
            Console.WriteLine("enter your adress: ");
            customer.custmerAdress = Console.ReadLine();
            return customer;

        }
        public static void storeInformationInList(List<Customer> cus, Customer custmer)
        {
            cus.Add(custmer);
        }
        public static Product addProducts()
        {
            Product products = new Product();
            Console.WriteLine("enter product name:");
            products.name = Console.ReadLine();
            Console.WriteLine("enter product category:");
            products.category = Console.ReadLine();
            Console.WriteLine("enter product price:");

            products.price = float.Parse(Console.ReadLine());
            return products;

        }
        public static void viewCustomerInformation(List<Customer> custmers)
        {
            Console.WriteLine("name\t\tcontact\t\t\tadress:");
            foreach (Customer storedCust in custmers)
            {
                Console.WriteLine(storedCust.custmerName + "\t\t" + storedCust.custmerContact + "\t\t" + storedCust.custmerAdress);
            }
        }
        public static void viewAllProduct(List<Product> pro)
        {
            Console.WriteLine("name\t\tCetagory\t\t\tprice:");
            foreach (Product storedPro in pro)
            {
                Console.WriteLine(storedPro.name + "\t\t" + storedPro.category + "\t\t" + storedPro.price);
            }
        }
        public static void viewTax(float tax)
        {
            Console.WriteLine("total tex is:" + tax);
        }

        //              Task 3

        public static void t3()
        {
            List<string> bookChapter = new List<string>();
            Books book = null;
            int option;
            do
            {
                option = menu3();
                if (option == 1)
                {
                    Console.WriteLine("Enter the Book Chapters Name:");
                    for (int x = 0; x < 3; x++)
                    {
                        string name = Console.ReadLine();
                        bookChapter.Add(name);
                    }
                    book = takeInput(bookChapter);
                }
                else if (option == 2)
                {
                    if (book != null)
                    {
                        setBookmark(book);
                    }
                    else
                    {
                        Console.WriteLine("Enter the Book Information 1st:");
                    }
                }
                else if (option == 3)
                {
                    if (book != null)
                    {
                        getbookMark(book); ;
                    }
                    else
                    {
                        Console.WriteLine("Enter the Book Information 1st:");
                    }
                }
                else if (option == 4)
                {
                    if (book != null)
                    {
                        getbookPrice(book);
                    }
                    else
                    {
                        Console.WriteLine("Enter the Book Information 1st:");
                    }
                }
                else if (option == 5)
                {
                    if (book != null)
                    {
                        setbookprice(book);
                    }
                    else
                    {
                        Console.WriteLine("Enter the Book Information 1st:");
                    }
                }
                else if (option == 6)
                {
                    if (book != null)
                    {
                        getbookChapter(book);
                    }
                    else
                    {
                        Console.WriteLine("Enter the Book Information 1st:");
                    }
                }

            }
            while (option != 7);
        }
        public static int menu3()
        {
            Console.WriteLine("1.enter information for for book");
            Console.WriteLine("2.set bookMark:");
            Console.WriteLine("3.get bookMark:");
            Console.WriteLine("4.get book price:");
            Console.WriteLine("5.setbook price:");
            Console.WriteLine("6.get book chapter:");
            Console.WriteLine("7.exist:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static Books takeInput(List<string> chapname)
        {

            Console.WriteLine("enter the auther name:");
            string name = Console.ReadLine();
            Console.WriteLine("enter the book pages");
            int page = int.Parse(Console.ReadLine());

            Console.WriteLine("enter book price:");
            int price = int.Parse(Console.ReadLine());
            Books objB = new Books(name, page, chapname, price);
            return objB;

        }
        public static void setBookmark(Books a)
        {
            Console.WriteLine("Enter the Mark:");
            int mark = int.Parse(Console.ReadLine());
            a.setBookMark(mark);
        }
        public static void getbookMark(Books a)
        {
            int mark = a.getBookMark();
            if (mark == -1)
            {
                Console.WriteLine("No Book Marks Set:");
            }
            else
                Console.WriteLine("Book Mark is " + mark);
        }
        public static void setbookprice(Books a)
        {
            Console.WriteLine("Enter The New Price of Book:");
            int mark = int.Parse(Console.ReadLine());
            a.setBookPrice(mark);
        }
        public static void getbookPrice(Books a)
        {
            int mark = a.getPrice();
            Console.WriteLine("Book Price is " + mark);
        }
        public static void getbookChapter(Books a)
        {
            Console.WriteLine("Enter Chapter Number:");
            int no = int.Parse(Console.ReadLine());
            string chapter = a.getChapter(no);
            Console.WriteLine("Book Chapter Is :" + chapter);
        }
    }
}
