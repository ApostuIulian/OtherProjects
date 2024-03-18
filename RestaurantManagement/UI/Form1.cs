using System;
using System.Windows.Forms;


namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BL.ExecuteQueries log = new BL.ExecuteQueries();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            switch (log.logIn(username, password))
            {
                case -1:
                    MessageBox.Show("Invalid username or password. Please try again.");
                    break;
                case 0:
                    UI.AdminMenu adminMenu = new UI.AdminMenu();
                    adminMenu.Show();
                    this.Hide();
                    break;
                case 1:
                    UI.EmployeeMenu employeeMenu = new UI.EmployeeMenu();
                    employeeMenu.Show();
                    this.Hide();
                    break;
            }
        }

        private void LogIn_Click(object sender, EventArgs e)
        {

        }
    }
}
