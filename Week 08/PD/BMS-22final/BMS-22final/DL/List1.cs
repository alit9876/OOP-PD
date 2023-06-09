using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BMS_22final.BL;
using BMS_22final.UI;

namespace BMS_22final.DL
{
    class List1
    {
        static List<user> s = new List<user>();
        public static void adddataintolist(user obj)
        {
            s.Add(obj);
        }
        public static int listcount()
        {
            return s.Count();
        }
        public static bool passwordvalid(string password)
        {
            bool isvalid = false;
            int count = 0;
            for (int x = 0; password.Length > x; x++)
            {
                count++;
            }
            if (count >= 5)
            {
                isvalid = true;
            }
            return isvalid;
        }
        public static bool namecheck(string name)
        {
            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    i++;
                    if (i >= 5)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public static string signup(user obj)
        {
            string Isfound = "false";
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].gettername() == obj.gettername())
                {
                    Isfound = "true";
                }
            }
            return Isfound;
        }
        public static user setacrole(user obj)
        {
            if (s.Count != 0)
            {
                obj.setaccountnumbers(s[s.Count - 1].getteraccountnumbers() + 1);
                obj.setroles("User") ;
            }
            if (s.Count == 0)
            {
                obj.setaccountnumbers(0);
                obj.setroles("admin");
            }
            return obj;
        }
        public static user signIn(user signin, ref int currentindex)
        {
            int count = 0;
            foreach (user storedUser in s)
            {
                if (signin.gettername() == storedUser.gettername() && signin.getterpassword() == storedUser.getterpassword())
                {
                    currentindex = count;
                    return storedUser;
                }
                count++;
            }
            return null;
        }
        public static string signinf(int currentindex)
        {
            string value = s[currentindex].getterstatus();
            return value;
        }
        public static string returnrole(int currentindex)
        {
            string role = s[currentindex].getterrole();
            return role;
        }

        //   file handling
        public static bool loaddataforadmin()
        {
            string path = "recorda.txt";
            if(File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record = filevariable.ReadLine();
                if(record != null)
                {
                    string[] temp = record.Split(',');
                    user obj = new user(temp[0], temp[1]);
                    adddataintolist(obj);
                    
                    return true;
                }
                filevariable.Close();
            }
            
            return false;            
        }
        public static void savadataforadmin()
        {
            string path = "recorda.txt";
            StreamWriter file = new StreamWriter(path, false);
            if(s.Count != 0)
            {
                file.Write(s[0].gettername() + ",");
                file.Write(s[0].getterpassword());
            }
            
            file.Close();
        }
        public static bool loaddata()
        {
            string path = "record.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] temp = record.Split(',');
                    loan l = new loan(int.Parse(temp[5]), temp[6], temp[7]);
                    freeze f = new freeze(temp[11], int.Parse(temp[12]));
                    insurance i = new insurance(int.Parse(temp[8]), int.Parse(temp[9]), temp[10]);
                    datac obj = new datac(temp[0], temp[1], temp[2], int.Parse(temp[3]), int.Parse(temp[4]), temp[13], temp[14], f, i, l);
                    adddataintolist(obj);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        public static void savedata()
        {
            string path = "record.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int index = 1; index < s.Count; index++)
            {
                file.Write(s[index].gettername() + ",");
                file.Write(s[index].getterpassword() + ",");
                file.Write(s[index].gettertypes() + ",");
                file.Write(s[index].getterbalances() + ",");
                file.Write(s[index].getteraccountnumbers() + ",");
                file.Write(s[index].getterloans() + ",");
                file.Write(s[index].getterissueloans() + ",");
                file.Write(s[index].getterlimitloans() + ",");
                file.Write(s[index].getterinsurances() + ",");
                file.Write(s[index].getterdurations() + ",");
                file.Write(s[index].getterinstallments() + ",");
                file.Write(s[index].getterstatus() + ",");
                file.Write(s[index].getterfdurations() + ",");
                file.Write(s[index].gettercomplains() + ",");
                file.WriteLine(s[index].getterrole());
            }
            file.Close();
        }
    }
}
