namespace WinFormsApp5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button BtnAddProduct;
        private System.Windows.Forms.Button BtnUpdateProduct;
        private System.Windows.Forms.Button BtnDeleteProduct;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.TextBox textBoxProductPrice;
        private System.Windows.Forms.TextBox textBoxProductStock;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblProductStock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            BtnAddProduct = new Button();
            BtnUpdateProduct = new Button();
            BtnDeleteProduct = new Button();
            comboBoxCategory = new ComboBox();
            comboBoxProvider = new ComboBox();
            textBoxProductName = new TextBox();
            textBoxProductCode = new TextBox();
            textBoxProductPrice = new TextBox();
            textBoxProductStock = new TextBox();
            lblProductName = new Label();
            lblProductCode = new Label();
            lblCategory = new Label();
            lblProvider = new Label();
            lblProductPrice = new Label();
            lblProductStock = new Label();
            dataGridView1 = new DataGridView();
            textBoxProductId = new TextBox();
            sqlConnection1 = new Microsoft.Data.SqlClient.SqlConnection();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BtnAddProduct
            // 
            BtnAddProduct.BackColor = Color.MediumSeaGreen;
            BtnAddProduct.FlatStyle = FlatStyle.Flat;
            BtnAddProduct.ForeColor = Color.White;
            BtnAddProduct.Location = new Point(12, 450);
            BtnAddProduct.Name = "BtnAddProduct";
            BtnAddProduct.Size = new Size(150, 40);
            BtnAddProduct.TabIndex = 1;
            BtnAddProduct.Text = "Agregar Producto";
            BtnAddProduct.UseVisualStyleBackColor = false;
            BtnAddProduct.Click += BtnAddProduct_Click;
            // 
            // BtnUpdateProduct
            // 
            BtnUpdateProduct.BackColor = Color.DodgerBlue;
            BtnUpdateProduct.FlatStyle = FlatStyle.Flat;
            BtnUpdateProduct.ForeColor = Color.White;
            BtnUpdateProduct.Location = new Point(180, 450);
            BtnUpdateProduct.Name = "BtnUpdateProduct";
            BtnUpdateProduct.Size = new Size(150, 40);
            BtnUpdateProduct.TabIndex = 2;
            BtnUpdateProduct.Text = "Actualizar Producto";
            BtnUpdateProduct.UseVisualStyleBackColor = false;
            BtnUpdateProduct.Click += BtnUpdateProduct_Click;
            // 
            // BtnDeleteProduct
            // 
            BtnDeleteProduct.BackColor = Color.Crimson;
            BtnDeleteProduct.FlatStyle = FlatStyle.Flat;
            BtnDeleteProduct.ForeColor = Color.White;
            BtnDeleteProduct.Location = new Point(350, 450);
            BtnDeleteProduct.Name = "BtnDeleteProduct";
            BtnDeleteProduct.Size = new Size(150, 40);
            BtnDeleteProduct.TabIndex = 3;
            BtnDeleteProduct.Text = "Eliminar Producto";
            BtnDeleteProduct.UseVisualStyleBackColor = false;
            BtnDeleteProduct.Click += BtnDeleteProduct_Click;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(12, 330);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 28);
            comboBoxCategory.TabIndex = 4;
            // 
            // comboBoxProvider
            // 
            comboBoxProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvider.FormattingEnabled = true;
            comboBoxProvider.Location = new Point(220, 330);
            comboBoxProvider.Name = "comboBoxProvider";
            comboBoxProvider.Size = new Size(200, 28);
            comboBoxProvider.TabIndex = 5;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(12, 270);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(200, 27);
            textBoxProductName.TabIndex = 6;
            // 
            // textBoxProductCode
            // 
            textBoxProductCode.Location = new Point(220, 270);
            textBoxProductCode.Name = "textBoxProductCode";
            textBoxProductCode.Size = new Size(200, 27);
            textBoxProductCode.TabIndex = 7;
            // 
            // textBoxProductPrice
            // 
            textBoxProductPrice.Location = new Point(12, 383);
            textBoxProductPrice.Name = "textBoxProductPrice";
            textBoxProductPrice.Size = new Size(200, 27);
            textBoxProductPrice.TabIndex = 8;
            // 
            // textBoxProductStock
            // 
            textBoxProductStock.Location = new Point(218, 383);
            textBoxProductStock.Name = "textBoxProductStock";
            textBoxProductStock.Size = new Size(200, 27);
            textBoxProductStock.TabIndex = 9;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(12, 250);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(128, 20);
            lblProductName.TabIndex = 11;
            lblProductName.Text = "Nombre Producto";
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(220, 250);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(122, 20);
            lblProductCode.TabIndex = 12;
            lblProductCode.Text = "Código Producto";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 310);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(74, 20);
            lblCategory.TabIndex = 13;
            lblCategory.Text = "Categoría";
            // 
            // lblProvider
            // 
            lblProvider.AutoSize = true;
            lblProvider.Location = new Point(220, 310);
            lblProvider.Name = "lblProvider";
            lblProvider.Size = new Size(77, 20);
            lblProvider.TabIndex = 14;
            lblProvider.Text = "Proveedor";
            // 
            // lblProductPrice
            // 
            lblProductPrice.AutoSize = true;
            lblProductPrice.Location = new Point(12, 360);
            lblProductPrice.Name = "lblProductPrice";
            lblProductPrice.Size = new Size(50, 20);
            lblProductPrice.TabIndex = 15;
            lblProductPrice.Text = "Precio";
            // 
            // lblProductStock
            // 
            lblProductStock.AutoSize = true;
            lblProductStock.Location = new Point(220, 360);
            lblProductStock.Name = "lblProductStock";
            lblProductStock.Size = new Size(45, 20);
            lblProductStock.TabIndex = 16;
            lblProductStock.Text = "Stock";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(746, 221);
            dataGridView1.TabIndex = 17;
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(450, 270);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new Size(200, 27);
            textBoxProductId.TabIndex = 10;
            // 
            // sqlConnection1
            // 
            sqlConnection1.AccessTokenCallback = null;
            sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveBorder;
            label1.Location = new Point(599, 482);
            label1.Name = "label1";
            label1.Size = new Size(173, 20);
            label1.TabIndex = 18;
            label1.Text = "Por ISaac González Pérez";
            // 
            // Form1
            // 
            ClientSize = new Size(784, 511);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(lblProductStock);
            Controls.Add(lblProductPrice);
            Controls.Add(lblProvider);
            Controls.Add(lblCategory);
            Controls.Add(lblProductCode);
            Controls.Add(lblProductName);
            Controls.Add(textBoxProductId);
            Controls.Add(textBoxProductStock);
            Controls.Add(textBoxProductPrice);
            Controls.Add(textBoxProductCode);
            Controls.Add(textBoxProductName);
            Controls.Add(comboBoxProvider);
            Controls.Add(comboBoxCategory);
            Controls.Add(BtnDeleteProduct);
            Controls.Add(BtnUpdateProduct);
            Controls.Add(BtnAddProduct);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridView1;
        private TextBox textBoxProductId;
        private Microsoft.Data.SqlClient.SqlConnection sqlConnection1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private Label label1;
    }
}
