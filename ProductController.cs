using System;
using System.Collections.Generic;
using WinFormsApp5.Repositories; // Asegúrate de usar el namespace correcto.

public class ProductController
{
    private readonly ProductRepository _productRepository;

    // Constructor: inicializa el repositorio de productos
    public ProductController()
    {
        _productRepository = new ProductRepository();
    }

    /// <summary>
    /// Obtiene todos los productos desde el repositorio.
    /// </summary>
    /// <returns>Lista de productos.</returns>
    public List<Products> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    /// <summary>
    /// Agrega un nuevo producto usando el repositorio.
    /// </summary>
    /// <param name="product">Producto que se desea agregar.</param>
    public void AddProduct(Products product)
    {
        // Validación previa antes de agregar el producto
        if (product == null) throw new ArgumentNullException(nameof(product), "El producto no puede ser nulo.");

        // Validación de datos esenciales
        if (string.IsNullOrEmpty(product.Nombre)) throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(product.Nombre));
        if (product.Precio <= 0) throw new ArgumentException("El precio del producto debe ser mayor a cero.", nameof(product.Precio));
        if (product.Existencia < 0) throw new ArgumentException("La existencia del producto no puede ser negativa.", nameof(product.Existencia));

        // Agregar producto al repositorio
        _productRepository.AddProduct(product);
    }

    /// <summary>
    /// Actualiza un producto existente en el repositorio.
    /// </summary>
    /// <param name="product">Producto con los datos actualizados.</param>
    public void UpdateProduct(Products product)
    {
        // Validación previa antes de actualizar el producto
        if (product == null) throw new ArgumentNullException(nameof(product), "El producto no puede ser nulo.");

        // Validación de datos esenciales
        if (product.IdProducto <= 0) throw new ArgumentException("El ID del producto debe ser válido.", nameof(product.IdProducto));
        if (string.IsNullOrEmpty(product.Nombre)) throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(product.Nombre));
        if (product.Precio <= 0) throw new ArgumentException("El precio del producto debe ser mayor a cero.", nameof(product.Precio));
        if (product.Existencia < 0) throw new ArgumentException("La existencia del producto no puede ser negativa.", nameof(product.Existencia));

        // Actualizar el producto en el repositorio
        _productRepository.UpdateProduct(product);
    }

    /// <summary>
    /// Elimina un producto mediante su ID único.
    /// </summary>
    /// <param name="idProducto">ID único del producto a eliminar.</param>
    public void DeleteProduct(int idProducto)
    {
        // Validación del ID de producto
        if (idProducto <= 0) throw new ArgumentException("El ID del producto debe ser válido.", nameof(idProducto));

        // Eliminar producto del repositorio
        _productRepository.DeleteProduct(idProducto);
    }

    /// <summary>
    /// Obtiene los productos con un stock bajo (menos de 10 unidades).
    /// </summary>
    /// <returns>Lista de productos con stock bajo.</returns>
    public List<Products> GetLowStockProducts()
    {
        var allProducts = _productRepository.GetAllProducts();
        return allProducts.FindAll(p => p.Existencia < 10); // Filtrar productos con stock bajo
    }
}
