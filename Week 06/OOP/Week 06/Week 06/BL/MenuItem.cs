using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06.BL
{
    class MenuItem
    {
        public string name;
        public string type;
        public float price;
        public MenuItem(string name, string type, float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public MenuItem(string name)
        {
            this.name = name;
        }
    }
    class Coffeeshop
    {
        public string name;
        public List<MenuItem> menulist = new List<MenuItem>();
        public List<string> order = new List<string>();
        public Coffeeshop(string name)
        {
            this.name = name;
        }
        public Coffeeshop()
        {

        }
        
    }

}
