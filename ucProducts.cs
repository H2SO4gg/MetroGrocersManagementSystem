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
    public partial class ucProducts : UserControl
    {
        private DataAccess Da { get; set; }
        public ucProducts()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();

            this.AutoGenerateProductId();
        }

        private void PopulateGridView(string sql = "select * from Products;")
        {
            var ds = this.Da.ExecuteQuery(sql, "Products");

            this.dgvProducts.AutoGenerateColumns = false;

            this.dgvProducts.DataSource = ds.Tables["Products"];
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvProducts.CurrentRow.Cells["ID"].Value.ToString();
            this.txtProductName.Text = this.dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtPrice.Text = this.dgvProducts.CurrentRow.Cells["Price"].Value.ToString();
            this.txtQuantity.Text = this.dgvProducts.CurrentRow.Cells["Quantity"].Value.ToString();
            bool isActive = Convert.ToBoolean(this.dgvProducts.CurrentRow.Cells["Active"].Value);
            this.cbActive.SelectedItem = isActive ? "Active" : "Inactive";
        }

        // In ucProducts.cs
        private void AutoGenerateProductId()
        {
            try
            {
                string query = "SELECT MAX(CAST(SUBSTRING(ID, 6, LEN(ID)) AS INT)) FROM Products;";
                var dt = this.Da.ExecuteQueryTable(query);

                int nextIdNumber = 1;

                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    int maxIdNumber = Convert.ToInt32(dt.Rows[0][0]);
                    nextIdNumber = maxIdNumber + 1;
                }

                string newId = $"PROD-{nextIdNumber:D3}"; 
                this.txtId.Text = newId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating a new Product ID: " + ex.Message);
            }
        }



        private void ClearAll()
        {
            this.txtProductName.Clear();
            this.txtPrice.Clear();
            this.txtQuantity.Clear();
            this.cbActive.SelectedIndex = -1;
            this.dgvProducts.ClearSelection();

            this.AutoGenerateProductId();
        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtProductName.Text) ||
                String.IsNullOrEmpty(this.txtPrice.Text) || String.IsNullOrEmpty(this.txtQuantity.Text) ||
                this.cbActive.SelectedItem == null)
            {
                return false;
            }
            return true;
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

                var query = "SELECT * FROM Products WHERE ID = '" + this.txtId.Text + "';";
                var dt = this.Da.ExecuteQueryTable(query);

                int activeStatus = this.cbActive.SelectedItem.ToString() == "Active" ? 1 : 0;

                if (dt.Rows.Count == 1)
                {
                    var sql = @"UPDATE Products SET
                        ProductName = '" + this.txtProductName.Text + @"',
                        Price = " + this.txtPrice.Text + @",
                        Quantity = " + this.txtQuantity.Text + @",
                        Active = " + activeStatus + @"
                        WHERE ID = '" + this.txtId.Text + "';";

                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                        MessageBox.Show("Product data has been updated successfully.");
                    else
                        MessageBox.Show("Product data update failed.");
                }
                else
                {
                    var sql = @"INSERT INTO Products (ID, ProductName, Price, Quantity, Active) VALUES
                        ('" + this.txtId.Text + "', '" + this.txtProductName.Text + "', " +
                                this.txtPrice.Text + ", " + this.txtQuantity.Text + ", " + activeStatus + ");";

                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                        MessageBox.Show("New product has been added successfully.");
                    else
                        MessageBox.Show("Failed to add new product.");
                }

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProducts.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a product to delete.");
                    return;
                }

                var id = this.dgvProducts.CurrentRow.Cells["ID"].Value.ToString();
                var name = this.dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();

                var result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                var sql = "DELETE FROM Products WHERE ID = '" + id + "';";
                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(name + " has been deleted successfully.");
                else
                    MessageBox.Show("Product deletion failed.");

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

            if (rbName.Checked)
            {
                sql = "SELECT * FROM Products WHERE ProductName LIKE '%" + searchTerm + "%';";
            }
            else if (rbID.Checked)
            {
                sql = "SELECT * FROM Products WHERE ID LIKE '%" + searchTerm + "%';";
            }
            else if (rbPrice.Checked)
            {
                sql = "SELECT * FROM Products WHERE ID LIKE '%" + searchTerm + "%';";
            }
            else
            {
                MessageBox.Show("Please select a search category (by Name or by ID).");
                return;
            }

            this.PopulateGridView(sql);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.txtSearch.Clear();
            this.PopulateGridView();
        }

        
    }
}
