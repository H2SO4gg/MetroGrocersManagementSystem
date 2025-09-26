using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStart
{
    public partial class FormAdmin : Form
    {
        private string currentUsername;
        private FormLogin loginForm;
        private bool isGoingBack = false;
        public FormAdmin()
        {
            InitializeComponent();
        }
        public FormAdmin(string username, FormLogin loginForm)
        {
            InitializeComponent();
            this.currentUsername = username;
            this.loginForm = loginForm;
        }

        private void lblShowInfo_Click(object sender, EventArgs e)
        {

        }

        private void LoadControl(UserControl control)
        {
            pnlShowOnClick.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlShowOnClick.Controls.Add(control);
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

            try
            {
                DataAccess da = new DataAccess();

                var userDetails = da.GetUserDetails(this.currentUsername);

                if (userDetails != null)
                {
                    string fullName = userDetails.Item1;
                    string Id = userDetails.Item2;

                    lblWelcome.Text = $"Welcome,\n{fullName} ({Id})";
                }
                else
                {
                    lblWelcome.Text = "Welcome, User!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user data: " + ex.Message);
                lblWelcome.Text = "Error loading data.";
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Create an instance of your Users user control and load it
            LoadControl(new ucUsers());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // Create an instance of your Users user control and load it
            LoadControl(new ucProducts());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.isGoingBack = true; 
            this.loginForm.Show();
            this.Close();
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isGoingBack == false)
            {
                this.loginForm.Close();
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            this.LoadControl(new ucCart());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.LoadControl(new ucSales());
        }
    }
}
