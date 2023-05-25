namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (uname.Text == "Admin" && password.Text == "Admin@123")
            {
                this.Hide();
                RegisterPage rgs = new RegisterPage();
                rgs.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please enter a valid userame and password");
                uname.ResetText();
                password.ResetText();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}