namespace FormStart
{
    partial class ucCart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlProductCart = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvProductCart = new System.Windows.Forms.DataGridView();
            this.IDCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineTotalCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.pnlProductCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProductCart
            // 
            this.pnlProductCart.Controls.Add(this.dtpDate);
            this.pnlProductCart.Controls.Add(this.txtSearch);
            this.pnlProductCart.Controls.Add(this.btnConfirm);
            this.pnlProductCart.Controls.Add(this.btnRemove);
            this.pnlProductCart.Controls.Add(this.btnAdd);
            this.pnlProductCart.Controls.Add(this.dgvProductCart);
            this.pnlProductCart.Controls.Add(this.dgvProducts);
            this.pnlProductCart.Location = new System.Drawing.Point(0, 217);
            this.pnlProductCart.Name = "pnlProductCart";
            this.pnlProductCart.Size = new System.Drawing.Size(1214, 461);
            this.pnlProductCart.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(630, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(250, 22);
            this.dtpDate.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(302, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("IBM Plex Sans Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1073, 13);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(119, 48);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("IBM Plex Sans Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(948, 13);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 48);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("IBM Plex Sans Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(461, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 43);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvProductCart
            // 
            this.dgvProductCart.AllowUserToAddRows = false;
            this.dgvProductCart.AllowUserToDeleteRows = false;
            this.dgvProductCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCart,
            this.ProductNameCart,
            this.PriceCart,
            this.QuantityCart,
            this.LineTotalCart});
            this.dgvProductCart.Location = new System.Drawing.Point(579, 70);
            this.dgvProductCart.Name = "dgvProductCart";
            this.dgvProductCart.RowHeadersWidth = 51;
            this.dgvProductCart.RowTemplate.Height = 24;
            this.dgvProductCart.Size = new System.Drawing.Size(632, 388);
            this.dgvProductCart.TabIndex = 1;
            this.dgvProductCart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductCart_CellDoubleClick);
            this.dgvProductCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductCart_CellValueChanged);
            // 
            // IDCart
            // 
            this.IDCart.DataPropertyName = "IDCart";
            this.IDCart.HeaderText = "ID";
            this.IDCart.MinimumWidth = 6;
            this.IDCart.Name = "IDCart";
            this.IDCart.Visible = false;
            this.IDCart.Width = 125;
            // 
            // ProductNameCart
            // 
            this.ProductNameCart.DataPropertyName = "ProductNameCart";
            this.ProductNameCart.HeaderText = "Product Name";
            this.ProductNameCart.MinimumWidth = 6;
            this.ProductNameCart.Name = "ProductNameCart";
            this.ProductNameCart.Width = 125;
            // 
            // PriceCart
            // 
            this.PriceCart.DataPropertyName = "PriceCart";
            this.PriceCart.HeaderText = "Price";
            this.PriceCart.MinimumWidth = 6;
            this.PriceCart.Name = "PriceCart";
            this.PriceCart.Width = 125;
            // 
            // QuantityCart
            // 
            this.QuantityCart.DataPropertyName = "QuantityCart";
            this.QuantityCart.HeaderText = "Quantity";
            this.QuantityCart.MinimumWidth = 6;
            this.QuantityCart.Name = "QuantityCart";
            this.QuantityCart.Width = 125;
            // 
            // LineTotalCart
            // 
            this.LineTotalCart.DataPropertyName = "LineTotalCart";
            this.LineTotalCart.HeaderText = "Total";
            this.LineTotalCart.MinimumWidth = 6;
            this.LineTotalCart.Name = "LineTotalCart";
            this.LineTotalCart.Width = 125;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.ID,
            this.Active,
            this.Quantity,
            this.Price});
            this.dgvProducts.Location = new System.Drawing.Point(3, 70);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(570, 389);
            this.dgvProducts.TabIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 125;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Visible = false;
            this.Active.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Available Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price per Unit";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // pnlCart
            // 
            this.pnlCart.Controls.Add(this.lblCart);
            this.pnlCart.Controls.Add(this.lblGrandTotal);
            this.pnlCart.Controls.Add(this.lblTax);
            this.pnlCart.Controls.Add(this.lblSubTotal);
            this.pnlCart.Location = new System.Drawing.Point(3, 3);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(1211, 208);
            this.pnlCart.TabIndex = 1;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("IBM Plex Sans Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(571, 159);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(164, 28);
            this.lblGrandTotal.TabIndex = 2;
            this.lblGrandTotal.Text = "Grand Total  -  ";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("IBM Plex Sans Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(571, 130);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(136, 28);
            this.lblTax.TabIndex = 1;
            this.lblTax.Text = "Tax (5%)  -  ";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("IBM Plex Sans Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(571, 99);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(131, 28);
            this.lblSubTotal.TabIndex = 0;
            this.lblSubTotal.Text = "Subtotal  -  ";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("IBM Plex Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(79, 74);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(73, 39);
            this.lblCart.TabIndex = 3;
            this.lblCart.Text = "Cart";
            // 
            // ucCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCart);
            this.Controls.Add(this.pnlProductCart);
            this.Name = "ucCart";
            this.Size = new System.Drawing.Size(1217, 679);
            this.pnlProductCart.ResumeLayout(false);
            this.pnlProductCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProductCart;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvProductCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private new System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTotalCart;
        private System.Windows.Forms.Label lblCart;
    }
}
