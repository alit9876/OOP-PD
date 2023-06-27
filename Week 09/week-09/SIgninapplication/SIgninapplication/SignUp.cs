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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void ClearDataFromForm()
        {
            name.Text = "";
            password.Text = "";
            role.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = name.Text;
            string upassword = password.Text;
            string urole = this.role.Text;
            string path = "data.txt";
            MUser data = new MUser(username, upassword, urole);
            MUserDl.adduserintolist(data);
            MUserDl.storeduserintofile(data, path);
            MessageBox.Show("User Added Successfully");
            ClearDataFromForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
