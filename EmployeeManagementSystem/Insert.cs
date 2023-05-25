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

    public partial class Insert : Form
    {

        public Insert()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage rgs = new RegisterPage();
            rgs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";

            if (checkBox1.Checked)
            {
                string Query = "INSERT INTO project(FirstName,LastName,Ages,Gender,Department,designation,ContactNumber,Address,Email,City,Dte) VALUES(@fname,@lname,@age,@gender,@department,@designation,@number,@address,@email,@city,@date)";

                OleDbCommand cmd = new OleDbCommand(Query, conn);

                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@age", Int16.Parse(age.Text));
                if (malebtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Male");
                }
                else if (femalebtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Female");
                }
                cmd.Parameters.AddWithValue("@department", department.Text);
                cmd.Parameters.AddWithValue("@designation", designation.Text);
                cmd.Parameters.AddWithValue("@number", Int64.Parse(number.Text));
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@city", this.city.SelectedItem);
                cmd.Parameters.AddWithValue("@date", date.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ClearFields();
                MessageBox.Show("Data Added Successfully");

            }
            else
            {
                MessageBox.Show("Verify your details and confirm it by selecting the checkbox");
            }
        }
        public void ClearFields()
        {
            fname.ResetText();
            lname.ResetText();
            age.ResetText();
            malebtn.Checked = false;
            femalebtn.Checked = false;
            department.ResetText();
            designation.ResetText();
            number.ResetText();
            address.ResetText();
            email.ResetText();
            date.ResetText();
            city.SelectedIndex = 0;
            checkBox1.Checked = false;

        }
    }
}
