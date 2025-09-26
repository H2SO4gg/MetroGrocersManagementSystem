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
    
    public partial class ucSales : UserControl
    {
        private DataAccess Da { get; set; }
        public ucSales()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateSalesGrid();
        }

        private void PopulateSalesGrid()
        {
            try
            {
                string sql = "SELECT InvoiceID, SaleDate, GrandTotal FROM Sales ORDER BY SaleDate DESC;";
                var ds = this.Da.ExecuteQuery(sql, "Sales");

                this.dgvSales.AutoGenerateColumns = false;
                this.dgvSales.DataSource = ds.Tables["Sales"];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error loading sales summary: " + exc.Message);
            }
        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvSales.SelectedRows.Count == 0)
            {
                this.dgvSaleDetails.DataSource = null;
                return;
            }

            try
            {
                string selectedInvoiceId = this.dgvSales.SelectedRows[0].Cells["InvoiceID"].Value.ToString();

                
                string sql = @"SELECT
                           sd.ProductID,
                           p.ProductName,
                           sd.UnitPrice,
                           sd.Quantity
                       FROM
                           SaleDetails sd
                       JOIN
                           Products p ON sd.ProductID = p.ID
                       WHERE
                           sd.InvoiceID = '" + selectedInvoiceId + "';"; 
                var ds = this.Da.ExecuteQuery(sql, "SaleDetails");

                this.dgvSaleDetails.AutoGenerateColumns = false;
                this.dgvSaleDetails.DataSource = ds.Tables["SaleDetails"];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error loading sale details: " + exc.Message);
            }
        }
    }
}
