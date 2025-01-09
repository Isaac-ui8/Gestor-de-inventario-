using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp5; // Ajusta el namespace según corresponda.

public class ProductController
{
    private readonly DatabaseHelper _databaseHelper;

    // Constructor: inicializa el helper de base de datos
    public ProductController()
    {
        _databaseHelper = new DatabaseHelper();
    }

    /// <summary>
    /// Obtiene todos los productos desde la base de datos.
    /// </summary>
    /// <returns>Lista de productos.</returns>
    public List<DataRow> GetAllProducts()
    {
        // Obtener productos desde la base de datos
        var productTable = _databaseHelper.GetAllProducts();
        return new List<DataRow>(productTable.Rows.Cast<DataRow>());
    }

    /// <summary>
    /// Agrega un nuevo producto a la base de datos.
    /// </summary>
    /// <param name="product">Producto que se desea agregar.</param>
    public void AddProduct(string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
    {
        // Validación previa antes de agregar el producto
        if (string.IsNullOrEmpty(productName)) throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (productPrice <= 0) throw new ArgumentException("El precio del producto debe ser mayor a cero.");
        if (productStock < 0) throw new ArgumentException("La existencia del producto no puede ser negativa.");

        // Agregar producto a la base de datos
        _databaseHelper.AddProduct(productName, productCode, productPrice, productStock, categoryId, providerId);
    }

    /// <summary>
    /// Actualiza un producto existente en la base de datos.
    /// </summary>
    /// <param name="productId">ID del producto a actualizar.</param>
    /// <param name="productName">Nuevo nombre del producto.</param>
    /// <param name="productCode">Nuevo código del producto.</param>
    /// <param name="productPrice">Nuevo precio del producto.</param>
    /// <param name="productStock">Nuevo stock del producto.</param>
    /// <param name="categoryId">Nuevo ID de categoría del producto.</param>
    /// <param name="providerId">Nuevo ID de proveedor del producto.</param>
    public void UpdateProduct(int productId, string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
    {
        // Validación previa antes de actualizar el producto
        if (productId <= 0) throw new ArgumentException("El ID del producto debe ser válido.");
        if (string.IsNullOrEmpty(productName)) throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (productPrice <= 0) throw new ArgumentException("El precio del producto debe ser mayor a cero.");
        if (productStock < 0) throw new ArgumentException("La existencia del producto no puede ser negativa.");

        // Actualizar producto en la base de datos
        _databaseHelper.UpdateProduct(productId, productName, productCode, productPrice, productStock, categoryId, providerId);
    }

    /// <summary>
    /// Elimina un producto mediante su ID único.
    /// </summary>
    /// <param name="productId">ID único del producto a eliminar.</param>
    public void DeleteProduct(int productId)
    {
        // Validación del ID del producto
        if (productId <= 0) throw new ArgumentException("El ID del producto debe ser válido.");

        // Eliminar producto de la base de datos
        _databaseHelper.DeleteProduct(productId);
    }

    /// <summary>
    /// Obtiene los productos con un stock bajo (menos de 10 unidades).
    /// </summary>
    /// <returns>Lista de productos con stock bajo.</returns>
    public List<DataRow> GetLowStockProducts()
    {
        var allProducts = GetAllProducts();
        return allProducts.FindAll(p => Convert.ToInt32(p["ProductStock"]) < 10); // Filtrar productos con stock bajo
    }
}
