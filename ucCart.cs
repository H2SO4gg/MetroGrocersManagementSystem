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

namespace FormStart
{
    public partial class ucCart : UserControl
    {
        private DataAccess Da { get; set; }

        public ucCart()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateProductGrid();
        }

        private void PopulateProductGrid()
        {
            string sql = "SELECT ID, ProductName, Price, Quantity FROM Products WHERE Active = 1 AND Quantity > 0;";
            try
            {
                var ds = this.Da.ExecuteQuery(sql, "Products");
                this.dgvProducts.AutoGenerateColumns = false;
                this.dgvProducts.DataSource = ds.Tables["Products"];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error loading product list: " + exc.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to add.");
                return;
            }

            var selectedRow = this.dgvProducts.SelectedRows[0];
            string productId = selectedRow.Cells["ID"].Value.ToString();
            string productName = selectedRow.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int availableStock = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            DataGridViewRow existingCartRow = null;
            foreach (DataGridViewRow row in this.dgvProductCart.Rows)
            {
                if (row.Cells["IDCart"].Value.ToString() == productId)
                {
                    existingCartRow = row;
                    break;
                }
            }

            if (existingCartRow != null)
            {
                int currentQuantityInCart = Convert.ToInt32(existingCartRow.Cells["QuantityCart"].Value);

                if (currentQuantityInCart >= availableStock)
                {
                    MessageBox.Show("No more stock available for " + productName + ".");
                    return;
                }

                existingCartRow.Cells["QuantityCart"].Value = currentQuantityInCart + 1;
                existingCartRow.Cells["LineTotalCart"].Value = (currentQuantityInCart + 1) * price;
            }
            else
            {
                if (availableStock < 1)
                {
                    MessageBox.Show(productName + " is out of stock.");
                    return;
                }
                this.dgvProductCart.Rows.Add(productId, productName, price, 1, price);
            }

