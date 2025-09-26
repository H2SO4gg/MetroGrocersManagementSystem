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
    public partial class FormInvoice : Form
    {
        public FormInvoice()
        {
            InitializeComponent();
        }

        public FormInvoice(string invoiceId, string date, string subTotal, string tax, string grandTotal, DataTable cartItems)
        {
            InitializeComponent();

            // Populate the labels with the summary data
            this.lblInvoiceIdValue.Text = invoiceId;
            this.lblDateValue.Text = date;
            this.lblSubTotalValue.Text = subTotal;
            this.lblGrandTotalValue.Text = grandTotal;

            // Set the DataGridView's data source to the list of items
            this.dgvInvoiceItems.AutoGenerateColumns = true; // Let it create columns automatically
            this.dgvInvoiceItems.DataSource = cartItems;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
