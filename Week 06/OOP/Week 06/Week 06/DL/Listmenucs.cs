using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06.BL;
using Week_06.UI;

namespace Week_06.DL
{
    class Listmenucs
    {
        public static void addmenuintomenulist(Coffeeshop shop, MenuItem obj)
        {
            shop.menulist.Add(obj);
        }
        public static MenuItem productwithcheapestprice(Coffeeshop shop)
        {
            float price = shop.menulist[0].price;
            int index = 0;
            for(int x=0; x< shop.menulist.Count;x++)
            {
                if(price >  shop.menulist[x].price)
                {
                    price = shop.menulist[x].price;
                    index = x;
                }
            }
            return shop.menulist[index];
        }
        public static bool verifyproductavailability(Coffeeshop shop,MenuItem obj)
        {
            bool check = false;
            for(int x=0; x< shop.menulist.Count;x++)
            {
                if(shop.menulist[x].name == obj.name)
                {
                    check = true;
                    return check;
                }
            }
            return check;
        }
        public static void addproductintoorderedlist(Coffeeshop shop, MenuItem obj)
        {
            shop.order.Add(obj.name);
        }
        public static bool  orderfullyavailablility(Coffeeshop shop)
        {
            bool check = false;
            if(shop.order.Count >= 0)
            {
                check = true;
            }
            return check;
        }
        public static void fullfilledordered(Coffeeshop shop)
        {
            for(int x=0; x< shop.order.Count;x++)
            {
                ShopCRUD.viewfullfilledorderd(shop.order[x]);
            }
        }
        public static void viewallorderedlist(Coffeeshop shop)
        {
            for(int x=0;x<shop.order.Count;x++)
            {
                ShopCRUD.showorderedlist(shop.order[x]);
            }
        }
        public static void emptylist(Coffeeshop shop)
        {
            for(int x=0;x<shop.order.Count;x++)
            {
                shop.order.RemoveAt(x);
            }
        }
        public static float calculatetotal(Coffeeshop shop)
        {
            float tprice = 0;
            for(int x=0;x<shop.menulist.Count;x++)
            {
                for(int y=0;y<shop.order.Count;y++)
                {
                    
                    if(shop.order[y] == shop.menulist[x].name)
                    {
                        tprice = tprice + shop.menulist[x].price;
                    }
                }
            }
            return tprice;
        }
    }
}
