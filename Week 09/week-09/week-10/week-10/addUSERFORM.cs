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
    public partial class addUSERFORM : Form
    {
        public addUSERFORM()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void addUSERFORM_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser user = new MUser(textBox1.Text, textBox2.Text, textBox3.Text);
            MUserDL.adddataintolist(user);
            this.Close();
        }
    }
}
