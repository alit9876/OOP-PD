using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22final.BL;
using BMS_22final.DL;
using BMS_22final.UI;


namespace BMS_22final
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentindex = 0;
            int bankbalance = 12000;
            List1.loaddataforadmin();
            List1.loaddata();
            Console.Clear();
            string option1 = "0";
            bool running = true;
            while (running)
            {
                menuCRUD.header();
                menuCRUD.submenu("login");
                option1 = menuCRUD.loginmenu();
                int listcount = List1.listcount();

                if (option1 == "1")
                {
                    string option;
                    Console.Clear();
                    menuCRUD.header();
                    menuCRUD.submenu("Sign In");
                    user signin = userCRUD.takeinputforsignin();
                    if (listcount != 0)
                    {
                        signin = List1.signIn(signin, ref currentindex);
                        if (signin == null)
                        {
                            userCRUD.notfound();
                        }
                        else if (signin != null)
                        {
                            string value = List1.signinf(currentindex);
                            if (value == "UnFreeze")
                            {
                                string role = List1.returnrole(currentindex);
                                if (role == "admin")
                                {
                                    string n = "1";
                                    while (n != "0")
                                    {
                                        Console.Clear();
                                        menuCRUD.header();
                                        menuCRUD.submenu("Admin");
                                        option = menuCRUD.admin();
                                        Console.WriteLine("Admin");
                                        Console.ReadKey();
                                   //     n = List1.adminfunctionality(option, ref currentindex, ref bankbalance);
                                     //   if (n != "0")
                                    //    {
                                    //        dataCRUD.presscontinue();
                                     //   }
                                    }
                                }
                                if (role == "User")
                                {
                                    string n = "1";
                                    while (n != "0")
                                    {
                                        Console.Clear();
                                        menuCRUD.header();
                                        menuCRUD.submenu("User");
                                        option = menuCRUD.user();
                                        Console.WriteLine("User");
                                        Console.ReadKey();
                                        // n = List1.userfunctionality(option, ref currentindex, ref bankbalance);
                                        // if (n != "0")
                                        // {
                                        //    dataCRUD.presscontinue();
                                        // }
                                    }
                                }
                            }
                            else
                            {
                                userCRUD.freezeacount();
                            }
                        }

                    }
                    else if (listcount == 0)
                    {
                        userCRUD.noaccountfound();
                    }

                }

                else if (option1 == "2")
                {
                    Console.Clear();
                    menuCRUD.header();
                    menuCRUD.submenu("Sign Up");
                    user obj;
                    if(listcount ==0)
                    {
                         obj = userCRUD.takeinputforsigupadmin();
                    }
                    else
                    {
                        obj = userCRUD.takeinputforsignup();
                    }
                    string Isvalid;
                    bool isName;
                    isName = List1.namecheck(obj.gettername());
                    if (isName)
                    {
                        bool passwordvalidity = List1.passwordvalid(obj.getterpassword());
                        if (passwordvalidity)
                        {
                            Isvalid = List1.signup(obj);
                            if (Isvalid == "false")
                            {
                                List1.adddataintolist(List1.setacrole(obj));
                                menuCRUD.loading();
                            }

                            if (Isvalid == "true")
                            {
                                userCRUD.alreadyexit();
                            }
                        }
                        else
                        {
                            userCRUD.passwordshot();
                        }
                    }
                    else
                    {
                        userCRUD.nameingerror();
                    }

                    menuCRUD.clear();
                }

                else if (option1 == "3")
                {
                    List1.savedata();
                    List1.savadataforadmin();
                    running = false;
                }

                else
                {
                    userCRUD.invalid();
                }

                Console.Clear();
            }
        }
    }
}
