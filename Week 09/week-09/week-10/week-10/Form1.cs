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
    public partial class Form1 : Form
    {
        private string path = "data.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MUserDL.readdatafromfile(path);
            dataGridView1.DataSource = MUserDL.Userlist;
        }
        
        public void dataBind()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MUserDL.Userlist;
            dataGridView1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addUSERFORM myform = new addUSERFORM();
            myform.ShowDialog();
            MUserDL.storeduserintofile(path);
            dataBind();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MUser user = (MUser)dataGridView1.CurrentRow.DataBoundItem;
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                MUserDL.deletedatafromlist(user);
                MUserDL.storeduserintofile(path);
                dataBind();
            }
            else if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                EditUserform myform = new EditUserform(user);
                myform.ShowDialog();
                MUserDL.storeduserintofile(path);
                dataBind();
            }
        }
    }
}