            this.CalculateTotals();
        }

        private void dgvProductCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProductCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.dgvProductCart.Columns[e.ColumnIndex].Name != "QuantityCart")
                return;

            var cartRow = this.dgvProductCart.Rows[e.RowIndex];
            string productId = cartRow.Cells["IDCart"].Value.ToString();
            int newQuantity;

            if (!int.TryParse(cartRow.Cells["QuantityCart"].Value.ToString(), out newQuantity) || newQuantity < 1)
            {
                cartRow.Cells["QuantityCart"].Value = 1;
                newQuantity = 1;
            }

            int availableStock = 0;
            foreach (DataGridViewRow prodRow in this.dgvProducts.Rows)
            {
                if (prodRow.Cells["ID"].Value.ToString() == productId)
                {
                    availableStock = Convert.ToInt32(prodRow.Cells["Quantity"].Value);
                    break;
                }
            }

            if (newQuantity > availableStock)
            {
                MessageBox.Show($"Only {availableStock} items are available for this product.");
                cartRow.Cells["QuantityCart"].Value = availableStock; 
                newQuantity = availableStock;
            }

            decimal price = Convert.ToDecimal(cartRow.Cells["PriceCart"].Value);
            cartRow.Cells["LineTotalCart"].Value = newQuantity * price;
            this.CalculateTotals();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvProductCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }
            var selectedRow = this.dgvProductCart.SelectedRows[0];
            this.dgvProductCart.Rows.Remove(selectedRow);
            this.CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in this.dgvProductCart.Rows)
            {
                if (row.Cells["LineTotalCart"].Value != null)
                    subTotal += Convert.ToDecimal(row.Cells["LineTotalCart"].Value);
            }

            decimal taxRate = 0.05m;
            decimal taxAmount = subTotal * taxRate;
            decimal grandTotal = subTotal + taxAmount;

            this.lblSubTotal.Text = "Subtotal  -  "+ subTotal.ToString("F2");
            this.lblTax.Text = "Tax (5%)  -  "+taxAmount.ToString("F2");
            this.lblGrandTotal.Text = "Grand Total  -  "+grandTotal.ToString("F2");
        }

        private void UpdateDisplayedStock(string productId, int quantityChange)
        {
            foreach (DataGridViewRow row in this.dgvProducts.Rows)
            {
                if (row.Cells["ID"].Value.ToString() == productId)
                {
                    int currentStock = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentStock + quantityChange; 
                }
            }
        }

        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.dgvProductCart.Rows.Count == 0)
            {
                MessageBox.Show("The cart is empty. Please add products to proceed.");
                return;
            }

            string invoiceId = this.GenerateInvoiceId();
            SqlConnection connection = this.Da.Connection;
            SqlTransaction transaction = null;

            try
            {
                transaction = connection.BeginTransaction();

                string sqlSale = @"INSERT INTO Sales (InvoiceID, SaleDate, SubTotal, TaxAmount, GrandTotal) 
                           VALUES (@InvoiceID, @SaleDate, @SubTotal, @TaxAmount, @GrandTotal);";

                SqlCommand cmdSale = new SqlCommand(sqlSale, connection, transaction);
                cmdSale.Parameters.AddWithValue("@InvoiceID", invoiceId);
                cmdSale.Parameters.AddWithValue("@SaleDate", DateTime.Now); 
                cmdSale.Parameters.AddWithValue("@SubTotal", Convert.ToDecimal(this.lblSubTotal.Text.Split('-')[1].Trim()));
                cmdSale.Parameters.AddWithValue("@TaxAmount", Convert.ToDecimal(this.lblTax.Text.Split('-')[1].Trim()));
                cmdSale.Parameters.AddWithValue("@GrandTotal", Convert.ToDecimal(this.lblGrandTotal.Text.Split('-')[1].Trim()));
                cmdSale.ExecuteNonQuery();

                foreach (DataGridViewRow row in this.dgvProductCart.Rows)
                {
                    string sqlDetail = @"INSERT INTO SaleDetails (InvoiceID, ProductID, UnitPrice, Quantity) 
                                 VALUES (@InvoiceID, @ProductID, @UnitPrice, @Quantity);";

                    SqlCommand cmdDetail = new SqlCommand(sqlDetail, connection, transaction);
                    cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    cmdDetail.Parameters.AddWithValue("@ProductID", row.Cells["IDCart"].Value.ToString());
                    cmdDetail.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(row.Cells["PriceCart"].Value));
                    cmdDetail.Parameters.AddWithValue("@Quantity", Convert.ToInt32(row.Cells["QuantityCart"].Value));
                    cmdDetail.ExecuteNonQuery();

                    string sqlProductUpdate = @"UPDATE Products SET Quantity = Quantity - @SoldQuantity 
                                        WHERE ID = @ProductID;";

                    SqlCommand cmdUpdate = new SqlCommand(sqlProductUpdate, connection, transaction);
                    cmdUpdate.Parameters.AddWithValue("@SoldQuantity", Convert.ToInt32(row.Cells["QuantityCart"].Value));
                    cmdUpdate.Parameters.AddWithValue("@ProductID", row.Cells["IDCart"].Value.ToString());
                    cmdUpdate.ExecuteNonQuery();
                }

                
                transaction.Commit();
                MessageBox.Show("Sale confirmed successfully!", "Success");


                DataTable dtCartForInvoice = new DataTable();
                dtCartForInvoice.Columns.Add("Product");
                dtCartForInvoice.Columns.Add("Price", typeof(decimal));
                dtCartForInvoice.Columns.Add("Quantity", typeof(int));
                dtCartForInvoice.Columns.Add("Total", typeof(decimal));

                foreach (DataGridViewRow row in this.dgvProductCart.Rows)
                {
                    dtCartForInvoice.Rows.Add(
                        row.Cells["ProductNameCart"].Value,
                        row.Cells["PriceCart"].Value,
                        row.Cells["QuantityCart"].Value,
                        row.Cells["LineTotalCart"].Value
                    );
                }

                var invoiceForm = new FormInvoice(
                    invoiceId,
                    DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"), 
                    this.lblSubTotal.Text,
                    this.lblTax.Text,
                    this.lblGrandTotal.Text,
                    dtCartForInvoice
                );
                invoiceForm.ShowDialog();

            }
            catch (Exception exc)
            {
                transaction?.Rollback();
                MessageBox.Show("An error occurred. The transaction has been rolled back.\n\nError: " + exc.Message);
            }
            finally
            {
                this.ResetSaleForm();
            }
        }


        private string GenerateInvoiceId()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string newId;
            string query = $"SELECT MAX(InvoiceID) FROM Sales WHERE InvoiceID LIKE 'INV-{datePart}-%';";
            var dt = this.Da.ExecuteQueryTable(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string lastId = dt.Rows[0][0].ToString();
                string[] parts = lastId.Split('-');
                int lastSeq = Convert.ToInt32(parts[2]);
                newId = $"INV-{datePart}-{(lastSeq + 1):D4}";
            }
            else
            {
                newId = $"INV-{datePart}-0001"; 
            }
            return newId;
        }

        private void ResetSaleForm()
        {
            this.dgvProductCart.Rows.Clear();
            this.CalculateTotals();
            this.PopulateProductGrid();
        }


    }
}