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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path = "data.txt";
            if (MUserDl.readdatafromfile(path))
            {
                MessageBox.Show("Data loaded from file");
            }
            else
            {
                MessageBox.Show("Data not loaded");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Form moreForm = new SignUp();
                moreForm.Show();
                checkBox3.Checked = false;
            }
            else if (Signin.Checked)
            {
                Form moreForm = new SignIn();
                moreForm.Show();
                Signin.Checked = false;
            }
        }

        private void Signin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
