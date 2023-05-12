using challengee02_w5.BL;
using challengee02_w5.DL;
using challengee02_w5.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengee02_w5
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;   
            do
            {
                 option = MUserCRUD.menu();
                if (option == 1)
                {
                    Console.Clear();
                    int currentindex = 0;
                    MUser data = MUserCRUD.signin();
                    string role = List.isvalid(data, ref currentindex);
                    Console.Clear();
                    if(role == "admin")
                    {
                        int option1 =0;
                        while(option1 != 6)
                        {
                            option1 = MUserCRUD.adminmenu();
                            Console.Clear();
                            if(option1 ==1)
                            {
                                List.addproductinlist(MUserCRUD.takeInputProduct());
                            }
                            if(option1 == 2)
                            {
                                MUserCRUD.headerforadminoption2();
                                List.displayproduct();
                            }
                            if (option1 == 3)
                            {
                                Product highest = List.productwithhighestp();
                                MUserCRUD.displayhighestP(highest);
                            }
                            if(option1 ==4)
                            {
                                List.calculatetax();
                                MUserCRUD.headerforsaletax();
                                List.displaysaletax();
                            }
                            if(option1 ==5)
                            {
                                int count = List.producttobeordered();
                                if(count ==0)
                                {
                                    MUserCRUD.displatelsefororedertobeorder();
                                }
                            }
                            if(option !=6)
                            {
                                MUserCRUD.clear();
                            }
                            if(option ==6)
                            {
                                Console.Clear();
                            }   
                        }
                    }
                    if(role == "Customer")
                    {
                        int option2 = 0;
                        while(option2 !=4)
                        {
                            Console.WriteLine(currentindex);
                            option2 =MUserCRUD.Usermenu();
                            Console.Clear();
                            if (option2 == 1)
                            {
                                MUserCRUD.viewallproductheaderU();
                                int count = List.displayproductUser();
                                if(count ==0)
                                {
                                    MUserCRUD.elseforUm1();
                                }
                            }
                            if(option2 == 2)
                            {
                                customer Orderedproduct = MUserCRUD.buyproducts();
                                bool availa = List.validtionondata(Orderedproduct);
                                if(availa)
                                {
                                    bool quan = List.validationonquantity(Orderedproduct);
                                    if(quan)
                                    {
                                        List.addbuyproductintolist(Orderedproduct, currentindex);
                                        List.decreasedquantity(Orderedproduct);
                                    }
                                    else
                                    {
                                        MUserCRUD.elseforquan();
                                    }
                                }
                                else
                                {
                                    MUserCRUD.elseforavail();
                                }
                            }
                            if (option2 == 3)
                            {
                                MUserCRUD.generateinvoice(List.generateinvoicebill(currentindex));
                            }
                            if (option != 4)
                            {
                                MUserCRUD.clear();
                            }
                            if (option == 4)
                            {
                                Console.Clear();
                            }
                        }
                    }
                    if(role == "UNdefind")
                    {
                        MUserCRUD.notuserfound();
                    }
                    MUserCRUD.clear();

                }
                if (option == 2)
                {
                    Console.Clear();
                    MUser data1 = MUserCRUD.signUp();
                    List.adddatainList(data1);
                }
                if(option !=3)
                {
                    MUserCRUD.clear();
                }
                
            } while (option != 3);
        }
    }
}
