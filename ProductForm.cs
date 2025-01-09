using System;
using System.Windows.Forms;
using System.Collections.Generic;
using WinFormsApp5.Repositories; // Asegúrate de incluir el namespace correcto.

public partial class ProductForm : Form
{
    private ProductRepository _productRepository;
    private CategoryRepository _categoryRepository;
    private ProviderRepository _providerRepository;
    private List<Products> _products;
    private List<Category> _categories;
    private List<Provider> _providers;

    public ProductForm()
    {
        InitializeComponent();
        _productRepository = new ProductRepository();
        _categoryRepository = new CategoryRepository();
        _providerRepository = new ProviderRepository();
        LoadData();
    }

    private void LoadData()
    {
        // Cargar productos
        _products = _productRepository.GetAllProducts();
        dataGridViewProducts.DataSource = _products;

        // Cargar categorías
        _categories = _categoryRepository.GetCategories();
        comboBoxCategories.DataSource = _categories;
        comboBoxCategories.DisplayMember = "Nombre";
        comboBoxCategories.ValueMember = "IdCategoria";

        // Cargar proveedores
        _providers = _providerRepository.GetProviders();
        comboBoxProviders.DataSource = _providers;
        comboBoxProviders.DisplayMember = "NombreEmpresa";
        comboBoxProviders.ValueMember = "IdProveedor";
    }

    private void BtnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            var product = new Products
            {
                Nombre = txtProductName.Text,
                CodigoProducto = txtProductCode.Text,
                CategoriaId = (int)comboBoxCategories.SelectedValue,
                Precio = decimal.Parse(txtProductPrice.Text),
                Existencia = int.Parse(txtProductStock.Text),
                ProveedorId = (int)comboBoxProviders.SelectedValue
            };

            _productRepository.AddProduct(product);
            LoadData();
            MessageBox.Show("Producto agregado exitosamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void BtnUpdateProduct_Click(object sender, EventArgs e)
    {
        try
        {
            var product = new Products
            {
                IdProducto = int.Parse(txtProductId.Text),
                Nombre = txtProductName.Text,
                CodigoProducto = txtProductCode.Text,
                CategoriaId = (int)comboBoxCategories.SelectedValue,
                Precio = decimal.Parse(txtProductPrice.Text),
                Existencia = int.Parse(txtProductStock.Text),
                ProveedorId = (int)comboBoxProviders.SelectedValue
            };

            _productRepository.UpdateProduct(product);
            LoadData();
            MessageBox.Show("Producto actualizado exitosamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void BtnDeleteProduct_Click(object sender, EventArgs e)
    {
        try
        {
            var productId = int.Parse(txtProductId.Text);
            _productRepository.DeleteProduct(productId);
            LoadData();
            MessageBox.Show("Producto eliminado exitosamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridViewProducts.SelectedRows.Count > 0)
        {
            var row = dataGridViewProducts.SelectedRows[0];
            txtProductId.Text = row.Cells["IdProducto"].Value.ToString();
            txtProductName.Text = row.Cells["Nombre"].Value.ToString();
            txtProductCode.Text = row.Cells["CodigoProducto"].Value.ToString();
            txtProductPrice.Text = row.Cells["Precio"].Value.ToString();
            txtProductStock.Text = row.Cells["Existencia"].Value.ToString();
            comboBoxCategories.SelectedValue = row.Cells["CategoriaId"].Value;
            comboBoxProviders.SelectedValue = row.Cells["ProveedorId"].Value;
        }
    }
}
