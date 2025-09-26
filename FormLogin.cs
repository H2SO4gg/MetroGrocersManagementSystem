using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormStart
{
    public partial class FormLogin : Form
    {
        private DataAccess Da { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            Da = new DataAccess();
        }

        //Show Password
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }
        //Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }
        //Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string userRole = Da.LoginOnUserRole(username, password);

            if (userRole != null)
            {
                this.Visible = false; 

                if (userRole == "Admin")
                {
                    FormAdmin adminWindow = new FormAdmin(username, this);
                    adminWindow.Show();
                }
                else if (userRole == "Manager")
                {
                    FormManager managerWindow = new FormManager(username, this);
                    managerWindow.Show();
                }
                else
                {
                    MessageBox.Show($"Login successful, but role '{userRole}' is not recognized.");
                    this.Close(); 
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


