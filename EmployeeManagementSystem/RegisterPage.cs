using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EmployeeManagementSystem
{
    public partial class RegisterPage : Form
    {
        OleDbConnection connect;
        OleDbDataAdapter adp;
        DataSet dt;
        OleDbCommand cmd;


        public RegisterPage()
        {
            InitializeComponent();

            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //to move from current page to insert page
            this.Hide();
            Insert ins = new Insert();
            ins.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to go back to login page
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            //To search for a selected Employee 
            string a = "SELECT * FROM project WHERE FirstName='" + SearchBox.Text + "' ";
            adp = new OleDbDataAdapter(a, connect);
            connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";
            dt = new DataSet();
            adp.Fill(dt);
            connect.Open();
            dataGridView1.DataSource = dt.Tables[0].DefaultView;
            connect.Close();
        }

        public void delete()
        {
            //to delete the selected row
            connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";

            connect.Open();
            cmd = new OleDbCommand("DELETE FROM project WHERE EmployeeID= " + dataGridView1.CurrentRow.Cells[0].Value + " ", connect);
            cmd.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Data deleted successfully");           //to display message
            display();

        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            delete();
            //dataGridView1.ContextMenuStrip = contextMenuStrip1;       //make change in properties of datgrid->contextmenustrip->contextmenustrip1
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {





            this.Hide();
            Update upd = new Update();

            //long method
            upd.id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value); ;
            upd.nam = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value); ;
            upd.las = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            upd.ag = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            upd.gndr = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            upd.depa = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            upd.desi = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            upd.nmbr = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
            upd.adrs = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
            upd.emal = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
            upd.cty = Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value);
            upd.dta = Convert.ToString(dataGridView1.CurrentRow.Cells[11].Value);

            upd.ShowDialog();


        }



        public void display()
        {
            //to copy the contents into data grid view from ms-access
            connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";
            string query = "Select * from project";
            adp = new OleDbDataAdapter();
            adp = new OleDbDataAdapter(query, connect);
            dt = new DataSet();
            connect.Open();
            adp.Fill(dt, "project");
            dataGridView1.DataSource = dt.Tables[0].DefaultView;
            connect.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
