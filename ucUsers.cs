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
    public partial class ucUsers : UserControl
    {
        private DataAccess Da { get; set; }
        private bool isDataLoading = false;

        public ucUsers()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = "select * from UserInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql, "UserInfo");
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.DataSource = ds.Tables["UserInfo"];
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.isDataLoading = true;
                var currentRow = this.dgvUsers.CurrentRow;
                if (currentRow == null) return;

                this.txtId.Text = currentRow.Cells["ID"].Value.ToString();
                this.txtUsername.Text = currentRow.Cells["Username"].Value.ToString();
                this.txtFullName.Text = currentRow.Cells["FullName"].Value.ToString();
                this.txtPassword.Text = currentRow.Cells["Password"].Value.ToString();
                this.cbRole.SelectedItem = currentRow.Cells["UserRole"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading user data: " + ex.Message);
            }
            finally
            {
                this.isDataLoading = false;
            }
        }

        private void ClearAll()
        {
            this.txtId.Clear();
            this.txtUsername.Clear();
            this.txtFullName.Clear();
            this.txtPassword.Clear();
            this.cbRole.SelectedIndex = -1;
            this.dgvUsers.ClearSelection();
        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtUsername.Text) ||
                String.IsNullOrEmpty(this.txtFullName.Text) || String.IsNullOrEmpty(this.txtPassword.Text) ||
                this.cbRole.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsers.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a user to delete.");
                    return;
                }

                var id = this.dgvUsers.CurrentRow.Cells["ID"].Value.ToString();
                var name = this.dgvUsers.CurrentRow.Cells["FullName"].Value.ToString();
                var result = MessageBox.Show("Are you sure you want to delete the user " + name + "?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                var sql = "DELETE FROM UserInfo WHERE ID = '" + id + "';";
                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(name + " has been deleted successfully.");
                else
                    MessageBox.Show("User deletion failed.");

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all required fields.");
                    return;
                }

                var query = "SELECT * FROM UserInfo WHERE ID = '" + this.txtId.Text + "';";
                var dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {
                    var sql = @"UPDATE UserInfo SET
                                    Username = '" + this.txtUsername.Text + @"',
                                    FullName = '" + this.txtFullName.Text + @"',
                                    Password = '" + this.txtPassword.Text + @"',
                                    UserRole = '" + this.cbRole.SelectedItem.ToString() + @"'
                                WHERE ID = '" + this.txtId.Text + "';";

                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                        MessageBox.Show("User data has been updated successfully.");
                    else
                        MessageBox.Show("User data update failed.");
                }
                else
                {
                    var sql = @"INSERT INTO UserInfo (ID, Username, FullName, Password, UserRole) VALUES
                                ('" + this.txtId.Text + "', '" + this.txtUsername.Text + "', '" +
                                 this.txtFullName.Text + "', '" + this.txtPassword.Text + "', '" +
                                 this.cbRole.SelectedItem.ToString() + "');";

                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                        MessageBox.Show("New user has been added successfully.");
                    else
                        MessageBox.Show("Failed to add new user.");
                }

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = this.txtSearch.Text;
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a term to search.");
                return;
            }

            string sql;

            if (rbUsername.Checked)
            {
                sql = "SELECT * FROM UserInfo WHERE Username LIKE '%" + searchTerm + "%';";
            }
            else if (rbName.Checked)
            {
                sql = "SELECT * FROM UserInfo WHERE FullName LIKE '%" + searchTerm + "%';";
            }
            else if (rbRole.Checked)
            {
                sql = "SELECT * FROM UserInfo WHERE UserRole LIKE '%" + searchTerm + "%';";
            }
            else
            {
                MessageBox.Show("Please select a search category (e.g., by Username).");
                return;
            }

            this.PopulateGridView(sql);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.txtSearch.Clear();
            this.PopulateGridView();
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isDataLoading)
            {
                this.GenerateNewId();
            }
        }

        private void GenerateNewId()
        {
            if (cbRole.SelectedItem == null)
            {
                txtId.Clear();
                return;
            }

            string selectedRole = cbRole.SelectedItem.ToString();
            string prefix = selectedRole.Equals("Admin") ? "A" : "M";

            string query = $"SELECT MAX(CAST(SUBSTRING(ID, 3, LEN(ID)) AS INT)) FROM UserInfo WHERE UserRole = '{selectedRole}';";

            var dt = this.Da.ExecuteQueryTable(query);
            int nextIdNumber = 1;

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                int maxIdNumber = Convert.ToInt32(dt.Rows[0][0]);
                nextIdNumber = maxIdNumber + 1;
            }

            string newId = $"{prefix}-{nextIdNumber:D3}";
            this.txtId.Text = newId;
        }

        private void rbRole_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
