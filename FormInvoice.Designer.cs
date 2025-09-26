namespace FormStart
{
    partial class FormInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.dgvInvoiceItems = new System.Windows.Forms.DataGridView();
            this.lblInvoiceIdValue = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblGrandTotalValue = new System.Windows.Forms.Label();
            this.pnlInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Controls.Add(this.lblGrandTotalValue);
            this.pnlInvoice.Controls.Add(this.lblSubTotalValue);
            this.pnlInvoice.Controls.Add(this.lblDateValue);
            this.pnlInvoice.Controls.Add(this.lblInvoiceIdValue);
            this.pnlInvoice.Controls.Add(this.dgvInvoiceItems);
            this.pnlInvoice.Location = new System.Drawing.Point(2, 1);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(442, 671);
            this.pnlInvoice.TabIndex = 0;
            // 
            // dgvInvoiceItems
            // 
            this.dgvInvoiceItems.AllowUserToAddRows = false;
            this.dgvInvoiceItems.AllowUserToDeleteRows = false;
            this.dgvInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceItems.Location = new System.Drawing.Point(3, 123);
            this.dgvInvoiceItems.Name = "dgvInvoiceItems";
            this.dgvInvoiceItems.ReadOnly = true;
            this.dgvInvoiceItems.RowHeadersWidth = 51;
            this.dgvInvoiceItems.RowTemplate.Height = 24;
            this.dgvInvoiceItems.Size = new System.Drawing.Size(436, 403);
            this.dgvInvoiceItems.TabIndex = 0;
            // 
            // lblInvoiceIdValue
            // 
            this.lblInvoiceIdValue.AutoSize = true;
            this.lblInvoiceIdValue.Font = new System.Drawing.Font("IBM Plex Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceIdValue.Location = new System.Drawing.Point(10, 8);
            this.lblInvoiceIdValue.Name = "lblInvoiceIdValue";
            this.lblInvoiceIdValue.Size = new System.Drawing.Size(120, 28);
            this.lblInvoiceIdValue.TabIndex = 1;
            this.lblInvoiceIdValue.Text = "Invoice ID : ";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValue.Location = new System.Drawing.Point(72, 58);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(58, 24);
            this.lblDateValue.TabIndex = 2;
            this.lblDateValue.Text = "Date : ";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.AutoSize = true;
            this.lblSubTotalValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalValue.Location = new System.Drawing.Point(236, 551);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(89, 24);
            this.lblSubTotalValue.TabIndex = 3;
            this.lblSubTotalValue.Text = "Subtotal : ";
            // 
            // lblGrandTotalValue
            // 
            this.lblGrandTotalValue.AutoSize = true;
            this.lblGrandTotalValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalValue.Location = new System.Drawing.Point(142, 591);
            this.lblGrandTotalValue.Name = "lblGrandTotalValue";
            this.lblGrandTotalValue.Size = new System.Drawing.Size(183, 24);
            this.lblGrandTotalValue.TabIndex = 5;
            this.lblGrandTotalValue.Text = "Grand Total (5% tax) : ";
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 674);
            this.Controls.Add(this.pnlInvoice);
            this.Name = "FormInvoice";
            this.Text = "FormInvoice";
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.DataGridView dgvInvoiceItems;
        private System.Windows.Forms.Label lblGrandTotalValue;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblInvoiceIdValue;
    }
}