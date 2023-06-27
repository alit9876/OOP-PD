using SIgninapplication.BL;
using SIgninapplication.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIgninapplication
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void Cleardatafromform()
        {
            uname.Text = "";
            upassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = uname.Text;
            string userpassword = upassword.Text;
            MUser data = new MUser(username, userpassword);
            MUser validuser = MUserDl.signin(data);
            if(validuser != null)
            {
                MessageBox.Show("User is valid");
            }
            else
            {
                MessageBox.Show("User is not found");
            }
            Cleardatafromform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
