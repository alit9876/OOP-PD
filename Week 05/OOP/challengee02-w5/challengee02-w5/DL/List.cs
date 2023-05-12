using challengee02_w5.BL;
using challengee02_w5.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengee02_w5.DL
{
    class List
    {
        static List<MUser> data = new List<MUser>();
        static List<Product> products = new List<Product>();
        public static void adddatainList(MUser s)
        {
            data.Add(s);
        }
        public static string isvalid(MUser s, ref int currentindex)
        {
            string role = "UNdefind";
            for(int x=0; x< data.Count;x++)
            {
                if(s.name == data[x].name && s.password == data[x].password)
                {
                    role = data[x].role;
                    currentindex = x;
                }
            }
            return role;
        }
        public static void addproductinlist(Product p)
        {
            products.Add(p);
        }
        public static void displayproduct()
        {
            Console.WriteLine();
            for(int x=0; x< products.Count;x++)
            {
                MUserCRUD.displayallproduct(products[x]);
            }
        }
        public static Product productwithhighestp()
        {
            float highest = 0;
            float current = 0;
            int index = 0;
            for(int x=0;x<products.Count;x++)
            {
                current = products[x].price;
                if(highest < current)
                {
                    highest = current;
                    index = x;
                }
            }
            return products[index];
        }
        public static void calculatetax()
        {
            float tax = 0;
            for(int x=0; x<products.Count;x++)
            {
                if(products[x].category == "Grocery")
                {
                    tax =  ((products[x].price * 10) / 100);
                    products[x].tax = tax;
                }
                else if (products[x].category == "Fruit")
                {
                    tax =  ((products[x].price * 5) / 100);
                    products[x].tax = tax;
                }
                else
                {
                    tax =  ((products[x].price * 15) / 100);
                    products[x].tax = tax;
                }
            }
        }
        public static void displaysaletax()
        {
            for(int x=0;x<products.Count;x++)
            {
                MUserCRUD.displaytax(products[x]);
            }
        }
        public static int producttobeordered()
        {
            int count = 0;
            for(int x=0;x<products.Count;x++)
            {
                if(products[x].thresholdstock > products[x].Astockquantity )
                {
                    MUserCRUD.displayproducttobeordered(products[x]);
                    count++;
                }
            }
            return count;
        }
        public static int displayproductUser()
        {
            int count = 0;
            for(int x=0;x< products.Count;x++)
            {
                MUserCRUD.displayoption1User(products[x]);
                count++;
            }
            return count;
        }
        public static void addbuyproductintolist(customer p, int currentindex)
        {
            data[currentindex].Orderdata.Add(p);
        }
        public static void decreasedquantity(customer p)
        {
            for(int x=0;x<products.Count;x++)
            {
                if(products[x].productnmae == p.productname )
                {
                    products[x].Astockquantity = products[x].Astockquantity - p.quantity;
                }
            }
        }
        public static bool validtionondata(customer p)
        {
            bool check = false;
            for(int x=0;x<products.Count;x++)
            {
                if (p.productname == products[x].productnmae)
                {
                    check = true;
                }
            }
            return check;
        }
        public static bool validationonquantity(customer p)
        {
            bool check = false;
            for (int x = 0; x < products.Count; x++)
            {
                if (p.productname == products[x].productnmae)
                {
                    if(p.quantity < products[x].Astockquantity)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
        public static float generateinvoicebill(int currentindex)
        {
            float total = 0;
            int count = data[currentindex].Orderdata.Count;
            for(int x=0; x< products.Count;x++)
            {
                for (int y = 0; y < count; y++)
                {
                    if(products[x].productnmae == data[currentindex].Orderdata[y].productname)
                    {
                        total = total + products[x].price * data[currentindex].Orderdata[y].quantity;
                        total = total - (products[x].tax * data[currentindex].Orderdata[y].quantity);
                    }
                }
            }
            data[currentindex].totalprice = total;
            return total;
        }

    }
}
