using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week_10.BL;
using week_10.DL;

namespace week_10
{
    public partial class EditUserform : Form
    {
        private MUser previous;
        public EditUserform(MUser previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EditUserform_Load(object sender, EventArgs e)
        {
            textBox1.Text = previous.UserName;
            textBox2.Text = previous.UserPassword;
            textBox3.Text = previous.UserRole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser updated = new MUser(textBox1.Text, textBox2.Text, textBox3.Text);
            MUserDL.Edituserfromlist(previous, updated);
            this.Close();
             
        }
    }
}
