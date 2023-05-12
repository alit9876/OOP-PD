using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengee02_w5.BL
{
    class MUser
    {
        public string name;
        public string password;
        public string role;
        public float totalprice;
        public List<customer> Orderdata;
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            if(role == "Customer")
            {
                Orderdata = new List<customer>();
                
            }
        }
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
    class Product
    {
        public string productnmae;
        public string category;
        public float price;
        public int Astockquantity;
        public int thresholdstock;
        public float tax;
        public Product(string name, string category, float price, int quantity, int threshold)
        {
            this.productnmae = name;
            this.category = category;
            this.price = price;
            this.Astockquantity = quantity;
            this.thresholdstock = threshold;
        }
    }
    class customer
    {
        public string productname;
        public int quantity;
        
        public customer(string name, int quantity)
        {
            this.productname = name;
            this.quantity = quantity;
        }
        public customer()
        {

        }
    }


}
