using SIgninapplication.BL;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIgninapplication.DL
{
    class MUserDl
    {
        private static List<MUser> stdlist = new List<MUser>();
        public static void adduserintolist(MUser obj)
        {
            stdlist.Add(obj);
        }
        public static MUser signin(MUser user)
        {
            foreach (MUser storeduser in stdlist)
            {
                if (storeduser.getname() == user.getname() && storeduser.getpassword() == user.getpassword())
                {
                    return storeduser;
                }

            }
            return null;
        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static bool readdatafromfile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    adduserintolist(user);
                }
                filevariable.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeduserintofile(MUser user, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.Write(user.getname() + "," + user.getpassword() + "," + user.getrole());
            file.Flush();
            file.Close();
        }
    }
}
