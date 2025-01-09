using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using WinFormsApp5.Models;

namespace WinFormsApp5
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            // Asegúrate de ajustar el nombre del servidor y base de datos según tu configuración.
            _connectionString = @"Server=LAMAQUINA\SQLEXPRESS;Database=Query1;Trusted_Connection=True;";
        }

        // ===================================
        // Métodos para Productos
        // ===================================

        public DataTable GetAllProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Products";
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var productsTable = new DataTable();
                    adapter.Fill(productsTable);
                    return productsTable;
                }
            }
        }

        public void AddProduct(string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId) 
                              VALUES (@ProductName, @ProductCode, @ProductPrice, @ProductStock, @CategoryId, @ProviderId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.Parameters.AddWithValue("@ProductPrice", productPrice);
                    command.Parameters.AddWithValue("@ProductStock", productStock);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@ProviderId", providerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(int productId, string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"UPDATE Products 
                              SET ProductName = @ProductName, ProductCode = @ProductCode, ProductPrice = @ProductPrice, 
                                  ProductStock = @ProductStock, CategoryId = @CategoryId, ProviderId = @ProviderId
                              WHERE ProductId = @ProductId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.Parameters.AddWithValue("@ProductPrice", productPrice);
                    command.Parameters.AddWithValue("@ProductStock", productStock);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@ProviderId", providerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Products WHERE ProductId = @ProductId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ===================================
        // Métodos para Categorías
        // ===================================

        public DataTable GetCategories()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Categories";
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var categoriesTable = new DataTable();
                    adapter.Fill(categoriesTable);
                    return categoriesTable;
                }
            }
        }

        public void AddCategory(string categoryName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCategory(int categoryId, string categoryName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Categories WHERE CategoryId = @CategoryId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ===================================
        // Métodos para Proveedores
        // ===================================

        public DataTable GetProviders()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Suppliers";
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var providersTable = new DataTable();
                    adapter.Fill(providersTable);
                    return providersTable;
                }
            }
        }

        public void AddProvider(string providerName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Suppliers (SupplierName) VALUES (@ProviderName)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProviderName", providerName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProvider(int providerId, string providerName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"UPDATE Suppliers SET SupplierName = @ProviderName WHERE SupplierId = @ProviderId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProviderId", providerId);
                    command.Parameters.AddWithValue("@ProviderName", providerName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProvider(int providerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Suppliers WHERE SupplierId = @ProviderId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProviderId", providerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ===================================
        // Método para verificar la conexión
        // ===================================

        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return true; // Conexión exitosa
                }
            }
            catch (Exception)
            {
                return false; // Error al intentar conectar
            }
        }
    }
}
