using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Inicializamos el DatabaseHelper
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dbHelper.TestConnection())
            {
                LoadProducts();
                LoadCategories();
                LoadProviders();
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos. Verifique la configuración.");
            }
        }

        private void LoadProducts()
        {
            try
            {
                DataTable productsTable = dbHelper.GetAllProducts();
                dataGridView1.DataSource = productsTable.Rows.Count > 0 ? productsTable : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}");
            }
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categoriesTable = dbHelper.GetCategories();
                if (categoriesTable.Rows.Count > 0)
                {
                    comboBoxCategory.DataSource = categoriesTable;
                    comboBoxCategory.DisplayMember = "CategoryName";
                    comboBoxCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}");
            }
        }

        private void LoadProviders()
        {
            try
            {
                DataTable providersTable = dbHelper.GetProviders();
                if (providersTable.Rows.Count > 0)
                {
                    comboBoxProvider.DataSource = providersTable;
                    comboBoxProvider.DisplayMember = "ProviderName";
                    comboBoxProvider.ValueMember = "ProviderId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores: {ex.Message}");
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProductInput();

                string productName = textBoxProductName.Text;
                string productCode = textBoxProductCode.Text;
                decimal productPrice = decimal.Parse(textBoxProductPrice.Text);
                int productStock = int.Parse(textBoxProductStock.Text);
                int categoryId = Convert.ToInt32(comboBoxCategory.SelectedValue ?? 0);
                int providerId = Convert.ToInt32(comboBoxProvider.SelectedValue ?? 0);

                dbHelper.AddProduct(productName, productCode, productPrice, productStock, categoryId, providerId);
                MessageBox.Show("Producto agregado exitosamente.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}");
            }
        }

        private void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProductInput();

                int productId = int.Parse(textBoxProductId.Text);
                string productName = textBoxProductName.Text;
                string productCode = textBoxProductCode.Text;
                decimal productPrice = decimal.Parse(textBoxProductPrice.Text);
                int productStock = int.Parse(textBoxProductStock.Text);
                int categoryId = Convert.ToInt32(comboBoxCategory.SelectedValue ?? 0);
                int providerId = Convert.ToInt32(comboBoxProvider.SelectedValue ?? 0);

                dbHelper.UpdateProduct(productId, productName, productCode, productPrice, productStock, categoryId, providerId);
                MessageBox.Show("Producto actualizado exitosamente.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}");
            }
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxProductId.Text))
                {
                    MessageBox.Show("Por favor, seleccione un producto para eliminar.");
                    return;
                }

                int productId = int.Parse(textBoxProductId.Text);
                dbHelper.DeleteProduct(productId);
                MessageBox.Show("Producto eliminado exitosamente.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    textBoxProductId.Text = selectedRow.Cells["ProductId"].Value?.ToString() ?? string.Empty;
                    textBoxProductName.Text = selectedRow.Cells["ProductName"].Value?.ToString() ?? string.Empty;
                    textBoxProductCode.Text = selectedRow.Cells["ProductCode"].Value?.ToString() ?? string.Empty;
                    textBoxProductPrice.Text = selectedRow.Cells["ProductPrice"].Value?.ToString() ?? string.Empty;
                    textBoxProductStock.Text = selectedRow.Cells["ProductStock"].Value?.ToString() ?? string.Empty;
                    comboBoxCategory.SelectedValue = selectedRow.Cells["CategoryId"].Value ?? 0;
                    comboBoxProvider.SelectedValue = selectedRow.Cells["ProviderId"].Value ?? 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el producto seleccionado: {ex.Message}");
                }
            }
        }

        private void ValidateProductInput()
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text) ||
                string.IsNullOrEmpty(textBoxProductCode.Text) ||
                string.IsNullOrEmpty(textBoxProductPrice.Text) ||
                string.IsNullOrEmpty(textBoxProductStock.Text))
            {
                throw new Exception("Por favor, complete todos los campos.");
            }

            if (comboBoxCategory.SelectedValue == null || comboBoxProvider.SelectedValue == null)
            {
                throw new Exception("Por favor, seleccione una categoría y un proveedor válidos.");
            }
        }
    }
}
