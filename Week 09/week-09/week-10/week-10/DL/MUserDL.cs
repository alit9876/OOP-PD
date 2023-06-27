using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using week_10.BL;

namespace week_10.DL
{
    class MUserDL
    {
        private static List<MUser> userlist = new List<MUser>();
        internal static List<MUser> Userlist { get => userlist; set => userlist = value; }
        public static void adddataintolist(MUser obj)
        {
            Userlist.Add(obj);
        }
        public static MUser SignIn(MUser obj)
        {
            foreach (MUser storedUser in Userlist)
            {
                if(storedUser.UserName == obj.UserName && storedUser.UserPassword == obj.UserPassword)
                {
                    return storedUser;
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
                    adddataintolist(user);
                }
                filevariable.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeduserintofile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            foreach(MUser user in userlist)
            {
                file.Write(user.getusername() + "," + user.getpassword() + "," + user.getuserrole());
            }
            
            file.Flush();
            file.Close();
        }
        public static void deletedatafromlist(MUser obj)
        {
            for(int index =0; index < userlist.Count; index++)
            {
                if(userlist[index].UserName == obj.UserName && userlist[index].UserPassword == obj.UserPassword)
                {
                    userlist.RemoveAt(index);
                }
            }
        }
        public static void Edituserfromlist(MUser prev, MUser updated)
        {
            foreach(MUser obj in userlist)
            {
                if(obj.UserName == prev.UserName && obj.UserPassword == prev.UserPassword)
                {
                    obj.UserName = updated.UserName;
                    obj.UserPassword = updated.UserPassword;
                    obj.UserRole = updated.UserRole;
                }
            }
        }
        public static void storeduserintofile(MUser user,string path)
        {
            StreamWriter file = new StreamWriter(path, true);

                file.Write(user.getusername() + "," + user.getpassword() + "," + user.getuserrole());
            file.Flush();
            file.Close();
        }
    }
    
}
