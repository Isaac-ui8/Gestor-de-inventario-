using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class ProductForm : Form
    {
        private DatabaseHelper _databaseHelper;
        private List<DataRow> _products;
        private List<DataRow> _categories;
        private List<DataRow> _providers;

        public ProductForm()
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
            _products = new List<DataRow>();
            _categories = new List<DataRow>();
            _providers = new List<DataRow>();
            LoadData(); // Carga los datos cuando el formulario se inicia
        }

        private void LoadData()
        {
            try
            {
                // Cargar productos desde la base de datos
                var productTable = _databaseHelper.GetAllProducts();
                _products = new List<DataRow>(productTable.Rows.Cast<DataRow>());
                dataGridViewProducts.DataSource = productTable;

                // Cargar categorías
                var categoryTable = _databaseHelper.GetCategories();
                _categories = new List<DataRow>(categoryTable.Rows.Cast<DataRow>());
                comboBoxCategories.DataSource = _categories;
                comboBoxCategories.DisplayMember = "CategoryName";
                comboBoxCategories.ValueMember = "CategoryId";

                // Cargar proveedores
                var providerTable = _databaseHelper.GetProviders();
                _providers = new List<DataRow>(providerTable.Rows.Cast<DataRow>());
                comboBoxProviders.DataSource = _providers;
                comboBoxProviders.DisplayMember = "ProviderName";
                comboBoxProviders.ValueMember = "ProviderId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtProductCode.Text) ||
                    string.IsNullOrWhiteSpace(txtProductPrice.Text) || string.IsNullOrWhiteSpace(txtProductStock.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                decimal productPrice;
                int productStock;

                // Validar que el precio y el stock sean números válidos
                if (!decimal.TryParse(txtProductPrice.Text, out productPrice) || !int.TryParse(txtProductStock.Text, out productStock))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para el precio y el stock.");
                    return;
                }

                var productName = txtProductName.Text;
                var productCode = txtProductCode.Text;
                var categoryId = Convert.ToInt32(comboBoxCategories.SelectedValue ?? 0);
                var providerId = Convert.ToInt32(comboBoxProviders.SelectedValue ?? 0);

                // Verificar que se haya seleccionado una categoría y proveedor válidos
                if (categoryId == 0 || providerId == 0)
                {
                    MessageBox.Show("Por favor, seleccione una categoría y un proveedor válidos.");
                    return;
                }

                // Agregar el producto a la base de datos
                _databaseHelper.AddProduct(productName, productCode, productPrice, productStock, categoryId, providerId);
                LoadData(); // Recargar los datos
                MessageBox.Show("Producto agregado exitosamente.");
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
                // Validar que se haya seleccionado un producto para actualizar
                if (string.IsNullOrWhiteSpace(txtProductId.Text))
                {
                    MessageBox.Show("Seleccione un producto para actualizar.");
                    return;
                }

                decimal productPrice;
                int productStock;

                // Validar que el precio y el stock sean números válidos
                if (!decimal.TryParse(txtProductPrice.Text, out productPrice) || !int.TryParse(txtProductStock.Text, out productStock))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para el precio y el stock.");
                    return;
                }

                var productId = int.Parse(txtProductId.Text);
                var productName = txtProductName.Text;
                var productCode = txtProductCode.Text;
                var categoryId = Convert.ToInt32(comboBoxCategories.SelectedValue ?? 0);
                var providerId = Convert.ToInt32(comboBoxProviders.SelectedValue ?? 0);

                // Verificar que se haya seleccionado una categoría y proveedor válidos
                if (categoryId == 0 || providerId == 0)
                {
                    MessageBox.Show("Por favor, seleccione una categoría y un proveedor válidos.");
                    return;
                }

                // Actualizar el producto en la base de datos
                _databaseHelper.UpdateProduct(productId, productName, productCode, productPrice, productStock, categoryId, providerId);
                LoadData(); // Recargar los datos
                MessageBox.Show("Producto actualizado exitosamente.");
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
                // Validar que se haya seleccionado un producto
                if (string.IsNullOrWhiteSpace(txtProductId.Text))
                {
                    MessageBox.Show("Seleccione un producto para eliminar.");
                    return;
                }

                var productId = int.Parse(txtProductId.Text);
                _databaseHelper.DeleteProduct(productId);
                LoadData(); // Recargar los datos
                MessageBox.Show("Producto eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
            }
        }

        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            // Asegurarse de que haya una fila seleccionada
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var row = dataGridViewProducts.SelectedRows[0];
                txtProductId.Text = row.Cells["ProductId"].Value?.ToString() ?? string.Empty;
                txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? string.Empty;
                txtProductCode.Text = row.Cells["ProductCode"].Value?.ToString() ?? string.Empty;
                txtProductPrice.Text = row.Cells["ProductPrice"].Value?.ToString() ?? string.Empty;
                txtProductStock.Text = row.Cells["ProductStock"].Value?.ToString() ?? string.Empty;
                comboBoxCategories.SelectedValue = row.Cells["CategoryId"].Value ?? 0;
                comboBoxProviders.SelectedValue = row.Cells["ProviderId"].Value ?? 0;
            }
        }
    }
}
