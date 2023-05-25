using System;

using System.Data;

using System.Data.OleDb;

namespace EmployeeManagementSystem
{
    public partial class Update : Form
    {

        OleDbConnection con;
        OleDbCommand command;
        //OleDbDataReader rdr;

        public string id, nam, las, ag, gndr, depa, desi, nmbr, adrs, emal, cty, dta;

        public Update()
        {
            InitializeComponent();
            //display();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage rgst = new RegisterPage();
            rgst.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            empid.ResetText();

        }

        private void Update_Load(object sender, EventArgs e)
        {
            //long method
            empid.Text = id;
            fname.Text = nam;
            lname.Text = las;
            age.Text = ag;
            if (gndr == "Male")
            {
                malebtn.Checked = true;
            }
            else if (gndr == "Female")
            {
                femalebtn.Checked = true;
            }
            department.Text = depa;
            designation.Text = desi;
            number.Text = nmbr;
            address.Text = adrs;
            email.Text = emal;
            city.Text = cty;
            date.Text = dta;
        }



        public void display()
        {
            //con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";
            //string query = "SELECT * FROM project WHERE EmployeeID=" + Int32.Parse(empid.Text) + " ";
            //command = new OleDbCommand(query, con);
            //command.CommandType = CommandType.Text;
            //command.Connection = con;
            //con.Open();


            //OleDbDataReader rdr = command.ExecuteReader();
            //rdr.Read();

            //fname.Text = rdr["FirstName"].ToString();
            //lname.Text = rdr["LastName"].ToString();
            //age.Text = rdr["Ages"].ToString();
            //lname.Text = rdr["LastName"].ToString();
            //department.Text = rdr["Department"].ToString();
            //designation.Text = rdr["Designation"].ToString();
            //number.Text = rdr["ContactNumber"].ToString();
            //email.Text = rdr["Email"].ToString();
            //address.Text = rdr["Address"].ToString();
            //lname.Text = rdr["LastName"].ToString();
            //date.Text = rdr["Dte"].ToString();

            //con.Close();







        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Rajat\\C#\\project.accdb;Persist Security Info=True";
            string gen = "";
            if (malebtn.Checked)
            {
                gen = "Male";
            }
            else if (femalebtn.Checked)
            {
                gen = "Female";
            }
            int ID = Int32.Parse(empid.Text);
            //string query = "UPDATE project SET FirstName='" + fname.Text + "' WHERE EmployeeID=" + ID + " ";
            string query = "UPDATE project SET FirstName='" + fname.Text + "',LastName='" + lname.Text + "',Ages=" + Int16.Parse(age.Text) + ",Gender='" + gen + "',Department='" + department.Text + "',Designation='" + designation.Text + "',ContactNumber=" + Int64.Parse(number.Text) + ",Address='" + address.Text + "',Email='" + email.Text + "',City='" + this.city.SelectedItem + "',Dte='" + date.Text + "' WHERE EmployeeID=" + ID + " ";
            command = new OleDbCommand(query, con);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Updated Successfully");
            ClearFields();

        }

    }
}
